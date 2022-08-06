#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
public static class ScenesList
{
    [MenuItem("Scenes/Charpter1")]
    public static void Assets_GameMain_Scenes_Charpter1_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter1.unity"); }
    [MenuItem("Scenes/Charpter2")]
    public static void Assets_GameMain_Scenes_Charpter2_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter2.unity"); }
    [MenuItem("Scenes/DialogSystem_Prototype")]
    public static void Assets_GameMain_Scenes_DialogSystem_Prototype_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/DialogSystem_Prototype.unity"); }
    [MenuItem("Scenes/Part2")]
    public static void Assets_GameMain_Scenes_Part2_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Part2.unity"); }
    [MenuItem("Scenes/SpriteMask_Prototype")]
    public static void Assets_GameMain_Scenes_SpriteMask_Prototype_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SpriteMask_Prototype.unity"); }
}
#endif
