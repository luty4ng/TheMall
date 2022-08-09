#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
public static class ScenesList
{
    [MenuItem("Scenes/Charpter1 1")]
    public static void Assets_GameMain_Scenes_Charpter1_1_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter1 1.unity"); }
    [MenuItem("Scenes/Charpter1 2")]
    public static void Assets_GameMain_Scenes_Charpter1_2_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter1 2.unity"); }
    [MenuItem("Scenes/Charpter1")]
    public static void Assets_GameMain_Scenes_Charpter1_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter1.unity"); }
    [MenuItem("Scenes/Charpter2")]
    public static void Assets_GameMain_Scenes_Charpter2_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter2.unity"); }
    [MenuItem("Scenes/Charpter3")]
    public static void Assets_GameMain_Scenes_Charpter3_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter3.unity"); }
    [MenuItem("Scenes/Charpter4")]
    public static void Assets_GameMain_Scenes_Charpter4_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter4.unity"); }
    [MenuItem("Scenes/Charpter_StartCG")]
    public static void Assets_GameMain_Scenes_Charpter_StartCG_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter_StartCG.unity"); }
    [MenuItem("Scenes/DialogSystem_Prototype")]
    public static void Assets_GameMain_Scenes_DialogSystem_Prototype_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/DialogSystem_Prototype.unity"); }
    [MenuItem("Scenes/GameKit_Launcher")]
    public static void Assets_GameMain_Scenes_GameKit_Launcher_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/GameKit_Launcher.unity"); }
    [MenuItem("Scenes/GameMain")]
    public static void Assets_GameMain_Scenes_GameMain_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/GameMain.unity"); }
    [MenuItem("Scenes/SpriteMask_Prototype")]
    public static void Assets_GameMain_Scenes_SpriteMask_Prototype_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SpriteMask_Prototype.unity"); }
}
#endif
