using System;
using System.Reflection;
using System.Globalization;
using LuaInterface;

public class TypeWrap
{
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
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
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
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Type class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Type));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Type", typeof(Type), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Delimiter(IntPtr L)
	{
		LuaScriptMgr.Push(L, Type.Delimiter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_EmptyTypes(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Type.EmptyTypes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FilterAttribute(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Type.FilterAttribute);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FilterName(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Type.FilterName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FilterNameIgnoreCase(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Type.FilterNameIgnoreCase);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Missing(IntPtr L)
	{
		LuaScriptMgr.PushVarObject(L, Type.Missing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Assembly(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Assembly");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushObject(L, obj.Assembly);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssemblyQualifiedName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name AssemblyQualifiedName");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.AssemblyQualifiedName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Attributes(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Attributes");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushEnum(L, obj.Attributes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BaseType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BaseType");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.BaseType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DeclaringType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name DeclaringType");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.DeclaringType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefaultBinder(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Type.DefaultBinder);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FullName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name FullName");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.FullName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GUID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name GUID");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushValue(L, obj.GUID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HasElementType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name HasElementType");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.HasElementType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsAbstract(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsAbstract");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsAbstract);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsAnsiClass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsAnsiClass");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsAnsiClass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsArray(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsArray");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsArray);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsAutoClass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsAutoClass");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsAutoClass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsAutoLayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsAutoLayout");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsAutoLayout);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsByRef(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsByRef");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsByRef);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsClass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsClass");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsClass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsCOMObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsCOMObject");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsCOMObject);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsContextful(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsContextful");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsContextful);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsEnum(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsEnum");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsEnum);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsExplicitLayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsExplicitLayout");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsExplicitLayout);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsImport(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsImport");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsImport);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsInterface(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsInterface");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsInterface);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsLayoutSequential(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsLayoutSequential");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsLayoutSequential);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsMarshalByRef(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsMarshalByRef");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsMarshalByRef);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNestedAssembly(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsNestedAssembly");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsNestedAssembly);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNestedFamANDAssem(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsNestedFamANDAssem");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsNestedFamANDAssem);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNestedFamily(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsNestedFamily");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsNestedFamily);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNestedFamORAssem(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsNestedFamORAssem");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsNestedFamORAssem);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNestedPrivate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsNestedPrivate");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsNestedPrivate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNestedPublic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsNestedPublic");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsNestedPublic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNotPublic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsNotPublic");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsNotPublic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsPointer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsPointer");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsPointer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsPrimitive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsPrimitive");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsPrimitive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsPublic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsPublic");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsPublic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsSealed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsSealed");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsSealed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsSerializable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsSerializable");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsSerializable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsSpecialName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsSpecialName");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsSpecialName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsUnicodeClass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsUnicodeClass");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsUnicodeClass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsValueType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsValueType");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsValueType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MemberType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name MemberType");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushEnum(L, obj.MemberType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Module(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Module");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushObject(L, obj.Module);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Namespace(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Namespace");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.Namespace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ReflectedType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ReflectedType");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.ReflectedType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TypeHandle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name TypeHandle");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushValue(L, obj.TypeHandle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TypeInitializer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name TypeInitializer");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushObject(L, obj.TypeInitializer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UnderlyingSystemType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UnderlyingSystemType");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.UnderlyingSystemType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ContainsGenericParameters(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ContainsGenericParameters");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.ContainsGenericParameters);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsGenericTypeDefinition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsGenericTypeDefinition");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsGenericTypeDefinition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsGenericType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsGenericType");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsGenericType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsGenericParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsGenericParameter");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsGenericParameter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsNested(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsNested");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsNested);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsVisible(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsVisible");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.IsVisible);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GenericParameterPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name GenericParameterPosition");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.GenericParameterPosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GenericParameterAttributes(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name GenericParameterAttributes");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushEnum(L, obj.GenericParameterAttributes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DeclaringMethod(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name DeclaringMethod");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushObject(L, obj.DeclaringMethod);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StructLayoutAttribute(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name StructLayoutAttribute");
		}

		Type obj = (Type)o;
		LuaScriptMgr.PushObject(L, obj.StructLayoutAttribute);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Name");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MetadataToken(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name MetadataToken");
		}

		Type obj = (Type)o;
		LuaScriptMgr.Push(L, obj.MetadataToken);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Type), typeof(Type)};
		Type[] types1 = {typeof(Type), typeof(object)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool o = obj.Equals(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			bool o = obj.Equals(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.Equals");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Type)};
		Type[] types1 = {typeof(string)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			Type o = obj.GetType();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Type o = Type.GetType(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			Type o = Type.GetType(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Type o = Type.GetType(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetType");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object[] objs0 = LuaScriptMgr.GetArrayObject<object>(L, 1);
		Type[] o = Type.GetTypeArray(objs0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		TypeCode o = Type.GetTypeCode(arg0);
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeFromCLSID(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Guid), typeof(string)};
		Type[] types2 = {typeof(Guid), typeof(bool)};

		if (count == 1)
		{
			Guid arg0 = LuaScriptMgr.GetNetObject<Guid>(L, 1);
			Type o = Type.GetTypeFromCLSID(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Guid arg0 = LuaScriptMgr.GetNetObject<Guid>(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			Type o = Type.GetTypeFromCLSID(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Guid arg0 = LuaScriptMgr.GetNetObject<Guid>(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			Type o = Type.GetTypeFromCLSID(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Guid arg0 = LuaScriptMgr.GetNetObject<Guid>(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Type o = Type.GetTypeFromCLSID(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetTypeFromCLSID");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeFromHandle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RuntimeTypeHandle arg0 = LuaScriptMgr.GetNetObject<RuntimeTypeHandle>(L, 1);
		Type o = Type.GetTypeFromHandle(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeFromProgID(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(string), typeof(string)};
		Type[] types2 = {typeof(string), typeof(bool)};

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Type o = Type.GetTypeFromProgID(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			Type o = Type.GetTypeFromProgID(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			Type o = Type.GetTypeFromProgID(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Type o = Type.GetTypeFromProgID(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetTypeFromProgID");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTypeHandle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		RuntimeTypeHandle o = Type.GetTypeHandle(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsSubclassOf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		bool o = obj.IsSubclassOf(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindInterfaces(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		TypeFilter arg0 = LuaScriptMgr.GetNetObject<TypeFilter>(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		Type[] o = obj.FindInterfaces(arg0,arg1);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInterface(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Type o = obj.GetInterface(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Type o = obj.GetInterface(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetInterface");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInterfaceMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		InterfaceMapping o = obj.GetInterfaceMap(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInterfaces(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type[] o = obj.GetInterfaces();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsAssignableFrom(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		bool o = obj.IsAssignableFrom(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInstanceOfType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.IsInstanceOfType(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetArrayRank(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		int o = obj.GetArrayRank();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetElementType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type o = obj.GetElementType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEvent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			EventInfo o = obj.GetEvent(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			EventInfo o = obj.GetEvent(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetEvent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEvents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			EventInfo[] o = obj.GetEvents();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			EventInfo[] o = obj.GetEvents(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetEvents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetField(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			FieldInfo o = obj.GetField(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			FieldInfo o = obj.GetField(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetField");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFields(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			FieldInfo[] o = obj.GetFields();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			FieldInfo[] o = obj.GetFields(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetFields");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMember(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			MemberInfo[] o = obj.GetMember(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			MemberInfo[] o = obj.GetMember(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			MemberTypes arg1 = LuaScriptMgr.GetNetObject<MemberTypes>(L, 3);
			BindingFlags arg2 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 4);
			MemberInfo[] o = obj.GetMember(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetMember");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMembers(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			MemberInfo[] o = obj.GetMembers();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			MemberInfo[] o = obj.GetMembers(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetMembers");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMethod(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Type), typeof(string), typeof(Type[])};
		Type[] types2 = {typeof(Type), typeof(string), typeof(BindingFlags)};

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			MethodInfo o = obj.GetMethod(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Type[] objs1 = LuaScriptMgr.GetArrayObject<Type>(L, 3);
			MethodInfo o = obj.GetMethod(arg0,objs1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			MethodInfo o = obj.GetMethod(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Type[] objs1 = LuaScriptMgr.GetArrayObject<Type>(L, 3);
			ParameterModifier[] objs2 = LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 4);
			MethodInfo o = obj.GetMethod(arg0,objs1,objs2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			Binder arg2 = LuaScriptMgr.GetNetObject<Binder>(L, 4);
			Type[] objs3 = LuaScriptMgr.GetArrayObject<Type>(L, 5);
			ParameterModifier[] objs4 = LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 6);
			MethodInfo o = obj.GetMethod(arg0,arg1,arg2,objs3,objs4);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			Binder arg2 = LuaScriptMgr.GetNetObject<Binder>(L, 4);
			CallingConventions arg3 = LuaScriptMgr.GetNetObject<CallingConventions>(L, 5);
			Type[] objs4 = LuaScriptMgr.GetArrayObject<Type>(L, 6);
			ParameterModifier[] objs5 = LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 7);
			MethodInfo o = obj.GetMethod(arg0,arg1,arg2,arg3,objs4,objs5);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetMethod");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMethods(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			MethodInfo[] o = obj.GetMethods();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			MethodInfo[] o = obj.GetMethods(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetMethods");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNestedType(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Type o = obj.GetNestedType(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			Type o = obj.GetNestedType(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetNestedType");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNestedTypes(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			Type[] o = obj.GetNestedTypes();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			Type[] o = obj.GetNestedTypes(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetNestedTypes");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProperties(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			PropertyInfo[] o = obj.GetProperties();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			PropertyInfo[] o = obj.GetProperties(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetProperties");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProperty(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Type), typeof(string), typeof(Type[])};
		Type[] types2 = {typeof(Type), typeof(string), typeof(Type)};
		Type[] types3 = {typeof(Type), typeof(string), typeof(BindingFlags)};

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			PropertyInfo o = obj.GetProperty(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Type[] objs1 = LuaScriptMgr.GetArrayObject<Type>(L, 3);
			PropertyInfo o = obj.GetProperty(arg0,objs1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 3);
			PropertyInfo o = obj.GetProperty(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			PropertyInfo o = obj.GetProperty(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 3);
			Type[] objs2 = LuaScriptMgr.GetArrayObject<Type>(L, 4);
			PropertyInfo o = obj.GetProperty(arg0,arg1,objs2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 3);
			Type[] objs2 = LuaScriptMgr.GetArrayObject<Type>(L, 4);
			ParameterModifier[] objs3 = LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 5);
			PropertyInfo o = obj.GetProperty(arg0,arg1,objs2,objs3);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			Binder arg2 = LuaScriptMgr.GetNetObject<Binder>(L, 4);
			Type arg3 = LuaScriptMgr.GetTypeObject(L, 5);
			Type[] objs4 = LuaScriptMgr.GetArrayObject<Type>(L, 6);
			ParameterModifier[] objs5 = LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 7);
			PropertyInfo o = obj.GetProperty(arg0,arg1,arg2,arg3,objs4,objs5);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetProperty");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetConstructor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			Type[] objs0 = LuaScriptMgr.GetArrayObject<Type>(L, 2);
			ConstructorInfo o = obj.GetConstructor(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			Binder arg1 = LuaScriptMgr.GetNetObject<Binder>(L, 3);
			Type[] objs2 = LuaScriptMgr.GetArrayObject<Type>(L, 4);
			ParameterModifier[] objs3 = LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 5);
			ConstructorInfo o = obj.GetConstructor(arg0,arg1,objs2,objs3);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			Binder arg1 = LuaScriptMgr.GetNetObject<Binder>(L, 3);
			CallingConventions arg2 = LuaScriptMgr.GetNetObject<CallingConventions>(L, 4);
			Type[] objs3 = LuaScriptMgr.GetArrayObject<Type>(L, 5);
			ParameterModifier[] objs4 = LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 6);
			ConstructorInfo o = obj.GetConstructor(arg0,arg1,arg2,objs3,objs4);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetConstructor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetConstructors(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			ConstructorInfo[] o = obj.GetConstructors();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			BindingFlags arg0 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 2);
			ConstructorInfo[] o = obj.GetConstructors(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetConstructors");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDefaultMembers(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		MemberInfo[] o = obj.GetDefaultMembers();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindMembers(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		MemberTypes arg0 = LuaScriptMgr.GetNetObject<MemberTypes>(L, 2);
		BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
		MemberFilter arg2 = LuaScriptMgr.GetNetObject<MemberFilter>(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		MemberInfo[] o = obj.FindMembers(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InvokeMember(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 6)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			Binder arg2 = LuaScriptMgr.GetNetObject<Binder>(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			object[] objs4 = LuaScriptMgr.GetArrayObject<object>(L, 6);
			object o = obj.InvokeMember(arg0,arg1,arg2,arg3,objs4);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			Binder arg2 = LuaScriptMgr.GetNetObject<Binder>(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			object[] objs4 = LuaScriptMgr.GetArrayObject<object>(L, 6);
			CultureInfo arg5 = LuaScriptMgr.GetNetObject<CultureInfo>(L, 7);
			object o = obj.InvokeMember(arg0,arg1,arg2,arg3,objs4,arg5);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else if (count == 9)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BindingFlags arg1 = LuaScriptMgr.GetNetObject<BindingFlags>(L, 3);
			Binder arg2 = LuaScriptMgr.GetNetObject<Binder>(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			object[] objs4 = LuaScriptMgr.GetArrayObject<object>(L, 6);
			ParameterModifier[] objs5 = LuaScriptMgr.GetArrayObject<ParameterModifier>(L, 7);
			CultureInfo arg6 = LuaScriptMgr.GetNetObject<CultureInfo>(L, 8);
			string[] objs7 = LuaScriptMgr.GetArrayString(L, 9);
			object o = obj.InvokeMember(arg0,arg1,arg2,arg3,objs4,objs5,arg6,objs7);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.InvokeMember");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGenericArguments(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type[] o = obj.GetGenericArguments();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGenericTypeDefinition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type o = obj.GetGenericTypeDefinition();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakeGenericType(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type[] objs0 = LuaScriptMgr.GetParamsObject<Type>(L, 2, count - 1);
		Type o = obj.MakeGenericType(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGenericParameterConstraints(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type[] o = obj.GetGenericParameterConstraints();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakeArrayType(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			Type o = obj.MakeArrayType();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Type o = obj.MakeArrayType(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.MakeArrayType");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakeByRefType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type o = obj.MakeByRefType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MakePointerType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type o = obj.MakePointerType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReflectionOnlyGetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
		Type o = Type.ReflectionOnlyGetType(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsDefined(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Type obj = LuaScriptMgr.GetTypeObject(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
		bool o = obj.IsDefined(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCustomAttributes(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			object[] o = obj.GetCustomAttributes(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Type obj = LuaScriptMgr.GetTypeObject(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			object[] o = obj.GetCustomAttributes(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Type.GetCustomAttributes");
		}

		return 0;
	}
}

