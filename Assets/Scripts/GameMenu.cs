using UnityEngine;
using UnityEditor;

public class GameMenu : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("HotUpdate/HotUpdateInRuntime %#h")]
    public static void HotUpdateInRuntime()
    {
        foreach (var file in HotUpdateUtility.ChangedLuaFiles)
        {
            UELuaMain.Get().HotUpdate(file);
        }
        
        HotUpdateUtility.Clear();
    }
#endif
}