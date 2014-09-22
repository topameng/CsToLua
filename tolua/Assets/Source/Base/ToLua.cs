/* designed by topameng. this is only ver0.9
 * 1.0 more fast version is coming soon
*/
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using LuaInterface;
using System.IO;

using Object = UnityEngine.Object;

public enum MetaOp
{
    None = 0,
    Add = 1,
    Sub = 2,
    Mul = 4,
    Div = 8,
    Eq = 16,
    Neg = 32,
    ALL = Add | Sub | Mul | Div | Eq | Neg,
}

public enum ObjAmbig
{
    None = 0,
    U3dObj = 1,
    NetObj = 2,
    All = 3
}

public static class ToLua 
{
    public static string className = "Quaternion";
    public static Type type = typeof(Quaternion);

    //设置之后继承基类，不然就导入所有基类信息
    public static string baseClassName = "object"; //"Behaviour"; //"MonoBehaviour";  //"Component";
    public static bool isStaticClass = false;

    static HashSet<string> usingList = new HashSet<string>();
    static MetaOp op = MetaOp.None;    
    static StringBuilder sb = null;
    static MethodInfo[] methods = null;
    static Dictionary<string, int> nameCounter = null;
    static FieldInfo[] fields = null;
    static PropertyInfo[] props = null;
    static List<PropertyInfo> propList = new List<PropertyInfo>();

    static BindingFlags binding = BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase;// | BindingFlags.FlattenHierarchy;

    static MethodInfo setItem = null;
    static MethodInfo getItem = null;
    static ObjAmbig ambig = ObjAmbig.NetObj;

    static ToLua()
    {
                
    }

    public static void Clear()
    {
        className = null;
        type = null;
        isStaticClass = false;
        baseClassName = null;
        usingList.Clear();
        op = MetaOp.None;
        sb = new StringBuilder();
        methods = null;
        fields = null;
        props = null;
        propList.Clear();
    }

    public static void Generate(params string[] param)
    {
        nameCounter = new Dictionary<string, int>();
        sb = new StringBuilder();
        List<MethodInfo> list = new List<MethodInfo>();

        if (baseClassName != null)
        {
            binding |= BindingFlags.DeclaredOnly;
        }

        if (type.IsInterface)
        {
            list.AddRange(type.GetMethods());
        }
        else
        {
            list.AddRange(type.GetMethods(BindingFlags.Instance | binding));            

            for (int i = list.Count - 1; i >= 0; --i)
            {
                //先去掉操作符函数
                if (list[i].Name.Contains("op_"))
                {
                    if (!IsNeedOp(list[i].Name))
                    {
                        list.RemoveAt(i);
                    }

                    continue;
                }

                //扔掉 unity3d 废弃的函数
                object[] attrs = list[i].GetCustomAttributes(true);

                for (int j = 0; j < attrs.Length; j++)
                {
                    if (attrs[j].GetType() == typeof(System.ObsoleteAttribute))
                    {
                        list.RemoveAt(i);
                        break;    
                    }
                }
            }
        }

        getItem = list.Find((m) => { return m.Name == "get_Item";});
        setItem = list.Find((m) => { return m.Name == "set_Item"; });

        PropertyInfo[] ps = type.GetProperties();                     

        for (int i = 0; i < ps.Length; i++)
        {
            int index = list.FindIndex((m) => { return m.Name == "get_" + ps[i].Name; });

            if (index >= 0)
            {                
                list.RemoveAt(index);
            }

            index = list.FindIndex((m) => { return m.Name == "set_" + ps[i].Name; });

            if (index >= 0)
            {
                list.RemoveAt(index);
            }
        }

        methods = list.ToArray();

        Debugger.Log("Begin Generate lua Wrap for class {0}\r\n", className);
                
        sb.AppendFormat("public class {0}Wrap : ILuaWrap\r\n", className);
        sb.AppendLine("{");        
        sb.AppendLine("\tpublic static LuaScriptMgr luaMgr = null;");
        sb.AppendLine("\tpublic static int reference = -1;\r\n");

        AddRegVar();
        GenConstruct();
        GenRegFunc();
        GenIndexFunc();
        GenNewIndexFunc();
        GenToStringFunc();
        GenFunction();        

        sb.AppendLine("}\r\n");
        //Debugger.Log(sb.ToString());

        usingList.Add("UnityEngine");
        usingList.Add("System");
        string file = Application.dataPath + "/Source/LuaWrap/" + className + "Wrap.cs";

        using (StreamWriter textWriter = new StreamWriter(file, false, Encoding.UTF8))
        {
            //textWriter.Write(usingInfo);
            StringBuilder usb = new StringBuilder();

            foreach (string str in usingList)
            {
                usb.AppendFormat("using {0};\r\n", str);
            }

            usb.AppendLine("using LuaInterface;");

            if (ambig == ObjAmbig.All)
            {
                usb.AppendLine("using Object = UnityEngine.Object;");
            }

            usb.AppendLine();

            textWriter.Write(usb.ToString());
            textWriter.Write(sb.ToString());
            textWriter.Flush();
            textWriter.Close();
        }    
    }

    static void AddRegVar()
    {
        sb.AppendLine("\tpublic static LuaMethod[] regs = new LuaMethod[]");
        sb.AppendLine("\t{");

        //注册库函数
        for (int i = 0; i < methods.Length; i++)
        {
            MethodInfo m = methods[i];
            int count = 1;

            if (m.IsGenericMethod)
            {
                continue;
            }                       

            if (!nameCounter.TryGetValue(m.Name, out count))
            {
                if (!m.Name.Contains("op_"))
                {
                    sb.AppendFormat("\t\tnew LuaMethod(\"{0}\", {0}),\r\n", m.Name);
                }

                nameCounter[m.Name] = 1;
            }
            else
            {
                nameCounter[m.Name] = count + 1;
            }
        }        

        sb.AppendLine("\t\tnew LuaMethod(\"New\", Create),");
        sb.AppendLine("\t};\r\n");
        fields = type.GetFields(BindingFlags.GetField | BindingFlags.SetField | BindingFlags.Instance | binding);
        props = type.GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Instance | binding);
        propList.AddRange(type.GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase));

        List<FieldInfo> fieldList = new List<FieldInfo>();
        fieldList.AddRange(fields);

        for (int i = fieldList.Count - 1; i >= 0; i--)
        {
            object[] attrs = fieldList[i].GetCustomAttributes(true);

            for (int j = 0; j < attrs.Length; j++)
            {
                if (attrs[j].GetType() == typeof(System.ObsoleteAttribute))
                {
                    fieldList.RemoveAt(i);
                    break;
                }
            }
        }

        fields = fieldList.ToArray();

        List<PropertyInfo> piList = new List<PropertyInfo>();
        piList.AddRange(props);

        for (int i = piList.Count - 1; i >= 0; i--)
        {
            object[] attrs = piList[i].GetCustomAttributes(true);

            if (piList[i].Name == "Item")
            {
                piList.RemoveAt(i);
                continue;
            }

            for (int j = 0; j < attrs.Length; j++)
            {
                if (attrs[j].GetType() == typeof(System.ObsoleteAttribute))
                {
                    piList.RemoveAt(i);
                    break;
                }
            }
        }

        props = piList.ToArray();

        for (int i = propList.Count - 1; i >= 0; i--)
        {
            object[] attrs = propList[i].GetCustomAttributes(true);

            if (propList[i].Name == "Item")
            {
                propList.RemoveAt(i);
                continue;
            }

            for (int j = 0; j < attrs.Length; j++)
            {
                if (attrs[j].GetType() == typeof(System.ObsoleteAttribute))
                {
                    propList.RemoveAt(i);
                    break;
                }
            }
        }

        sb.AppendLine("\tstatic LuaField[] fields = new LuaField[]");
        sb.AppendLine("\t{");

        for (int i = 0; i < fields.Length; i++)
        {
            if (fields[i].IsLiteral || fields[i].IsPrivate || fields[i].IsInitOnly)
            {
                sb.AppendFormat("\t\tnew LuaField(\"{0}\", get_{0}, null),\r\n", fields[i].Name);
            }
            else
            {
                sb.AppendFormat("\t\tnew LuaField(\"{0}\", get_{0}, set_{0}),\r\n", fields[i].Name);
            }
        }

        for (int i = 0; i < props.Length; i++)
        {
            if (props[i].CanRead && props[i].CanWrite && props[i].GetSetMethod(true).IsPublic)
            {
                sb.AppendFormat("\t\tnew LuaField(\"{0}\", get_{0}, set_{0}),\r\n", props[i].Name);
            }
            else if (props[i].CanRead)
            {
                sb.AppendFormat("\t\tnew LuaField(\"{0}\", get_{0}, null),\r\n", props[i].Name);
            }
            else if (props[i].CanWrite)
            {
                sb.AppendFormat("\t\tnew LuaField(\"{0}\", null, set_{0}),\r\n", props[i].Name);
            }
        }

        sb.AppendLine("\t};");
    }

    static void GenOperatorReg()
    {
        if ((op & MetaOp.Add) != 0)
        {            
            sb.AppendLine("\t\t\tnew LuaMethod(\"__add\", Lua_Add),");                                            
        }

        if ((op & MetaOp.Sub) != 0)
        {
            sb.AppendLine("\t\t\tnew LuaMethod(\"__sub\", Lua_Sub),");
        }

        if ((op & MetaOp.Mul) != 0)
        {
            sb.AppendLine("\t\t\tnew LuaMethod(\"__mul\", Lua_Mul),");
        }

        if ((op & MetaOp.Div) != 0)
        {
            sb.AppendLine("\t\t\tnew LuaMethod(\"__div\", Lua_Div),");
        }

        if ((op & MetaOp.Eq) != 0)
        {
            sb.AppendLine("\t\t\tnew LuaMethod(\"__eq\", Lua_Eq),");    
        }

        if ((op & MetaOp.Neg) != 0)
        {
            sb.AppendLine("\t\t\tnew LuaMethod(\"__unm\", Lua_Neg),");    
        }
    }

    static void GenRegFunc()
    {
        sb.AppendLine("\r\n\tpublic void Register()");
        sb.AppendLine("\t{");

        sb.AppendLine("\t\tLuaMethod[] metas = new LuaMethod[]");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tnew LuaMethod(\"__index\", Lua_Index),");
        sb.AppendLine("\t\t\tnew LuaMethod(\"__newindex\", Lua_NewIndex),");

        //ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | binding);
        int index = Array.FindIndex<MethodInfo>(methods, (p) => {return p.Name == "ToString";});

        if (index >= 0)
        {
            sb.AppendLine("\t\t\tnew LuaMethod(\"__tostring\", Lua_ToString),");
        }

        GenOperatorReg();
        sb.AppendLine("\t\t};\r\n");

        sb.AppendLine("\t\tluaMgr = LuaScriptMgr.Instance;");       
        sb.AppendFormat("\t\treference = luaMgr.RegisterLib(\"{0}\", regs);\r\n", className);                                        
        sb.AppendFormat("\t\tluaMgr.CreateMetaTable(\"{0}\", metas, typeof({0}));\r\n", className);
        sb.AppendFormat("\t\tluaMgr.RegisterField(typeof({0}), fields);\r\n", className);
        sb.AppendLine("\t}");
    }

    static bool IsParams(ParameterInfo param)
    {
        return param.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0;
    }

    static void GenFunction()
    {
        HashSet<string> set = new HashSet<string>();

        for (int i = 0; i < methods.Length; i++)
        {
            MethodInfo m = methods[i];

            if (m.IsGenericMethod)
            {
                Debugger.Log("Generic Method {0} cannot be export to lua", m.Name);
                continue;
            }

            if (nameCounter[m.Name] > 1)
            {
                if (!set.Contains(m.Name))
                {
                    MethodInfo mi = GenOverrideFunc(m.Name);

                    if (mi == null)
                    {
                        set.Add(m.Name);
                        continue;
                    }
                    else
                    {
                        m = mi;
                    }
                }
                else
                {
                    continue;
                }
            }
            
            set.Add(m.Name);
            sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
            sb.AppendFormat("\tstatic int {0}(IntPtr l)\r\n", GetFuncName(m.Name));
            sb.AppendLine("\t{");
            
            ParameterInfo[] paramInfos = m.GetParameters();            
            int offset = m.IsStatic ? 1 : 2;
            bool haveParams = HasOptionalParam(paramInfos);

            if (!haveParams)
            {
                sb.AppendFormat("\t\tluaMgr.CheckArgsCount({0});\r\n", paramInfos.Length + offset - 1);
            }
            else
            {
                sb.AppendLine("\t\tint count = LuaDLL.lua_gettop(l);");
            }

            int rc = m.ReturnType == typeof(void) ? 0 : 1;
            rc += ProcessParams(m, 2, false);            
            sb.AppendFormat("\t\treturn {0};\r\n", rc);
            sb.AppendLine("\t}");
        }
    }    

    static void GenConstruct()
    {
        if (isStaticClass)
        {
            sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
            sb.AppendFormat("\tstatic int {0}(IntPtr l)\r\n", "Create");
            sb.AppendLine("\t{");
            sb.AppendFormat("\t\tLuaDLL.luaL_error(l, \"{0} class does not have a constructor function\");\r\n", className);
            sb.AppendLine("\t\treturn 0;");
            sb.AppendLine("\t}");
            return;
        }

        ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | binding);

        if (constructors.Length == 0)
        {
            if (!type.IsValueType)
            {
                sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
                sb.AppendFormat("\tstatic int {0}(IntPtr l)\r\n", "Create");
                sb.AppendLine("\t{");
                sb.AppendFormat("\t\tLuaDLL.luaL_error(l, \"{0} class does not have a constructor function\");\r\n", className);
                sb.AppendLine("\t\treturn 0;");
                sb.AppendLine("\t}");
            }
            else
            {
                sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
                sb.AppendFormat("\tstatic int {0}(IntPtr l)\r\n", "Create");
                sb.AppendLine("\t{");
                sb.AppendLine("\t\tluaMgr.CheckArgsCount(0);");
                sb.AppendFormat("\t\tobject obj = new {0}();\r\n", className);
                sb.AppendLine("\t\tluaMgr.PushResult(obj);");
                sb.AppendLine("\t\treturn 1;");
                sb.AppendLine("\t}");
            }

            return;
        }

        List<ConstructorInfo> list = new List<ConstructorInfo>();
        list.AddRange(constructors);
        list.Sort(Compare);

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}(IntPtr l)\r\n", "Create");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tint count = LuaDLL.lua_gettop(l);");
        sb.AppendLine("\t\tobject obj = null;");

        sb.AppendLine();

        List<ConstructorInfo> countList = new List<ConstructorInfo>();

        for (int i = 0; i < list.Count; i++)
        {
            int index = list.FindIndex((p) => { return p != list[i] && p.GetParameters().Length == list[i].GetParameters().Length; });

            if (index >= 0)
            {
                countList.Add(list[i]);
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (countList.Contains(list[i]))
            {
                CreateParamTypes(i, list[i].GetParameters(), true);
            }
        }

        if (countList.Count > 1)
        {
            sb.AppendLine();
        }

        MethodBase md = list[0];
        bool hasEmptyCon = list[0].GetParameters().Length == 0 ? true : false;

        if (list.Count == 1 || md.GetParameters().Length != list[1].GetParameters().Length)
        {
            sb.AppendFormat("\t\tif (count == {0})\r\n", md.GetParameters().Length);
        }
        else
        {
            sb.AppendFormat("\t\tif (count == {0} && luaMgr.CheckTypes(types0, {1}))\r\n", md.GetParameters().Length, 1);
        }

        sb.AppendLine("\t\t{");
        int rc = ProcessParams(md, 3, true);
        sb.AppendFormat("\t\t\treturn {0};\r\n", rc);
        sb.AppendLine("\t\t}");

        for (int i = 1; i < list.Count; i++)
        {
            hasEmptyCon = list[i].GetParameters().Length == 0 ? true : hasEmptyCon;
            md = list[i];

            if (countList.Contains(list[i]))
            {
                sb.AppendFormat("\t\telse if (count == {0} && luaMgr.CheckTypes(types{1}, {2}))\r\n", md.GetParameters().Length, i, 1);
            }
            else
            {
                sb.AppendFormat("\t\telse if (count == {0})\r\n", md.GetParameters().Length);
            }

            sb.AppendLine("\t\t{");            
            rc = ProcessParams(md, 3, true);
            sb.AppendFormat("\t\t\treturn {0};\r\n", rc);
            sb.AppendLine("\t\t}");
        }

        if (type.IsValueType && !hasEmptyCon)
        {
            sb.AppendLine("\t\telse if (count == 0)");
            sb.AppendLine("\t\t{");
            sb.AppendFormat("\t\t\tobj = new {0}();\r\n", className);
            sb.AppendLine("\t\t\tluaMgr.PushResult(obj);");
            sb.AppendLine("\t\t\treturn 1;");
            sb.AppendLine("\t\t}");
        }

        sb.AppendLine("\t\telse");
        sb.AppendLine("\t\t{");
        sb.AppendFormat("\t\t\tLuaDLL.luaL_error(l, \"The best overloaded method match for '{0}.New' has some invalid arguments\");\r\n", className);
        sb.AppendLine("\t\t}");

        sb.AppendLine();        
        sb.AppendLine("\t\treturn 0;");
        sb.AppendLine("\t}");
    }

    static int Compare(MethodBase lhs, MethodBase rhs)
    {
        int c1 = lhs.IsStatic ? 0 : 1;
        int c2 = rhs.IsStatic ? 0 : 1;

        c1 += lhs.GetParameters().Length;
        c2 += rhs.GetParameters().Length;

        if (c1 > c2)
        {
            return 1;
        }
        else if (c1 == c2)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    static bool HasOptionalParam(ParameterInfo[] infos)
    {        
        for (int i = 0; i < infos.Length; i++)
        {
            if (IsParams(infos[i]))
            {
                return true;
            }
        }

        return false;
    }

    static int ProcessParams(MethodBase md, int tab, bool beConstruct)
    {
        ParameterInfo[] paramInfos = md.GetParameters();
        int count = paramInfos.Length;
        string head = string.Empty;

        for (int i = 0; i < tab; i++)
        {
            head += "\t";
        }

        if (!md.IsStatic && !beConstruct)
        {
            sb.AppendFormat("{0}{1} obj = ({1})luaMgr.GetNetObject(1);\r\n", head, className);
        }

        for (int j = 0; j < count; j++)
        {
            ParameterInfo param = paramInfos[j];
            string str = param.ParameterType.ToString();
            str = _C(str);

            string arg = "arg" + j;
            int offset = (md.IsStatic || beConstruct) ? 1 : 2;

            if (param.ParameterType == typeof(bool))
            {
                sb.AppendFormat("{2}bool {0} = luaMgr.GetBoolean({1});\r\n", arg, j + offset, head);
            }
            else if (param.ParameterType == typeof(string))
            {
                sb.AppendFormat("{2}string {0} = luaMgr.GetString({1});\r\n", arg, j + offset, head);
            }
            else if (param.ParameterType.IsPrimitive)
            {
                sb.AppendFormat("{3}{0} {1} = ({0})luaMgr.GetNumber({2});\r\n", str, arg, j + offset, head);
            }
            else if (param.ParameterType == typeof(LuaFunction))
            {
                sb.AppendFormat("{2}LuaFunction {0} = luaMgr.GetLuaFunction({1});\r\n", arg, j + offset, head);
            }
            else if (param.ParameterType.IsArray)
            {
                Type et = param.ParameterType.GetElementType();
                string atstr = _C(et.ToString());
                string fname = "GetArrayObject";
                bool flag = false;
                bool optional = false;        

                if (et == typeof(bool))
                {
                    fname = "GetArrayBool";
                }
                else if (et.IsPrimitive)
                {
                    flag = true;
                    fname = "GetArrayNumber";
                }
                else if (et == typeof(string))
                {
                    optional = IsParams(param);
                    fname = optional ? "GetParamsString" : "GetArrayString";
                }
                else //if (et == typeof(object))
                {
                    flag = true;
                    optional = IsParams(param);
                    fname = optional ? "GetParamsObject" : "GetArrayObject";                    
                }
                
                if (flag)
                {
                    if (optional)
                    {
                        sb.AppendFormat("{5}{0}[] objs{2} = luaMgr.{4}<{0}>({1}, count - {3});\r\n", atstr, j + offset, j, j + offset - 1, fname, head);
                    }
                    else
                    {
                        sb.AppendFormat("{5}{0}[] objs{2} = luaMgr.{4}<{0}>({1});\r\n", atstr, j + offset, j, j + offset - 1, fname, head);
                    }
                }
                else
                {
                    sb.AppendFormat("{5}{0}[] objs{2} = luaMgr.{4}({1});\r\n", atstr, j + offset, j, j + offset - 1, fname, head);                    
                }
            }
            else //if (param.ParameterType == typeof(object))
            {
                sb.AppendFormat("{3}{0} {1} = ({0})luaMgr.GetNetObject({2});\r\n", str, arg, j + offset, head);
            }
        }

        StringBuilder sbArgs = new StringBuilder();
        List<string> refList = new List<string>();

        for (int j = 0; j < count - 1; j++)
        {
            ParameterInfo param = paramInfos[j];

            if (!param.ParameterType.IsArray)
            {
                if (!param.ParameterType.ToString().Contains("&"))
                {
                    sbArgs.Append("arg");
                }
                else
                {
                    if (param.Attributes == ParameterAttributes.Out)
                    {
                        sbArgs.Append("out arg");
                    }
                    else
                    {
                        sbArgs.Append("ref arg");
                    }

                    refList.Add("arg" + j);
                }
            }
            else
            {
                sbArgs.Append("objs");
            }

            sbArgs.Append(j);
            sbArgs.Append(",");
        }

        if (count > 0)
        {
            ParameterInfo param = paramInfos[count - 1];

            if (!param.ParameterType.IsArray)
            {
                if (!param.ParameterType.ToString().Contains("&"))
                {
                    sbArgs.Append("arg");
                }
                else
                {
                    if (param.Attributes == ParameterAttributes.Out)
                    {
                        sbArgs.Append("out arg");
                    }
                    else
                    {
                        sbArgs.Append("ref arg");
                    }

                    refList.Add("arg" + (count - 1));
                }
            }
            else
            {
                sbArgs.Append("objs");
            }

            sbArgs.Append(count - 1);
        }

        if (beConstruct)
        {
            sb.AppendFormat("{2}obj = new {0}({1});\r\n", className, sbArgs.ToString(), head);
            sb.AppendFormat("{0}luaMgr.PushResult(obj);\r\n", head);

            for (int i = 0; i < refList.Count; i++)
            {
                sb.AppendFormat("{1}luaMgr.PushResult({0});\r\n", refList[i], head);
            }
            
            return refList.Count + 1;
        }

        string obj = md.IsStatic ? className : "obj";
        MethodInfo m = md as MethodInfo;

        if (m.ReturnType == typeof(void))
        {
            sb.AppendFormat("{3}{0}.{1}({2});\r\n", obj, md.Name, sbArgs.ToString(), head);

            if (!md.IsStatic && type.IsValueType)
            {
                sb.AppendFormat("{0}luaMgr.SetValueObject(1, obj);\r\n", head);
            }
        }
        else
        {
            string ret = "object";

            if (m.ReturnType.IsArray)
            {
                Type et = m.ReturnType.GetElementType();
                ret = _C(et.ToString());                
                ret += "[]";
            }
            else
            {
                ret = _C(m.ReturnType.ToString());
            }

            if (md.Name.Contains("op_"))
            {
                CallOpFunction(md.Name, tab, ret);
            }
            else
            {
                sb.AppendFormat("{4}{3} o = {0}.{1}({2});\r\n", obj, md.Name, sbArgs.ToString(), ret, head);
            }

            sb.AppendFormat("{0}luaMgr.PushResult(o);\r\n", head);
        }

        for (int i = 0; i < refList.Count; i++)
        {
            sb.AppendFormat("{1}luaMgr.PushResult({0});\r\n", refList[i], head);
        }

        return refList.Count;
    }

    static bool CompareParmsCount(MethodInfo l, MethodInfo r)
    {
        if (l == r)
        {
            return false;
        }

        int c1 = l.IsStatic ? 0 : 1;
        int c2 = r.IsStatic ? 0 : 1;

        c1 += l.GetParameters().Length;
        c2 += r.GetParameters().Length;

        return c1 == c2;
    }

    //decimal 类型扔掉了
    static Dictionary<Type, int> typeSize = new Dictionary<Type, int>()
    {
        {typeof(bool), 1},
        { typeof(char), 2},
        { typeof(byte), 3 },
        { typeof(sbyte), 4 },
        { typeof(ushort),5 },      
        { typeof(short), 6 },        
        { typeof(uint), 7 },
        {typeof(int), 8},        
        {typeof(float), 9},
        { typeof(ulong), 10},
        { typeof(long), 11},                                                  
        { typeof(double), 12 },

    };

    //-1 不存在替换, 1 保留左面， 2 保留右面
    static int CompareMethod(MethodInfo l, MethodInfo r)
    {
        int s = 0;

        if (!CompareParmsCount(l,r))
        {
            return -1;
        }
        else
        {
            ParameterInfo[] lp = l.GetParameters();
            ParameterInfo[] rp = r.GetParameters();

            List<Type> ll = new List<Type>();
            List<Type> lr = new List<Type>();

            if (!l.IsStatic)
            {
                ll.Add(type);
            }

            if (!r.IsStatic)
            {
                lr.Add(type);
            }

            for (int i = 0; i < lp.Length; i++)
            {
                ll.Add(lp[i].ParameterType);
            }

            for (int i = 0; i < rp.Length; i++)
            {
                lr.Add(rp[i].ParameterType);
            }

            for (int i = 0; i < ll.Count; i++)
            {
                if (ll[i].IsPrimitive && lr[i].IsPrimitive && s == 0)
                {
                    s = typeSize[ll[i]] >= typeSize[lr[i]] ? 1 : 2;
                }
                else if (ll[i] != lr[i])
                {
                    return -1;
                }
            }

            if (s == 0 && l.IsStatic)
            {
                s = 2;
            }
        }

        return s;
    }

    static void Push(List<MethodInfo> list, MethodInfo r)
    {
        int index = list.FindIndex((p) => { return p.Name == r.Name && CompareMethod(p, r) >= 0; });

        if (index >= 0)
        {
            if (CompareMethod(list[index], r) == 2)
            {
                list.RemoveAt(index);        
                list.Add(r);
                return;
            }
            else
            {
                return;
            }
        }

        list.Add(r);        
    }

    static bool HasDecimal(ParameterInfo[] pi)
    {
        for (int i = 0; i < pi.Length; i++)
        {
            if (pi[i].ParameterType == typeof(decimal))
            {
                return true;
            }
        }

        return false;
    }

    public static MethodInfo GenOverrideFunc(string name)
    {
        List<MethodInfo> list = new List<MethodInfo>();        

        for (int i = 0; i < methods.Length; i++)
        {
            if (methods[i].Name == name && !methods[i].IsGenericMethod && !HasDecimal(methods[i].GetParameters()))
            {
                Push(list, methods[i]);
            }
        }

        if (list.Count == 1)
        {
            return list[0];
        }

        list.Sort(Compare);

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}(IntPtr l)\r\n", GetFuncName(name));
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tint count = LuaDLL.lua_gettop(l);");
        sb.AppendLine();

        List<MethodInfo> countList = new List<MethodInfo>();

        for (int i = 0; i < list.Count; i++)
        {
            int index = list.FindIndex((p) => { return CompareParmsCount(p, list[i]); });

            if (index >= 0 || (HasOptionalParam(list[i].GetParameters()) && list[i].GetParameters().Length > 1))
            {
                countList.Add(list[i]);                
            }            
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (countList.Contains(list[i]))
            {
                CreateParamTypes(i, list[i].GetParameters(), list[i].IsStatic);
            }
        }                        

        if (countList.Count >= 1)
        {
            sb.AppendLine();
        }

        MethodInfo md = list[0];
        int ret = md.ReturnType == typeof(void) ? 0 : 1;
        int offset = md.IsStatic ? 0 : 1;
        int c1 = md.GetParameters().Length + offset;
        int c2 = list[1].GetParameters().Length + (list[1].IsStatic ? 0 : 1);

        if (HasOptionalParam(md.GetParameters()))
        {
            ParameterInfo[] paramInfos = md.GetParameters();
            ParameterInfo param = paramInfos[paramInfos.Length - 1];
            string str = param.ParameterType.GetElementType().ToString();
            str = _C(str);

            if (paramInfos.Length > 1)
            {
                sb.AppendFormat("\t\tif (luaMgr.CheckTypes(types0, 1) && luaMgr.CheckParamsType(typeof({0}), {1}, count - {2}))\r\n", str, paramInfos.Length + offset, paramInfos.Length + offset - 1);
            }
            else
            {
                sb.AppendFormat("\t\tif (luaMgr.CheckParamsType(typeof({0}), {1}, count - {2}))\r\n", str, paramInfos.Length + offset, paramInfos.Length + offset - 1);
            }
        }
        else
        {
            if (c1 != c2)
            {
                sb.AppendFormat("\t\tif (count == {0})\r\n", md.GetParameters().Length + offset);
            }
            else
            {
                sb.AppendFormat("\t\tif (count == {0} && luaMgr.CheckTypes(types0, {1}))\r\n", md.GetParameters().Length + offset, 1);
            }
        }

        sb.AppendLine("\t\t{");
        int count = ProcessParams(md, 3, false);
        sb.AppendFormat("\t\t\treturn {0};\r\n", ret + count);
        sb.AppendLine("\t\t}");
        //int offset = md.IsStatic ? 1 : 2;

        for (int i = 1; i < list.Count; i++)
        {
            md = list[i];
            offset = md.IsStatic ? 0 : 1;
            ret = md.ReturnType == typeof(void) ? 0 : 1;

            if (!HasOptionalParam(md.GetParameters()))
            {
                if (countList.Contains(list[i]))
                {
                    sb.AppendFormat("\t\telse if (count == {0} && luaMgr.CheckTypes(types{1}, {2}))\r\n", md.GetParameters().Length + offset, i, 1);
                }
                else
                {
                    sb.AppendFormat("\t\telse if (count == {0})\r\n", md.GetParameters().Length + offset);
                }
            }
            else
            {
                ParameterInfo[] paramInfos = md.GetParameters();
                ParameterInfo param = paramInfos[paramInfos.Length - 1];
                string str = param.ParameterType.GetElementType().ToString();
                str = _C(str);

                if (paramInfos.Length > 1)
                {
                    sb.AppendFormat("\t\telse if (luaMgr.CheckTypes(types{2}, 1) && luaMgr.CheckParamsType(typeof({0}), {1}, count - {3}))\r\n", str, paramInfos.Length + offset, i, paramInfos.Length + offset - 1);
                }
                else
                {
                    sb.AppendFormat("\t\telse if (luaMgr.CheckParamsType(typeof({0}), {1}, count - {2}))\r\n", str, paramInfos.Length + offset, paramInfos.Length + offset - 1);
                }
            }

            sb.AppendLine("\t\t{");
            count = ProcessParams(md, 3, false);
            sb.AppendFormat("\t\t\treturn {0};\r\n", ret + count);
            sb.AppendLine("\t\t}");
        }

        sb.AppendLine("\t\telse");
        sb.AppendLine("\t\t{");
        sb.AppendFormat("\t\t\tLuaDLL.luaL_error(l, \"The best overloaded method match for '{0}.{1}' has some invalid arguments\");\r\n", className, name);
        sb.AppendLine("\t\t}");        

        sb.AppendLine();
        sb.AppendLine("\t\treturn 0;");
        sb.AppendLine("\t}");

        return null;
    }

    static string _C(string str)
    {        
        if (str[str.Length - 1] == '&')
        {
            str = str.Remove(str.Length - 1);
            return _C(str);
        }
        else if (str == "System.Single" || str == "Single")
        {            
            return "float";
        }
        else if (str == "System.String" || str == "String")
        {
            return "string";
        }
        else if (str == "System.Int32" || str == "Int32")
        {
            return "int";
        }
        else if (str == "System.Int64" || str == "Int64")
        {
            return "long";
        }
        else if (str == "System.SByte" || str == "SByte")
        {
            return "sbyte";
        }
        else if (str == "System.Byte" || str == "Byte")
        {
            return "byte";
        }
        else if (str == "System.Int16" || str == "Int16")
        {
            return "short";
        }
        else if (str == "System.UInt16" || str == "UInt16")
        {
            return "ushort";
        }
        else if (str == "System.Char" || str == "Char")
        {
            return "char";
        }
        else if (str == "System.UInt32" || str == "UInt32")
        {
            return "uint";
        }
        else if (str == "System.UInt64" || str == "UInt64")
        {
            return "ulong";
        }
        else if (str == "System.Decimal" || str == "Decimal")
        {
            return "decimal";
        }
        else if (str == "System.Double" || str == "Double")
        {
            return "double";
        }
        else if (str == "System.Boolean" || str == "Boolean")
        {
            return "bool";
        }
        else if (str == "System.Object")
        {
            usingList.Add("System");
            ambig |= ObjAmbig.NetObj;
            return "object";
        }
        else if (str.Contains("+"))
        {
            return str.Replace('+', '.');
        }
        else if (str.Contains("`1["))
        {
            //处理泛型
            //System.Collections.Generic.List`1[System.Int32]
            usingList.Add("System.Collections.Generic");
            int pos2 = str.IndexOf("`1");
            string ss = str.Substring(0, pos2);
            int pos1 = ss.LastIndexOf('.');
            string s1 = str.Substring(pos1 + 1, pos2 - pos1 - 1);
            pos1 = str.LastIndexOf('[');
            pos2 = str.IndexOf("]");
            string s2 = str.Substring(pos1 + 1, pos2 - pos1 - 1);
            s2 = _C(s2);
            string s3 = string.Format("{0}<{1}>", s1, s2);
            return s3;
        }
        else if (str.Length > 12 && str.Substring(0, 12) == "UnityEngine.")
        {
            usingList.Add("UnityEngine");
            str = str.Remove(0, 12);

            if ((ambig & ObjAmbig.U3dObj) == 0 && str == "Object")
            {
                ambig |= ObjAmbig.U3dObj;
            }

            return _C(str);
        }
        else if (str.Length > 7 && str.Substring(0, 7) == "System.")
        {
            int pos1 = str.LastIndexOf('.');
            usingList.Add(str.Substring(0, pos1));
            str = str.Remove(0, pos1+1);
            return _C(str);
        }        

        return str;
    }

    static void CreateParamTypes(int pos, ParameterInfo[] p, bool beAddSelf)
    {
        List<Type> a = new List<Type>();

        if (!beAddSelf)
        {
            a.Add(type);
        }

        for (int i = 0; i < p.Length; i++)
        {
            if (!IsParams(p[i]))
            {
                a.Add(p[i].ParameterType);
            }
        }

        if (a.Count == 0)
        {
            return;
        }
        else if (a.Count == 1)
        {
            sb.AppendFormat("\t\tType[] types{0} = {{typeof({1})}};\r\n", pos, _C(a[0].ToString()));
        }
        else if (a.Count == 2)
        {
            sb.AppendFormat("\t\tType[] types{0} = {{typeof({1}), typeof({2})}};\r\n", pos, _C(a[0].ToString()), _C(a[1].ToString()));
        }
        else if (a.Count == 3)
        {
            sb.AppendFormat("\t\tType[] types{0} = {{typeof({1}), typeof({2}), typeof({3})}};\r\n", pos, _C(a[0].ToString()), _C(a[1].ToString()), _C(a[2].ToString()));
        }
        else if (a.Count == 4)
        {
            sb.AppendFormat("\t\tType[] types{0} = {{typeof({1}), typeof({2}), typeof({3}), typeof({4})}};\r\n", pos, _C(a[0].ToString()), _C(a[1].ToString()), _C(a[2].ToString()), _C(a[3].ToString()));
        }
        else if (a.Count == 5)
        {
            sb.AppendFormat("\t\tType[] types{0} = {{typeof({1}), typeof({2}), typeof({3}), typeof({4}), typeof({5})}};\r\n", pos, _C(a[0].ToString()), _C(a[1].ToString()), _C(a[2].ToString()), _C(a[3].ToString()), _C(a[4].ToString()));
        }
        else if (a.Count == 6)
        {
            sb.AppendFormat("\t\tType[] types{0} = {{typeof({1}), typeof({2}), typeof({3}), typeof({4}), typeof({5}), typeof({6})}};\r\n", pos, _C(a[0].ToString()), _C(a[1].ToString()), _C(a[2].ToString()), _C(a[3].ToString()), _C(a[4].ToString()), _C(a[5].ToString()));
        }
        else
        {
            Debugger.LogError("CreateParamTypes i am not defined it: " + a.Count);
        }
    }

    static void SetField(string s1, string s2, Type t)
    {
        if (t == typeof(bool))
        {
            sb.AppendFormat("\t\t{0}.{1} = (bool)luaMgr.GetBool(3);\r\n", s1, s2);
        }
        else if (t == typeof(string))
        {
            sb.AppendFormat("\t\t{0}.{1} = (string)luaMgr.GetString(3);\r\n", s1, s2);
        }
        else if (t == typeof(LuaFunction))
        {
            sb.AppendFormat("\t\t{0}.{1} = (LuaFunction)luaMgr.GetLuaFunction(3);\r\n", s1, s2);
        }
        else if (t.IsPrimitive)
        {
            sb.AppendFormat("\t\t{0}.{1} = ({2})luaMgr.GetNumber(3);\r\n", s1, s2, _C(t.Name));
        }
    }

    static void GenIndexFunc()
    {
        for(int i = 0; i < fields.Length; i++)
        {            
            sb.AppendFormat("\r\n\tstatic bool get_{0}(IntPtr l)\r\n", fields[i].Name);
            sb.AppendLine("\t{");

            if (fields[i].IsStatic)
            {
                sb.AppendFormat("\t\tluaMgr.PushResult({0}.{1});\r\n", className, fields[i].Name);
            }
            else
            {
                sb.AppendFormat("\t\tobject o = luaMgr.GetLuaObject(1);\r\n");
                sb.AppendLine("\t\tif (o == null) return false;");                
                sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", className);                
                sb.AppendFormat("\t\tluaMgr.PushResult({0}.{1});\r\n", "obj", fields[i].Name);                
            }

            sb.AppendLine("\t\treturn true;");
            sb.AppendLine("\t}");
        }

        for (int i = 0; i < props.Length; i++)
        {
            if (!props[i].CanRead)
            {
                continue;
            }

            bool isStatic = true;
            int index = propList.IndexOf(props[i]);

            if (index >= 0)
            {
                isStatic = false;
            }
            
            sb.AppendFormat("\r\n\tstatic bool get_{0}(IntPtr l)\r\n", props[i].Name);
            sb.AppendLine("\t{");

            if (isStatic)
            {
                sb.AppendFormat("\t\tluaMgr.PushResult({0}.{1});\r\n", className, props[i].Name);
            }
            else
            {
                sb.AppendFormat("\t\tobject o = luaMgr.GetLuaObject(1);\r\n");
                sb.AppendLine("\t\tif (o == null) return false;");
                sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", className);
                sb.AppendFormat("\t\tluaMgr.PushResult({0}.{1});\r\n", "obj", props[i].Name); 
            }

            sb.AppendLine("\t\treturn true;");
            sb.AppendLine("\t}");
        }
        
        sb.AppendLine("\r\n\tpublic static bool TryLuaIndex(IntPtr l)");
        sb.AppendLine("\t{");        

        if (getItem != null)
        {
            sb.AppendLine("\t\tLuaTypes luaType = LuaDLL.lua_type(l, 2);");
            sb.AppendLine();
            sb.AppendLine("\t\tif (luaType == LuaTypes.LUA_TNUMBER)");
            sb.AppendLine("\t\t{");            
            sb.AppendLine("\t\t\tobject o = luaMgr.GetLuaObject(1);");
            sb.AppendLine("\t\t\tif (o == null) return false;");
            sb.AppendLine("\t\t\tint pos = (int)luaMgr.GetNumber(2);");
            sb.AppendFormat("\t\t\t{0} obj = ({0})o;\r\n", className);
            sb.AppendLine("\t\t\tluaMgr.PushResult(obj[pos]);");
            sb.AppendLine("\t\t\treturn true;");
            sb.AppendLine("\t\t}");
            sb.AppendLine();
        }

        sb.AppendLine("\t\tstring str = luaMgr.GetString(2);\r\n");
        sb.AppendLine("\t\tif (luaMgr.Index(reference, str, fields))");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\treturn true;");
        sb.AppendLine("\t\t}\r\n");

        if (baseClassName != null)
        {
            sb.AppendFormat("\t\treturn {0}Wrap.TryLuaIndex(l);\r\n", baseClassName);
        }
        else
        {
            sb.AppendLine("\t\treturn false;");
        }

        sb.AppendLine("\t}");

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendLine("\tstatic int Lua_Index(IntPtr l)");
        sb.AppendLine("\t{");        
        sb.AppendLine("\t\tif (TryLuaIndex(l))");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\treturn 1;");
        sb.AppendLine("\t\t}");
        sb.AppendLine();
        sb.AppendLine("\t\tstring str = luaMgr.GetString(2);");
        sb.AppendFormat("\t\tLuaDLL.luaL_error(l, string.Format(\"'{0}' does not contain a definition for '{{0}}'\", str));\r\n", className);        
        sb.AppendLine("\t\treturn 0;");
        sb.AppendLine("\t}");  
    }

    static void GenNewIndexFunc()
    {
        for (int i = 0; i < fields.Length; i++)
        {
            if (fields[i].IsLiteral || fields[i].IsInitOnly || fields[i].IsPrivate)
            {
                continue;
            }
            
            sb.AppendFormat("\r\n\tstatic bool set_{0}(IntPtr l)\r\n", fields[i].Name);
            sb.AppendLine("\t{");
            string o = fields[i].IsStatic ? className : "obj";                        
            string t = _C(fields[i].FieldType.Name);
            t = t.Replace('+', '.');

            if (!fields[i].IsStatic)
            {                                
                sb.AppendFormat("\t\tobject o = luaMgr.GetLuaObject(1);\r\n");
                sb.AppendLine("\t\tif (o == null) return false;");
                sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", className);                
            }

            NewIndexSetValue(fields[i].FieldType, o, fields[i].Name);

            if (!fields[i].IsStatic && type.IsValueType)
            {
                sb.AppendLine("\t\tluaMgr.SetValueObject(1, obj);");
            }

            sb.AppendLine("\t\treturn true;");
            sb.AppendLine("\t}");
        }

        for (int i = 0; i < props.Length; i++)
        {
            if (!props[i].CanWrite || !props[i].GetSetMethod(true).IsPublic)
            {
                continue;
            }

            bool isStatic = true;
            int index = propList.IndexOf(props[i]);

            if (index >= 0)
            {
                isStatic = false;
            }
            
            sb.AppendFormat("\r\n\tstatic bool set_{0}(IntPtr l)\r\n", props[i].Name);
            sb.AppendLine("\t{");
            string o = isStatic ? className : "obj";
            string t = _C(props[i].PropertyType.Name);
            t = t.Replace('+', '.');

            if (!isStatic)
            {
                sb.AppendFormat("\t\tobject o = luaMgr.GetLuaObject(1);\r\n");
                sb.AppendLine("\t\tif (o == null) return false;");
                sb.AppendFormat("\t\t{0} obj = ({0})o;\r\n", className);     
            }

            NewIndexSetValue(props[i].PropertyType, o, props[i].Name);

            if (!isStatic && type.IsValueType)
            {
                sb.AppendLine("\t\tluaMgr.SetValueObject(1, obj);");
            }

            sb.AppendLine("\t\treturn true;");
            sb.AppendLine("\t}");
        }
        
        sb.AppendLine("\r\n\tpublic static bool TryLuaNewIndex(IntPtr l)");
        sb.AppendLine("\t{");        

        if (setItem != null)
        {
            ParameterInfo[] pi = setItem.GetParameters();
            Type rt = pi[1].ParameterType;
            string ret = _C(rt.ToString());

            sb.AppendLine("\t\tLuaTypes luaType = LuaDLL.lua_type(l, 2);");
            sb.AppendLine();
            sb.AppendLine("\t\tif (luaType == LuaTypes.LUA_TNUMBER)");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tobject o = luaMgr.GetLuaObject(1);");
            sb.AppendLine("\t\t\tif (o == null) return false;");
            sb.AppendLine("\t\t\tint pos = (int)luaMgr.GetNumber(2);");
            sb.AppendFormat("\t\t\t{0} val = ({0})luaMgr.GetNumber(3);\r\n", ret);            
            sb.AppendFormat("\t\t\t{0} obj = ({0})o;\r\n", className);
            sb.AppendLine("\t\t\tobj[pos] = val;");

            if (type.IsValueType)
            {
                sb.AppendLine("\t\t\tluaMgr.SetValueObject(1, obj);");
            }

            sb.AppendLine("\t\t\treturn true;");
            sb.AppendLine("\t\t}");
            sb.AppendLine();
        }

        sb.AppendLine("\t\tstring str = luaMgr.GetString(2);\r\n");
        sb.AppendLine("\t\tif (luaMgr.NewIndex(reference, str, fields))");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\treturn true;");
        sb.AppendLine("\t\t}\r\n");

        if (baseClassName != null)
        {
            sb.AppendFormat("\t\treturn {0}Wrap.TryLuaNewIndex(l);\r\n", baseClassName);
        }
        else
        {
            sb.AppendLine("\t\treturn false;");
        }
        sb.AppendLine("\t}");

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendLine("\tstatic int Lua_NewIndex(IntPtr l)");
        sb.AppendLine("\t{");       
        sb.AppendLine("\t\tif (TryLuaNewIndex(l))");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\treturn 0;");
        sb.AppendLine("\t\t}");
        sb.AppendLine();
        sb.AppendLine("\t\tstring str = luaMgr.GetString(2);");        
        sb.AppendFormat("\t\tLuaDLL.luaL_error(l, string.Format(\"'{0}' does not contain a definition for '{{0}}'\", str));\r\n", className);        
        sb.AppendLine("\t\treturn 0;");
        sb.AppendLine("\t}");  
    }    
   

    static void NewIndexSetValue(Type t, string o, string name)
    {
        if (t == typeof(bool))
        {
            sb.AppendFormat("\t\t{0}.{1} = luaMgr.GetBoolean(3);\r\n", o, name);
        }
        else if (t == typeof(string))
        {            
            sb.AppendFormat("\t\t{0}.{1} = luaMgr.GetString(3);\r\n", o, name);
        }
        else if (t.IsPrimitive || t.IsEnum)
        {            
            sb.AppendFormat("\t\t{0}.{1} = ({2})luaMgr.GetNumber(3);\r\n", o, name, _C(t.ToString()));
        }
        else if (t == typeof(LuaFunction))
        {            
            sb.AppendFormat("\t\t{0}.{1} = luaMgr.GetLuaFunction(3);\r\n", o, name);
        }
        else if (typeof(UnityEngine.Object).IsAssignableFrom(t))
        {
            sb.AppendFormat("\t\t{0}.{1} = ({2})luaMgr.GetNetObject(3);\r\n", o, name, _C(t.ToString()));
        }
        else if (typeof(object).IsAssignableFrom(t))
        {
            sb.AppendFormat("\t\t{0}.{1} = ({2})luaMgr.GetNetObject(3);\r\n", o, name, _C(t.ToString()));
        }
        else
        {
            Debugger.LogError("not defined type {0}", t);
        }
    }

    static void GenToStringFunc()
    {
        int index = Array.FindIndex<MethodInfo>(methods, (p) => { return p.Name == "ToString"; });
        if (index < 0 || isStaticClass) return;

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendLine("\tstatic int Lua_ToString(IntPtr l)");
        sb.AppendLine("\t{");
        sb.AppendFormat("\t\t{0} obj = ({0})luaMgr.GetNetObject(1);\r\n", className);
        sb.AppendFormat("\t\tluaMgr.PushResult(obj.ToString());\r\n");        

        sb.AppendLine("\t\treturn 1;");
        sb.AppendLine("\t}");
    }

    static bool IsNeedOp(string name)
    {
        if (name == "op_Addition")
        {
            op |= MetaOp.Add;
        }
        else if (name == "op_Subtraction")
        {
            op |= MetaOp.Sub;
        }
        else if (name == "op_Equality")
        {
            op |= MetaOp.Eq;
        }
        else if (name == "op_Multiply")
        {
            op |= MetaOp.Mul;
        }
        else if (name == "op_Division")
        {
            op |= MetaOp.Div;
        }
        else if (name == "op_UnaryNegation")
        {
            op |= MetaOp.Neg;
        }
        else
        {
            return false;
        }
        

        return true;
    }

    static void CallOpFunction(string name, int count, string ret)
    {
        string head = string.Empty;

        for (int i = 0; i < count; i++)
        {
            head += "\t";
        }

        if (name == "op_Addition")
        {
            sb.AppendFormat("{0}{1} o = arg0 + arg1;\r\n", head, ret);
        }
        else if (name == "op_Subtraction")
        {
            sb.AppendFormat("{0}{1} o = arg0 - arg1;\r\n", head, ret);            
        }
        else if (name == "op_Equality")
        {
            sb.AppendFormat("{0}bool o = arg0 == arg1;\r\n", head);
        }
        else if (name == "op_Multiply")
        {
            sb.AppendFormat("{0}{1} o = arg0 * arg1;\r\n", head, ret);
        }
        else if (name == "op_Division")
        {
            sb.AppendFormat("{0}{1} o = arg0 / arg1;\r\n", head, ret);            
        }
        else if (name == "op_UnaryNegation")
        {
            sb.AppendFormat("{0}{1} o = -arg0;\r\n", head, ret);
        }
    }

    static string GetFuncName(string name)
    {
        if (name == "op_Addition")
        {
            return "Lua_Add";
        }
        else if (name == "op_Subtraction")
        {
            return "Lua_Sub";
        }
        else if (name == "op_Equality")
        {
            return "Lua_Eq";
        }
        else if (name == "op_Multiply")
        {
            return "Lua_Mul";
        }
        else if (name == "op_Division")
        {
            return "Lua_Div";
        }
        else if (name == "op_UnaryNegation")
        {
            return "Lua_Neg";
        }

        return name;
    }
}
