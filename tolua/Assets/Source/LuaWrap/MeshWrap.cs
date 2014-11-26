using UnityEngine;
using System;
using LuaInterface;

public class MeshWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Clear", Clear),
		new LuaMethod("RecalculateBounds", RecalculateBounds),
		new LuaMethod("RecalculateNormals", RecalculateNormals),
		new LuaMethod("Optimize", Optimize),
		new LuaMethod("GetTriangles", GetTriangles),
		new LuaMethod("SetTriangles", SetTriangles),
		new LuaMethod("GetIndices", GetIndices),
		new LuaMethod("SetIndices", SetIndices),
		new LuaMethod("GetTopology", GetTopology),
		new LuaMethod("CombineMeshes", CombineMeshes),
		new LuaMethod("MarkDynamic", MarkDynamic),
		new LuaMethod("UploadMeshData", UploadMeshData),
		new LuaMethod("GetBlendShapeName", GetBlendShapeName),
		new LuaMethod("GetBlendShapeIndex", GetBlendShapeIndex),
		new LuaMethod("New", _CreateMesh),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("isReadable", get_isReadable, null),
		new LuaField("vertices", get_vertices, set_vertices),
		new LuaField("normals", get_normals, set_normals),
		new LuaField("tangents", get_tangents, set_tangents),
		new LuaField("uv", get_uv, set_uv),
		new LuaField("uv2", get_uv2, set_uv2),
		new LuaField("uv1", get_uv1, set_uv1),
		new LuaField("bounds", get_bounds, set_bounds),
		new LuaField("colors", get_colors, set_colors),
		new LuaField("colors32", get_colors32, set_colors32),
		new LuaField("triangles", get_triangles, set_triangles),
		new LuaField("vertexCount", get_vertexCount, null),
		new LuaField("subMeshCount", get_subMeshCount, set_subMeshCount),
		new LuaField("boneWeights", get_boneWeights, set_boneWeights),
		new LuaField("bindposes", get_bindposes, set_bindposes),
		new LuaField("blendShapeCount", get_blendShapeCount, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMesh(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Mesh obj = new Mesh();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Mesh.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Mesh));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Mesh", typeof(Mesh), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isReadable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isReadable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isReadable on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.Push(L, obj.isReadable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vertices(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vertices");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vertices on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.vertices);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_normals(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name normals");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index normals on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.normals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tangents(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tangents");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tangents on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.tangents);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uv(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uv");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uv on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.uv);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uv2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uv2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uv2 on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.uv2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uv1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uv1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uv1 on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.uv1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushValue(L, obj.bounds);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colors(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colors");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colors on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.colors);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colors32(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colors32");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colors32 on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.colors32);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_triangles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name triangles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index triangles on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.triangles);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vertexCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vertexCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vertexCount on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.Push(L, obj.vertexCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_subMeshCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subMeshCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subMeshCount on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.Push(L, obj.subMeshCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_boneWeights(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneWeights");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneWeights on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.boneWeights);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bindposes(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bindposes");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bindposes on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.PushArray(L, obj.bindposes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_blendShapeCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name blendShapeCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index blendShapeCount on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		LuaScriptMgr.Push(L, obj.blendShapeCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_vertices(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vertices");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vertices on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.vertices = LuaScriptMgr.GetNetObject<Vector3[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_normals(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name normals");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index normals on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.normals = LuaScriptMgr.GetNetObject<Vector3[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tangents(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tangents");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tangents on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.tangents = LuaScriptMgr.GetNetObject<Vector4[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uv(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uv");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uv on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.uv = LuaScriptMgr.GetNetObject<Vector2[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uv2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uv2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uv2 on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.uv2 = LuaScriptMgr.GetNetObject<Vector2[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uv1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uv1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uv1 on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.uv1 = LuaScriptMgr.GetNetObject<Vector2[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bounds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.bounds = LuaScriptMgr.GetNetObject<Bounds>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colors(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colors");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colors on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.colors = LuaScriptMgr.GetNetObject<Color[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colors32(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colors32");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colors32 on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.colors32 = LuaScriptMgr.GetNetObject<Color32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_triangles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name triangles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index triangles on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.triangles = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_subMeshCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subMeshCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subMeshCount on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.subMeshCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_boneWeights(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name boneWeights");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index boneWeights on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.boneWeights = LuaScriptMgr.GetNetObject<BoneWeight[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bindposes(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bindposes");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bindposes on a nil value");
			}
		}

		Mesh obj = (Mesh)o;
		obj.bindposes = LuaScriptMgr.GetNetObject<Matrix4x4[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
			obj.Clear();
			return 0;
		}
		else if (count == 2)
		{
			Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Clear(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Mesh.Clear");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RecalculateBounds(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		obj.RecalculateBounds();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RecalculateNormals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		obj.RecalculateNormals();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Optimize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		obj.Optimize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTriangles(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int[] o = obj.GetTriangles(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTriangles(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		int[] objs0 = LuaScriptMgr.GetArrayNumber<int>(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.SetTriangles(objs0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIndices(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int[] o = obj.GetIndices(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetIndices(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		int[] objs0 = LuaScriptMgr.GetArrayNumber<int>(L, 2);
		MeshTopology arg1 = LuaScriptMgr.GetNetObject<MeshTopology>(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		obj.SetIndices(objs0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTopology(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		MeshTopology o = obj.GetTopology(arg0);
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CombineMeshes(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
			CombineInstance[] objs0 = LuaScriptMgr.GetArrayObject<CombineInstance>(L, 2);
			obj.CombineMeshes(objs0);
			return 0;
		}
		else if (count == 3)
		{
			Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
			CombineInstance[] objs0 = LuaScriptMgr.GetArrayObject<CombineInstance>(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.CombineMeshes(objs0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
			CombineInstance[] objs0 = LuaScriptMgr.GetArrayObject<CombineInstance>(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			obj.CombineMeshes(objs0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Mesh.CombineMeshes");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MarkDynamic(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		obj.MarkDynamic();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UploadMeshData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.UploadMeshData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBlendShapeName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string o = obj.GetBlendShapeName(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBlendShapeIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Mesh obj = LuaScriptMgr.GetNetObject<Mesh>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int o = obj.GetBlendShapeIndex(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

