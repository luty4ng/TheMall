#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
public static class ScenesList
{
    [MenuItem("Scenes/Charpter1")]
    public static void Assets_GameMain_Scenes_Charpter1_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter1.unity"); }
    [MenuItem("Scenes/Charpter2_ComingSoonCG")]
    public static void Assets_GameMain_Scenes_Charpter2_ComingSoonCG_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter2_ComingSoonCG.unity"); }
    [MenuItem("Scenes/Charpter_StartCG")]
    public static void Assets_GameMain_Scenes_Charpter_StartCG_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter_StartCG.unity"); }
    [MenuItem("Scenes/GameKit_Launcher")]
    public static void Assets_GameMain_Scenes_GameKit_Launcher_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/GameKit_Launcher.unity"); }
    [MenuItem("Scenes/GameMain")]
    public static void Assets_GameMain_Scenes_GameMain_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/GameMain.unity"); }
}
#endif
