/*
 * 与Lua中主入口交互
 */
using UnityEngine;

public class LuaMain
{
    private static LuaMain msInstance;

    private LuaFunction mFunctionHotUpdate;

    public static LuaMain Get()
    {
        return msInstance;
    }

    public static LuaMain CreateInstance()
    {
        if (msInstance == null)
        {
            msInstance = new LuaMain();
        }
        return msInstance;
    }

    private LuaTable mTableLuaMain;

    private UELuaMain()
    {
        UELuaManager luaManager = UELuaManager.Get();
        if (luaManager != null)
        {
            luaManager.SetDebugMode(UEPlatform.Platform.EnableLuaDebug);
            luaManager.DoFile("UELuaMain");
            object[] objs = luaManager.CallFunction("GetLuaMain");
            mTableLuaMain = objs[0] as LuaTable;
            CreateLuaFunction();
        }
    }

    public void HotUpdate(string fileName)
    {
        if (mFunctionHotUpdate != null)
        {
            mFunctionHotUpdate.BeginPCall();
            mFunctionHotUpdate.Push(fileName);
            mFunctionHotUpdate.PCall();
            mFunctionHotUpdate.EndPCall();
        }
    }

    public LuaTable NewTable()
    {
        LuaState luaState = UELuaManager.Get().GetLuaState();
        if (luaState != null)
        {
            return luaState.NewTable();
        }

        return null;
    }

    private void CreateLuaFunction()
    {
        mFunctionHotUpdate = mTableLuaMain.GetLuaFunction("HotUpdate");
    }
    
    public void Release()
    {
        if (mTableLuaMain != null)
        {
            mTableLuaMain.Dispose();
            mTableLuaMain = null;
        }
    }

    public static void ReleaseInstance()
    {
        if (msInstance != null)
        {
            msInstance.Release();
            msInstance = null;
        }
    }
}