using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotUpdateUtility
{
    private static HashSet<string> _changedLuaFiles = new HashSet<string>();

    public static HashSet<string> ChangedLuaFiles
    {
        get
        {
            return _changedLuaFiles;
        }
    }

    public static void CreateLuaFileWatcher()
    {
        var scriptPath = Path.Combine(Application.dataPath, "LuaFrameWork/Lua");
        var directoryWatcher = new DirectoryWatcher(scriptPath, new FileSystemEventHandler(LuaFileOnChanged));
    }

    private static void LuaFileOnChanged(object obj, FileSystemEventArgs args)
    {
        var luaFolderName = "LuaFrameWork";
        var requirePath = args.FullPath.Replace(".lua", "");
        var luaScriptIndex = requirePath.IndexOf(luaFolderName) + luaFolderName.Length + 5;
        requirePath = requirePath.Substring(luaScriptIndex);
        requirePath = requirePath.Replace('\\', '.');

        if (_changedLuaFiles != null)
            _changedLuaFiles.Add(requirePath);
    }

    public static void Clear()
    {
        if (_changedLuaFiles != null && _changedLuaFiles.Count != 0)
        {
            _changedLuaFiles.Clear();
        }
    }
}