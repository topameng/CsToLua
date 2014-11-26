using UnityEngine;
using System;
using LuaInterface;

public class CameraWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetTargetBuffers", SetTargetBuffers),
		new LuaMethod("ResetWorldToCameraMatrix", ResetWorldToCameraMatrix),
		new LuaMethod("ResetProjectionMatrix", ResetProjectionMatrix),
		new LuaMethod("ResetAspect", ResetAspect),
		new LuaMethod("WorldToScreenPoint", WorldToScreenPoint),
		new LuaMethod("WorldToViewportPoint", WorldToViewportPoint),
		new LuaMethod("ViewportToWorldPoint", ViewportToWorldPoint),
		new LuaMethod("ScreenToWorldPoint", ScreenToWorldPoint),
		new LuaMethod("ScreenToViewportPoint", ScreenToViewportPoint),
		new LuaMethod("ViewportToScreenPoint", ViewportToScreenPoint),
		new LuaMethod("ViewportPointToRay", ViewportPointToRay),
		new LuaMethod("ScreenPointToRay", ScreenPointToRay),
		new LuaMethod("GetAllCameras", GetAllCameras),
		new LuaMethod("Render", Render),
		new LuaMethod("RenderWithShader", RenderWithShader),
		new LuaMethod("SetReplacementShader", SetReplacementShader),
		new LuaMethod("ResetReplacementShader", ResetReplacementShader),
		new LuaMethod("RenderDontRestore", RenderDontRestore),
		new LuaMethod("SetupCurrent", SetupCurrent),
		new LuaMethod("RenderToCubemap", RenderToCubemap),
		new LuaMethod("CopyFrom", CopyFrom),
		new LuaMethod("CalculateObliqueMatrix", CalculateObliqueMatrix),
		new LuaMethod("New", _CreateCamera),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("fieldOfView", get_fieldOfView, set_fieldOfView),
		new LuaField("nearClipPlane", get_nearClipPlane, set_nearClipPlane),
		new LuaField("farClipPlane", get_farClipPlane, set_farClipPlane),
		new LuaField("renderingPath", get_renderingPath, set_renderingPath),
		new LuaField("actualRenderingPath", get_actualRenderingPath, null),
		new LuaField("hdr", get_hdr, set_hdr),
		new LuaField("orthographicSize", get_orthographicSize, set_orthographicSize),
		new LuaField("orthographic", get_orthographic, set_orthographic),
		new LuaField("transparencySortMode", get_transparencySortMode, set_transparencySortMode),
		new LuaField("isOrthoGraphic", get_isOrthoGraphic, set_isOrthoGraphic),
		new LuaField("depth", get_depth, set_depth),
		new LuaField("aspect", get_aspect, set_aspect),
		new LuaField("cullingMask", get_cullingMask, set_cullingMask),
		new LuaField("eventMask", get_eventMask, set_eventMask),
		new LuaField("backgroundColor", get_backgroundColor, set_backgroundColor),
		new LuaField("rect", get_rect, set_rect),
		new LuaField("pixelRect", get_pixelRect, set_pixelRect),
		new LuaField("targetTexture", get_targetTexture, set_targetTexture),
		new LuaField("pixelWidth", get_pixelWidth, null),
		new LuaField("pixelHeight", get_pixelHeight, null),
		new LuaField("cameraToWorldMatrix", get_cameraToWorldMatrix, null),
		new LuaField("worldToCameraMatrix", get_worldToCameraMatrix, set_worldToCameraMatrix),
		new LuaField("projectionMatrix", get_projectionMatrix, set_projectionMatrix),
		new LuaField("velocity", get_velocity, null),
		new LuaField("clearFlags", get_clearFlags, set_clearFlags),
		new LuaField("stereoEnabled", get_stereoEnabled, null),
		new LuaField("stereoSeparation", get_stereoSeparation, set_stereoSeparation),
		new LuaField("stereoConvergence", get_stereoConvergence, set_stereoConvergence),
		new LuaField("main", get_main, null),
		new LuaField("current", get_current, null),
		new LuaField("allCameras", get_allCameras, null),
		new LuaField("allCamerasCount", get_allCamerasCount, null),
		new LuaField("useOcclusionCulling", get_useOcclusionCulling, set_useOcclusionCulling),
		new LuaField("layerCullDistances", get_layerCullDistances, set_layerCullDistances),
		new LuaField("layerCullSpherical", get_layerCullSpherical, set_layerCullSpherical),
		new LuaField("depthTextureMode", get_depthTextureMode, set_depthTextureMode),
		new LuaField("clearStencilAfterLightingPass", get_clearStencilAfterLightingPass, set_clearStencilAfterLightingPass),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCamera(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Camera obj = new Camera();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Camera.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Camera));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Camera", typeof(Camera), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fieldOfView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fieldOfView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fieldOfView on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.fieldOfView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nearClipPlane(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nearClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nearClipPlane on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.nearClipPlane);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_farClipPlane(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name farClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index farClipPlane on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.farClipPlane);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderingPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderingPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderingPath on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushEnum(L, obj.renderingPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_actualRenderingPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name actualRenderingPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index actualRenderingPath on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushEnum(L, obj.actualRenderingPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hdr(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hdr");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hdr on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.hdr);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthographicSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographicSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographicSize on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.orthographicSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orthographic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographic on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.orthographic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transparencySortMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name transparencySortMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index transparencySortMode on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushEnum(L, obj.transparencySortMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isOrthoGraphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOrthoGraphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOrthoGraphic on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.isOrthoGraphic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_aspect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspect on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.aspect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cullingMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cullingMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cullingMask on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.cullingMask);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_eventMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventMask on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.eventMask);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_backgroundColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backgroundColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backgroundColor on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushValue(L, obj.backgroundColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rect on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushValue(L, obj.rect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelRect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelRect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelRect on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushValue(L, obj.pixelRect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetTexture on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.targetTexture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelWidth on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.pixelWidth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelHeight on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.pixelHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cameraToWorldMatrix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cameraToWorldMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cameraToWorldMatrix on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushValue(L, obj.cameraToWorldMatrix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldToCameraMatrix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldToCameraMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldToCameraMatrix on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushValue(L, obj.worldToCameraMatrix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_projectionMatrix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionMatrix on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushValue(L, obj.projectionMatrix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name velocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index velocity on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushValue(L, obj.velocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clearFlags(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clearFlags");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clearFlags on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushEnum(L, obj.clearFlags);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoEnabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoEnabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoEnabled on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.stereoEnabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoSeparation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoSeparation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoSeparation on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.stereoSeparation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stereoConvergence(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoConvergence");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoConvergence on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.stereoConvergence);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_main(IntPtr L)
	{
		LuaScriptMgr.Push(L, Camera.main);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, Camera.current);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_allCameras(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Camera.allCameras);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_allCamerasCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Camera.allCamerasCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useOcclusionCulling(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useOcclusionCulling");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useOcclusionCulling on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.useOcclusionCulling);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layerCullDistances(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layerCullDistances");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layerCullDistances on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushArray(L, obj.layerCullDistances);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layerCullSpherical(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layerCullSpherical");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layerCullSpherical on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.layerCullSpherical);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depthTextureMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depthTextureMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depthTextureMode on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.PushEnum(L, obj.depthTextureMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clearStencilAfterLightingPass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clearStencilAfterLightingPass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clearStencilAfterLightingPass on a nil value");
			}
		}

		Camera obj = (Camera)o;
		LuaScriptMgr.Push(L, obj.clearStencilAfterLightingPass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fieldOfView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fieldOfView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fieldOfView on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.fieldOfView = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_nearClipPlane(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nearClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nearClipPlane on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.nearClipPlane = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_farClipPlane(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name farClipPlane");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index farClipPlane on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.farClipPlane = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderingPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderingPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderingPath on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.renderingPath = LuaScriptMgr.GetNetObject<RenderingPath>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hdr(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hdr");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hdr on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.hdr = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthographicSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographicSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographicSize on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.orthographicSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orthographic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name orthographic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index orthographic on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.orthographic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_transparencySortMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name transparencySortMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index transparencySortMode on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.transparencySortMode = LuaScriptMgr.GetNetObject<TransparencySortMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isOrthoGraphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOrthoGraphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOrthoGraphic on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.isOrthoGraphic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.depth = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_aspect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name aspect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index aspect on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.aspect = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cullingMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cullingMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cullingMask on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.cullingMask = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_eventMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eventMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eventMask on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.eventMask = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_backgroundColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name backgroundColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index backgroundColor on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.backgroundColor = LuaScriptMgr.GetNetObject<Color>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rect on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.rect = LuaScriptMgr.GetNetObject<Rect>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelRect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelRect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelRect on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.pixelRect = LuaScriptMgr.GetNetObject<Rect>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetTexture on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.targetTexture = LuaScriptMgr.GetNetObject<RenderTexture>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_worldToCameraMatrix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldToCameraMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldToCameraMatrix on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.worldToCameraMatrix = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_projectionMatrix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionMatrix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionMatrix on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.projectionMatrix = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clearFlags(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clearFlags");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clearFlags on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.clearFlags = LuaScriptMgr.GetNetObject<CameraClearFlags>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stereoSeparation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoSeparation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoSeparation on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.stereoSeparation = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stereoConvergence(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stereoConvergence");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stereoConvergence on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.stereoConvergence = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useOcclusionCulling(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useOcclusionCulling");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useOcclusionCulling on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.useOcclusionCulling = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layerCullDistances(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layerCullDistances");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layerCullDistances on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.layerCullDistances = LuaScriptMgr.GetNetObject<Single[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layerCullSpherical(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layerCullSpherical");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layerCullSpherical on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.layerCullSpherical = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depthTextureMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depthTextureMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depthTextureMode on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.depthTextureMode = LuaScriptMgr.GetNetObject<DepthTextureMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clearStencilAfterLightingPass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clearStencilAfterLightingPass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clearStencilAfterLightingPass on a nil value");
			}
		}

		Camera obj = (Camera)o;
		obj.clearStencilAfterLightingPass = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTargetBuffers(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Camera), typeof(RenderBuffer[]), typeof(RenderBuffer)};
		Type[] types1 = {typeof(Camera), typeof(RenderBuffer), typeof(RenderBuffer)};

		if (count == 3 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
			RenderBuffer[] objs0 = LuaScriptMgr.GetArrayObject<RenderBuffer>(L, 2);
			RenderBuffer arg1 = LuaScriptMgr.GetNetObject<RenderBuffer>(L, 3);
			obj.SetTargetBuffers(objs0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
			RenderBuffer arg0 = LuaScriptMgr.GetNetObject<RenderBuffer>(L, 2);
			RenderBuffer arg1 = LuaScriptMgr.GetNetObject<RenderBuffer>(L, 3);
			obj.SetTargetBuffers(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Camera.SetTargetBuffers");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetWorldToCameraMatrix(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		obj.ResetWorldToCameraMatrix();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetProjectionMatrix(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		obj.ResetProjectionMatrix();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetAspect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		obj.ResetAspect();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WorldToScreenPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.WorldToScreenPoint(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WorldToViewportPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.WorldToViewportPoint(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportToWorldPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.ViewportToWorldPoint(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenToWorldPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.ScreenToWorldPoint(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenToViewportPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.ScreenToViewportPoint(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportToScreenPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.ViewportToScreenPoint(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ViewportPointToRay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Ray o = obj.ViewportPointToRay(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScreenPointToRay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Ray o = obj.ScreenPointToRay(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllCameras(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera[] objs0 = LuaScriptMgr.GetArrayObject<Camera>(L, 1);
		int o = Camera.GetAllCameras(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Render(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		obj.Render();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderWithShader(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Shader arg0 = LuaScriptMgr.GetNetObject<Shader>(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.RenderWithShader(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetReplacementShader(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Shader arg0 = LuaScriptMgr.GetNetObject<Shader>(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.SetReplacementShader(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetReplacementShader(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		obj.ResetReplacementShader();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderDontRestore(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		obj.RenderDontRestore();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetupCurrent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Camera arg0 = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Camera.SetupCurrent(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RenderToCubemap(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Camera), typeof(RenderTexture)};
		Type[] types1 = {typeof(Camera), typeof(Cubemap)};
		Type[] types2 = {typeof(Camera), typeof(RenderTexture), typeof(int)};
		Type[] types3 = {typeof(Camera), typeof(Cubemap), typeof(int)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
			RenderTexture arg0 = LuaScriptMgr.GetNetObject<RenderTexture>(L, 2);
			bool o = obj.RenderToCubemap(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
			Cubemap arg0 = LuaScriptMgr.GetNetObject<Cubemap>(L, 2);
			bool o = obj.RenderToCubemap(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
			RenderTexture arg0 = LuaScriptMgr.GetNetObject<RenderTexture>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			bool o = obj.RenderToCubemap(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
			Cubemap arg0 = LuaScriptMgr.GetNetObject<Cubemap>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			bool o = obj.RenderToCubemap(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Camera.RenderToCubemap");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyFrom(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Camera arg0 = LuaScriptMgr.GetNetObject<Camera>(L, 2);
		obj.CopyFrom(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateObliqueMatrix(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Camera obj = LuaScriptMgr.GetNetObject<Camera>(L, 1);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		Matrix4x4 o = obj.CalculateObliqueMatrix(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}
}

