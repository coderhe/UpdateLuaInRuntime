using System;
using LuaInterface;
using LuaFramework;
using System.IO;
using UEEngine;
using UnityEngine;

public class LuaManager
{
    private static LuaManager msInstance = null;
    public static LuaManager Get()
    {
        return msInstance;
    }

    public static LuaManager CreateInstance()
    {
        if (msInstance == null)
        {
            msInstance = new LuaManager();
            msInstance.InitStart();
            
            HotUpdateUtility.CreateLuaFileWatcher();
        }
        return msInstance;
    }

    public static void ReleaseInstance()
    {
        if (msInstance != null)
        {
            msInstance.Release();
            msInstance = null;
        }
    }

    private LuaManager()
    {
    }

    private void InitStart()
    {
        InitLuaPath();
    }

    /// <summary>
    /// 初始化加载第三方库
    /// </summary>
    void OpenLibs()
    {
    }

    /// <summary>
    /// 初始化Lua代码加载路径
    /// </summary>
    void InitLuaPath()
    {
        
    }

    public void DoFile(string filename)
    {

    }

    // 此方法只允许和主入口间调用一次
    public object[] CallFunction(string funcName, params object[] args)
    {
    }

   
    private void Release()
    {
        
    }
}