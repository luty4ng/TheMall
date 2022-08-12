using UnityEngine;
using GameKit;

public class GameRegulator : Regulator
{
    public string QuickNextScene;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchSceneByDefault(QuickNextScene);
        }
    }
}