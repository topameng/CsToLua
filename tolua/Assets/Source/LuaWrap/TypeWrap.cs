using System;
using System.Reflection;
using System.Globalization;
using UnityEngine;
using LuaInterface;

public class TypeWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetType", GetType),
		new LuaMethod("GetTypeArray", GetTypeArray),
		new LuaMethod("GetTypeCode", GetTypeCode),
		new LuaMethod("GetTypeFromCLSID", GetTypeFromCLSID),
		new LuaMethod("GetTypeFromHandle", GetTypeFromHandle),
		new LuaMethod("GetTypeFromProgID", GetTypeFromProgID),
		new LuaMethod("GetTypeHandle", GetTypeHandle),
		new LuaMethod("IsSubclassOf", IsSubclassOf),
		new LuaMethod("FindInterfaces", FindInterfaces),
		new LuaMethod("GetInterface", GetInterface),
		new LuaMethod("GetInterfaceMap", GetInterfaceMap),
		new LuaMethod("GetInterfaces", GetInterfaces),
		new LuaMethod("IsAssignableFrom", IsAssignableFrom),
		new LuaMethod("IsInstanceOfType", IsInstanceOfType),
		new LuaMethod("GetArrayRank", GetArrayRank),
		new LuaMethod("GetElementType", GetElementType),
		new LuaMethod("GetEvent", GetEvent),
		new LuaMethod("GetEvents", GetEvents),
		new LuaMethod("GetField", GetField),
		new LuaMethod("GetFields", GetFields),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetMember", GetMember),
		new LuaMethod("GetMembers", GetMembers),
		new LuaMethod("GetMethod", GetMethod),
		new LuaMethod("GetMethods", GetMethods),
		new LuaMethod("GetNestedType", GetNestedType),
		new LuaMethod("GetNestedTypes", GetNestedTypes),
		new LuaMethod("GetProperties", GetProperties),
		new LuaMethod("GetProperty", GetProperty),
		new LuaMethod("GetConstructor", GetConstructor),
		new LuaMethod("GetConstructors", GetConstructors),
		new LuaMethod("GetDefaultMembers", GetDefaultMembers),
		new LuaMethod("FindMembers", FindMembers),
		new LuaMethod("InvokeMember", InvokeMember),
		new LuaMethod("ToString", ToString),
		new LuaMethod("GetGenericArguments", GetGenericArguments),
		new LuaMethod("GetGenericTypeDefinition", GetGenericTypeDefinition),
		new LuaMethod("MakeGenericType", MakeGenericType),
		new LuaMethod("GetGenericParameterConstraints", GetGenericParameterConstraints),
		new LuaMethod("MakeArrayType", MakeArrayType),
		new LuaMethod("MakeByRefType", MakeByRefType),
		new LuaMethod("MakePointerType", MakePointerType),
		new LuaMethod("ReflectionOnlyGetType", ReflectionOnlyGetType),
		new LuaMethod("IsDefined", IsDefined),
		new LuaMethod("GetCustomAttributes", GetCustomAttributes),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Delimiter", get_Delimiter, null),
		new LuaField("EmptyTypes", get_EmptyTypes, null),
		new LuaField("FilterAttribute", get_FilterAttribute, null),
		new LuaField("FilterName", get_FilterName, null),
		new LuaField("FilterNameIgnoreCase", get_FilterNameIgnoreCase, null),
		new LuaField("Missing", get_Missing, null),
		new LuaField("Assembly", get_Assembly, null),
		new LuaField("AssemblyQualifiedName", get_AssemblyQualifiedName, null),
		new LuaField("Attributes", get_Attributes, null),
		new LuaField("BaseType", get_BaseType, null),
		new LuaField("DeclaringType", get_DeclaringType, null),
		new LuaField("DefaultBinder", get_DefaultBinder, null),
		new LuaField("FullName", get_FullName, null),
		new LuaField("GUID", get_GUID, null),
		new LuaField("HasElementType", get_HasElementType, null),
		new LuaField("IsAbstract", get_IsAbstract, null),
		new LuaField("IsAnsiClass", get_IsAnsiClass, null),
		new LuaField("IsArray", get_IsArray, null),
		new LuaField("IsAutoClass", get_IsAutoClass, null),
		new LuaField("IsAutoLayout", get_IsAutoLayout, null),
		new LuaField("IsByRef", get_IsByRef, null),
		new LuaField("IsClass", get_IsClass, null),
		new LuaField("IsCOMObject", get_IsCOMObject, null),
		new LuaField("IsContextful", get_IsContextful, null),
		new LuaField("IsEnum", get_IsEnum, null),
		new LuaField("IsExplicitLayout", get_IsExplicitLayout, null),
		new LuaField("IsImport", get_IsImport, null),
		new LuaField("IsInterface", get_IsInterface, null),
		new LuaField("IsLayoutSequential", get_IsLayoutSequential, null),
		new LuaField("IsMarshalByRef", get_IsMarshalByRef, null),
		new LuaField("IsNestedAssembly", get_IsNestedAssembly, null),
		new LuaField("IsNestedFamANDAssem", get_IsNestedFamANDAssem, null),
		new LuaField("IsNestedFamily", get_IsNestedFamily, null),
		new LuaField("IsNestedFamORAssem", get_IsNestedFamORAssem, null),
		new LuaField("IsNestedPrivate", get_IsNestedPrivate, null),
		new LuaField("IsNestedPublic", get_IsNestedPublic, null),
		new LuaField("IsNotPublic", get_IsNotPublic, null),
		new LuaField("IsPointer", get_IsPointer, null),
		new LuaField("IsPrimitive", get_IsPrimitive, null),
		new LuaField("IsPublic", get_IsPublic, null),
		new LuaField("IsSealed", get_IsSealed, null),
		new LuaField("IsSerializable", get_IsSerializable, null),
		new LuaField("IsSpecialName", get_IsSpecialName, null),
		new LuaField("IsUnicodeClass", get_IsUnicodeClass, null),
		new LuaField("IsValueType", get_IsValueType, null),
		new LuaField("MemberType", get_MemberType, null),
		new LuaField("Module", get_Module, null),
		new LuaField("Namespace", get_Namespace, null),
		new LuaField("ReflectedType", get_ReflectedType, null),
		new LuaField("TypeHandle", get_TypeHandle, null),
		new LuaField("TypeInitializer", get_TypeInitializer, null),
		new LuaField("UnderlyingSystemType", get_UnderlyingSystemType, null),
		new LuaField("ContainsGenericParameters", get_ContainsGenericParameters, null),
		new LuaField("IsGenericTypeDefinition", get_IsGenericTypeDefinition, null),
		new LuaField("IsGenericType", get_IsGenericType, null),
		new LuaField("IsGenericParameter", get_IsGenericParameter, null),
		new LuaField("IsNested", get_IsNested, null),
		new LuaField("IsVisible", get_IsVisible, null),
		new LuaField("GenericParameterPosition", get_GenericParameterPosition, null),
		new LuaField("GenericParameterAttributes", get_GenericParameterAttributes, null),
		new LuaField("DeclaringMethod", get_DeclaringMethod, null),
		new LuaField("StructLayoutAttribute", get_StructLayoutAttribute, null),
		new LuaField("Name", get_Name, null),
		new LuaField("MetadataToken", get_MetadataToken, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr l)
	{
		LuaDLL.luaL_error(l, "Type class does not have a constructor function");
		return 0;
	}

	public void Register()
	{
		LuaMethod[] metas = new LuaMethod[]
		{
			new LuaMethod("__index", Lua_Index),
			new LuaMethod("__newindex", Lua_NewIndex),
			new LuaMethod("__tostring", Lua_ToString),
		};

		luaMgr = LuaScriptMgr.Instance;
		reference = luaMgr.RegisterLib("Type", regs);
		luaMgr.CreateMetaTable("Type", metas, typeof(Type));
		luaMgr.RegisterField(typeof(Type), fields);
	}

	static bool get_Delimiter(IntPtr l)
	{
		luaMgr.PushResult(Type.Delimiter);
		return true;
	}

	static bool get_EmptyTypes(IntPtr l)
	{
		luaMgr.PushResult(Type.EmptyTypes);
		return true;
	}

	static bool get_FilterAttribute(IntPtr l)
	{
		luaMgr.PushResult(Type.FilterAttribute);
		return true;
	}

	static bool get_FilterName(IntPtr l)
	{
		luaMgr.PushResult(Type.FilterName);
		return true;
	}

	static bool get_FilterNameIgnoreCase(IntPtr l)
	{
		luaMgr.PushResult(Type.FilterNameIgnoreCase);
		return true;
	}

	static bool get_Missing(IntPtr l)
	{
		luaMgr.PushResult(Type.Missing);
		return true;
	}

	static bool get_Assembly(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.Assembly);
		return true;
	}

	static bool get_AssemblyQualifiedName(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.AssemblyQualifiedName);
		return true;
	}

	static bool get_Attributes(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.Attributes);
		return true;
	}

	static bool get_BaseType(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.BaseType);
		return true;
	}

	static bool get_DeclaringType(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.DeclaringType);
		return true;
	}

	static bool get_DefaultBinder(IntPtr l)
	{
		luaMgr.PushResult(Type.DefaultBinder);
		return true;
	}

	static bool get_FullName(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.FullName);
		return true;
	}

	static bool get_GUID(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.GUID);
		return true;
	}

	static bool get_HasElementType(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.HasElementType);
		return true;
	}

	static bool get_IsAbstract(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsAbstract);
		return true;
	}

	static bool get_IsAnsiClass(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsAnsiClass);
		return true;
	}

	static bool get_IsArray(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsArray);
		return true;
	}

	static bool get_IsAutoClass(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsAutoClass);
		return true;
	}

	static bool get_IsAutoLayout(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsAutoLayout);
		return true;
	}

	static bool get_IsByRef(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsByRef);
		return true;
	}

	static bool get_IsClass(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsClass);
		return true;
	}

	static bool get_IsCOMObject(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsCOMObject);
		return true;
	}

	static bool get_IsContextful(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsContextful);
		return true;
	}

	static bool get_IsEnum(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsEnum);
		return true;
	}

	static bool get_IsExplicitLayout(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsExplicitLayout);
		return true;
	}

	static bool get_IsImport(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsImport);
		return true;
	}

	static bool get_IsInterface(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsInterface);
		return true;
	}

	static bool get_IsLayoutSequential(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsLayoutSequential);
		return true;
	}

	static bool get_IsMarshalByRef(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsMarshalByRef);
		return true;
	}

	static bool get_IsNestedAssembly(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsNestedAssembly);
		return true;
	}

	static bool get_IsNestedFamANDAssem(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsNestedFamANDAssem);
		return true;
	}

	static bool get_IsNestedFamily(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsNestedFamily);
		return true;
	}

	static bool get_IsNestedFamORAssem(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsNestedFamORAssem);
		return true;
	}

	static bool get_IsNestedPrivate(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsNestedPrivate);
		return true;
	}

	static bool get_IsNestedPublic(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsNestedPublic);
		return true;
	}

	static bool get_IsNotPublic(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsNotPublic);
		return true;
	}

	static bool get_IsPointer(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsPointer);
		return true;
	}

	static bool get_IsPrimitive(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsPrimitive);
		return true;
	}

	static bool get_IsPublic(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsPublic);
		return true;
	}

	static bool get_IsSealed(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsSealed);
		return true;
	}

	static bool get_IsSerializable(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsSerializable);
		return true;
	}

	static bool get_IsSpecialName(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsSpecialName);
		return true;
	}

	static bool get_IsUnicodeClass(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsUnicodeClass);
		return true;
	}

	static bool get_IsValueType(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsValueType);
		return true;
	}

	static bool get_MemberType(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.MemberType);
		return true;
	}

	static bool get_Module(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.Module);
		return true;
	}

	static bool get_Namespace(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.Namespace);
		return true;
	}

	static bool get_ReflectedType(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.ReflectedType);
		return true;
	}

	static bool get_TypeHandle(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.TypeHandle);
		return true;
	}

	static bool get_TypeInitializer(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.TypeInitializer);
		return true;
	}

	static bool get_UnderlyingSystemType(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.UnderlyingSystemType);
		return true;
	}

	static bool get_ContainsGenericParameters(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.ContainsGenericParameters);
		return true;
	}

	static bool get_IsGenericTypeDefinition(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsGenericTypeDefinition);
		return true;
	}

	static bool get_IsGenericType(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsGenericType);
		return true;
	}

	static bool get_IsGenericParameter(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsGenericParameter);
		return true;
	}

	static bool get_IsNested(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsNested);
		return true;
	}

	static bool get_IsVisible(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.IsVisible);
		return true;
	}

	static bool get_GenericParameterPosition(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.GenericParameterPosition);
		return true;
	}

	static bool get_GenericParameterAttributes(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.GenericParameterAttributes);
		return true;
	}

	static bool get_DeclaringMethod(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.DeclaringMethod);
		return true;
	}

	static bool get_StructLayoutAttribute(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.StructLayoutAttribute);
		return true;
	}

	static bool get_Name(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.Name);
		return true;
	}

	static bool get_MetadataToken(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Type obj = (Type)o;
		luaMgr.PushResult(obj.MetadataToken);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return false;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Type' does not contain a definition for '{0}'", str));
		return 0;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return false;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Type' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr l)
	{
		Type obj = (Type)luaMgr.GetNetObject(1);
		luaMgr.PushResult(obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(Type), typeof(Type)};
		Type[] types1 = {typeof(Type), typeof(object)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			Type arg0 = (Type)luaMgr.GetNetObject(2);
			bool o = obj.Equals(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			object arg0 = (object)luaMgr.GetNetObject(2);
			bool o = obj.Equals(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.Equals' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(Type)};
		Type[] types1 = {typeof(string)};

		if (count == 1 && luaMgr.CheckTypes(types0, 1))
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			Type o = obj.GetType();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 1 && luaMgr.CheckTypes(types1, 1))
		{
			string arg0 = luaMgr.GetString(1);
			Type o = Type.GetType(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			string arg0 = luaMgr.GetString(1);
			bool arg1 = luaMgr.GetBoolean(2);
			Type o = Type.GetType(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			string arg0 = luaMgr.GetString(1);
			bool arg1 = luaMgr.GetBoolean(2);
			bool arg2 = luaMgr.GetBoolean(3);
			Type o = Type.GetType(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetType' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeArray(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		object[] objs0 = luaMgr.GetArrayObject<object>(1);
		Type[] o = Type.GetTypeArray(objs0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeCode(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type arg0 = (Type)luaMgr.GetNetObject(1);
		TypeCode o = Type.GetTypeCode(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeFromCLSID(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(Guid), typeof(string)};
		Type[] types2 = {typeof(Guid), typeof(bool)};

		if (count == 1)
		{
			Guid arg0 = (Guid)luaMgr.GetNetObject(1);
			Type o = Type.GetTypeFromCLSID(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			Guid arg0 = (Guid)luaMgr.GetNetObject(1);
			string arg1 = luaMgr.GetString(2);
			Type o = Type.GetTypeFromCLSID(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types2, 1))
		{
			Guid arg0 = (Guid)luaMgr.GetNetObject(1);
			bool arg1 = luaMgr.GetBoolean(2);
			Type o = Type.GetTypeFromCLSID(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Guid arg0 = (Guid)luaMgr.GetNetObject(1);
			string arg1 = luaMgr.GetString(2);
			bool arg2 = luaMgr.GetBoolean(3);
			Type o = Type.GetTypeFromCLSID(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetTypeFromCLSID' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeFromHandle(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		RuntimeTypeHandle arg0 = (RuntimeTypeHandle)luaMgr.GetNetObject(1);
		Type o = Type.GetTypeFromHandle(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeFromProgID(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(string), typeof(string)};
		Type[] types2 = {typeof(string), typeof(bool)};

		if (count == 1)
		{
			string arg0 = luaMgr.GetString(1);
			Type o = Type.GetTypeFromProgID(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			string arg0 = luaMgr.GetString(1);
			string arg1 = luaMgr.GetString(2);
			Type o = Type.GetTypeFromProgID(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types2, 1))
		{
			string arg0 = luaMgr.GetString(1);
			bool arg1 = luaMgr.GetBoolean(2);
			Type o = Type.GetTypeFromProgID(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			string arg0 = luaMgr.GetString(1);
			string arg1 = luaMgr.GetString(2);
			bool arg2 = luaMgr.GetBoolean(3);
			Type o = Type.GetTypeFromProgID(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetTypeFromProgID' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeHandle(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		object arg0 = (object)luaMgr.GetNetObject(1);
		RuntimeTypeHandle o = Type.GetTypeHandle(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsSubclassOf(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type arg0 = (Type)luaMgr.GetNetObject(2);
		bool o = obj.IsSubclassOf(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindInterfaces(IntPtr l)
	{
		luaMgr.CheckArgsCount(3);
		Type obj = (Type)luaMgr.GetNetObject(1);
		TypeFilter arg0 = (TypeFilter)luaMgr.GetNetObject(2);
		object arg1 = (object)luaMgr.GetNetObject(3);
		Type[] o = obj.FindInterfaces(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInterface(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Type o = obj.GetInterface(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			bool arg1 = luaMgr.GetBoolean(3);
			Type o = obj.GetInterface(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetInterface' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInterfaceMap(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type arg0 = (Type)luaMgr.GetNetObject(2);
		InterfaceMapping o = obj.GetInterfaceMap(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInterfaces(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type[] o = obj.GetInterfaces();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsAssignableFrom(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type arg0 = (Type)luaMgr.GetNetObject(2);
		bool o = obj.IsAssignableFrom(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInstanceOfType(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Type obj = (Type)luaMgr.GetNetObject(1);
		object arg0 = (object)luaMgr.GetNetObject(2);
		bool o = obj.IsInstanceOfType(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetArrayRank(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		int o = obj.GetArrayRank();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetElementType(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type o = obj.GetElementType();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEvent(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			EventInfo o = obj.GetEvent(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			EventInfo o = obj.GetEvent(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetEvent' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEvents(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			EventInfo[] o = obj.GetEvents();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			EventInfo[] o = obj.GetEvents(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetEvents' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetField(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			FieldInfo o = obj.GetField(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			FieldInfo o = obj.GetField(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetField' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFields(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			FieldInfo[] o = obj.GetFields();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			FieldInfo[] o = obj.GetFields(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetFields' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		int o = obj.GetHashCode();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMember(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			MemberInfo[] o = obj.GetMember(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			MemberInfo[] o = obj.GetMember(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 4)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			MemberTypes arg1 = (MemberTypes)luaMgr.GetNetObject(3);
			BindingFlags arg2 = (BindingFlags)luaMgr.GetNetObject(4);
			MemberInfo[] o = obj.GetMember(arg0,arg1,arg2);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetMember' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMembers(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			MemberInfo[] o = obj.GetMembers();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			MemberInfo[] o = obj.GetMembers(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetMembers' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMethod(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(Type), typeof(string), typeof(Type[])};
		Type[] types2 = {typeof(Type), typeof(string), typeof(BindingFlags)};

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			MethodInfo o = obj.GetMethod(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3 && luaMgr.CheckTypes(types1, 1))
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Type[] objs1 = luaMgr.GetArrayObject<Type>(3);
			MethodInfo o = obj.GetMethod(arg0,objs1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3 && luaMgr.CheckTypes(types2, 1))
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			MethodInfo o = obj.GetMethod(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 4)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Type[] objs1 = luaMgr.GetArrayObject<Type>(3);
			ParameterModifier[] objs2 = luaMgr.GetArrayObject<ParameterModifier>(4);
			MethodInfo o = obj.GetMethod(arg0,objs1,objs2);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 6)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			Binder arg2 = (Binder)luaMgr.GetNetObject(4);
			Type[] objs3 = luaMgr.GetArrayObject<Type>(5);
			ParameterModifier[] objs4 = luaMgr.GetArrayObject<ParameterModifier>(6);
			MethodInfo o = obj.GetMethod(arg0,arg1,arg2,objs3,objs4);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 7)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			Binder arg2 = (Binder)luaMgr.GetNetObject(4);
			CallingConventions arg3 = (CallingConventions)luaMgr.GetNetObject(5);
			Type[] objs4 = luaMgr.GetArrayObject<Type>(6);
			ParameterModifier[] objs5 = luaMgr.GetArrayObject<ParameterModifier>(7);
			MethodInfo o = obj.GetMethod(arg0,arg1,arg2,arg3,objs4,objs5);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetMethod' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMethods(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			MethodInfo[] o = obj.GetMethods();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			MethodInfo[] o = obj.GetMethods(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetMethods' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNestedType(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Type o = obj.GetNestedType(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			Type o = obj.GetNestedType(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetNestedType' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNestedTypes(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			Type[] o = obj.GetNestedTypes();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			Type[] o = obj.GetNestedTypes(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetNestedTypes' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProperties(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			PropertyInfo[] o = obj.GetProperties();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			PropertyInfo[] o = obj.GetProperties(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetProperties' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProperty(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types1 = {typeof(Type), typeof(string), typeof(Type[])};
		Type[] types2 = {typeof(Type), typeof(string), typeof(Type)};
		Type[] types3 = {typeof(Type), typeof(string), typeof(BindingFlags)};

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			PropertyInfo o = obj.GetProperty(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3 && luaMgr.CheckTypes(types1, 1))
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Type[] objs1 = luaMgr.GetArrayObject<Type>(3);
			PropertyInfo o = obj.GetProperty(arg0,objs1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3 && luaMgr.CheckTypes(types2, 1))
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Type arg1 = (Type)luaMgr.GetNetObject(3);
			PropertyInfo o = obj.GetProperty(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3 && luaMgr.CheckTypes(types3, 1))
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			PropertyInfo o = obj.GetProperty(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 4)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Type arg1 = (Type)luaMgr.GetNetObject(3);
			Type[] objs2 = luaMgr.GetArrayObject<Type>(4);
			PropertyInfo o = obj.GetProperty(arg0,arg1,objs2);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 5)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			Type arg1 = (Type)luaMgr.GetNetObject(3);
			Type[] objs2 = luaMgr.GetArrayObject<Type>(4);
			ParameterModifier[] objs3 = luaMgr.GetArrayObject<ParameterModifier>(5);
			PropertyInfo o = obj.GetProperty(arg0,arg1,objs2,objs3);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 7)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			Binder arg2 = (Binder)luaMgr.GetNetObject(4);
			Type arg3 = (Type)luaMgr.GetNetObject(5);
			Type[] objs4 = luaMgr.GetArrayObject<Type>(6);
			ParameterModifier[] objs5 = luaMgr.GetArrayObject<ParameterModifier>(7);
			PropertyInfo o = obj.GetProperty(arg0,arg1,arg2,arg3,objs4,objs5);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetProperty' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetConstructor(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			Type[] objs0 = luaMgr.GetArrayObject<Type>(2);
			ConstructorInfo o = obj.GetConstructor(objs0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 5)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			Binder arg1 = (Binder)luaMgr.GetNetObject(3);
			Type[] objs2 = luaMgr.GetArrayObject<Type>(4);
			ParameterModifier[] objs3 = luaMgr.GetArrayObject<ParameterModifier>(5);
			ConstructorInfo o = obj.GetConstructor(arg0,arg1,objs2,objs3);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 6)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			Binder arg1 = (Binder)luaMgr.GetNetObject(3);
			CallingConventions arg2 = (CallingConventions)luaMgr.GetNetObject(4);
			Type[] objs3 = luaMgr.GetArrayObject<Type>(5);
			ParameterModifier[] objs4 = luaMgr.GetArrayObject<ParameterModifier>(6);
			ConstructorInfo o = obj.GetConstructor(arg0,arg1,arg2,objs3,objs4);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetConstructor' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetConstructors(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			ConstructorInfo[] o = obj.GetConstructors();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			BindingFlags arg0 = (BindingFlags)luaMgr.GetNetObject(2);
			ConstructorInfo[] o = obj.GetConstructors(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetConstructors' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDefaultMembers(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		MemberInfo[] o = obj.GetDefaultMembers();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindMembers(IntPtr l)
	{
		luaMgr.CheckArgsCount(5);
		Type obj = (Type)luaMgr.GetNetObject(1);
		MemberTypes arg0 = (MemberTypes)luaMgr.GetNetObject(2);
		BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
		MemberFilter arg2 = (MemberFilter)luaMgr.GetNetObject(4);
		object arg3 = (object)luaMgr.GetNetObject(5);
		MemberInfo[] o = obj.FindMembers(arg0,arg1,arg2,arg3);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InvokeMember(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 6)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			Binder arg2 = (Binder)luaMgr.GetNetObject(4);
			object arg3 = (object)luaMgr.GetNetObject(5);
			object[] objs4 = luaMgr.GetArrayObject<object>(6);
			object o = obj.InvokeMember(arg0,arg1,arg2,arg3,objs4);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 7)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			Binder arg2 = (Binder)luaMgr.GetNetObject(4);
			object arg3 = (object)luaMgr.GetNetObject(5);
			object[] objs4 = luaMgr.GetArrayObject<object>(6);
			CultureInfo arg5 = (CultureInfo)luaMgr.GetNetObject(7);
			object o = obj.InvokeMember(arg0,arg1,arg2,arg3,objs4,arg5);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 9)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			BindingFlags arg1 = (BindingFlags)luaMgr.GetNetObject(3);
			Binder arg2 = (Binder)luaMgr.GetNetObject(4);
			object arg3 = (object)luaMgr.GetNetObject(5);
			object[] objs4 = luaMgr.GetArrayObject<object>(6);
			ParameterModifier[] objs5 = luaMgr.GetArrayObject<ParameterModifier>(7);
			CultureInfo arg6 = (CultureInfo)luaMgr.GetNetObject(8);
			string[] objs7 = luaMgr.GetArrayString(9);
			object o = obj.InvokeMember(arg0,arg1,arg2,arg3,objs4,objs5,arg6,objs7);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.InvokeMember' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		string o = obj.ToString();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGenericArguments(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type[] o = obj.GetGenericArguments();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGenericTypeDefinition(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type o = obj.GetGenericTypeDefinition();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakeGenericType(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type[] objs0 = luaMgr.GetParamsObject<Type>(2, count - 1);
		Type o = obj.MakeGenericType(objs0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGenericParameterConstraints(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type[] o = obj.GetGenericParameterConstraints();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakeArrayType(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			Type o = obj.MakeArrayType();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			int arg0 = (int)luaMgr.GetNumber(2);
			Type o = obj.MakeArrayType(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.MakeArrayType' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakeByRefType(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type o = obj.MakeByRefType();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakePointerType(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type o = obj.MakePointerType();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReflectionOnlyGetType(IntPtr l)
	{
		luaMgr.CheckArgsCount(3);
		string arg0 = luaMgr.GetString(1);
		bool arg1 = luaMgr.GetBoolean(2);
		bool arg2 = luaMgr.GetBoolean(3);
		Type o = Type.ReflectionOnlyGetType(arg0,arg1,arg2);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsDefined(IntPtr l)
	{
		luaMgr.CheckArgsCount(3);
		Type obj = (Type)luaMgr.GetNetObject(1);
		Type arg0 = (Type)luaMgr.GetNetObject(2);
		bool arg1 = luaMgr.GetBoolean(3);
		bool o = obj.IsDefined(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCustomAttributes(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 2)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			bool arg0 = luaMgr.GetBoolean(2);
			object[] o = obj.GetCustomAttributes(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = (Type)luaMgr.GetNetObject(1);
			Type arg0 = (Type)luaMgr.GetNetObject(2);
			bool arg1 = luaMgr.GetBoolean(3);
			object[] o = obj.GetCustomAttributes(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Type.GetCustomAttributes' has some invalid arguments");
		}

		return 0;
	}
}

