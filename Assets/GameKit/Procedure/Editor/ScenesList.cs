#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
public static class ScenesList
{
    [MenuItem("Scenes/GameKitDemo_Fsm")]
    public static void Assets_GameKit_Fsm_Demo_GameKitDemo_Fsm_unity() { ScenesUpdate.OpenScene("Assets/GameKit/Fsm/Demo/GameKitDemo_Fsm.unity"); }
    [MenuItem("Scenes/GameKitDemo_ObjectPool")]
    public static void Assets_GameKit_ObjectPool_Demo_GameKitDemo_ObjectPool_unity() { ScenesUpdate.OpenScene("Assets/GameKit/ObjectPool/Demo/GameKitDemo_ObjectPool.unity"); }
    [MenuItem("Scenes/GameKit_Launcher")]
    public static void Assets_GameKit_Procedure_Demo_GameKit_Launcher_unity() { ScenesUpdate.OpenScene("Assets/GameKit/Procedure/Demo/GameKit_Launcher.unity"); }
    [MenuItem("Scenes/GameKitDemo_Loading")]
    public static void Assets_GameKit_Procedure_Demo_GameKitDemo_Loading_unity() { ScenesUpdate.OpenScene("Assets/GameKit/Procedure/Demo/GameKitDemo_Loading.unity"); }
    [MenuItem("Scenes/GameKitDemo_Main")]
    public static void Assets_GameKit_Procedure_Demo_GameKitDemo_Main_unity() { ScenesUpdate.OpenScene("Assets/GameKit/Procedure/Demo/GameKitDemo_Main.unity"); }
    [MenuItem("Scenes/Attributes")]
    public static void Assets_GameKit_QuickDev_Attributes_Attributes_unity() { ScenesUpdate.OpenScene("Assets/GameKit/QuickDev/Attributes/Attributes.unity"); }
    [MenuItem("Scenes/MyDotween")]
    public static void Assets_GameKit_QuickDev_MyDotween_MyDotween_unity() { ScenesUpdate.OpenScene("Assets/GameKit/QuickDev/MyDotween/MyDotween.unity"); }
    [MenuItem("Scenes/Demo_UI")]
    public static void Assets_GameKit_QuickDev_UGUI_TabGroup_Demo_Demo_UI_unity() { ScenesUpdate.OpenScene("Assets/GameKit/QuickDev/UGUI/TabGroup/Demo/Demo_UI.unity"); }
    [MenuItem("Scenes/GameKitDemo_ReferencePool")]
    public static void Assets_GameKit_ReferencePool_Demo_GameKitDemo_ReferencePool_unity() { ScenesUpdate.OpenScene("Assets/GameKit/ReferencePool/Demo/GameKitDemo_ReferencePool.unity"); }
    [MenuItem("Scenes/Demo")]
    public static void Assets_GameMain_Arts_UI_Icons_40_Simple_Icons_Free_Scenes_Demo_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Arts/UI_Icons/40-Simple Icons-Free/Scenes/Demo.unity"); }
    [MenuItem("Scenes/Shop_Prototype")]
    public static void Assets_GameMain_Core_Shop_Shop_Prototype_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Core/Shop/Shop_Prototype.unity"); }
    [MenuItem("Scenes/Charpter1")]
    public static void Assets_GameMain_Scenes_Charpter1_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter1.unity"); }
    [MenuItem("Scenes/Charpter2")]
    public static void Assets_GameMain_Scenes_Charpter2_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter2.unity"); }
    [MenuItem("Scenes/Charpter3")]
    public static void Assets_GameMain_Scenes_Charpter3_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/Charpter3.unity"); }
    [MenuItem("Scenes/DialogSystem_Prototype")]
    public static void Assets_GameMain_Scenes_DialogSystem_Prototype_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/DialogSystem_Prototype.unity"); }
    [MenuItem("Scenes/SpriteMask_Prototype")]
    public static void Assets_GameMain_Scenes_SpriteMask_Prototype_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SpriteMask_Prototype.unity"); }
}
#endif
