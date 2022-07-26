using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecretErase : MonoBehaviour
{
    public int unlockPoint = 0;
    public UnityEvent AfterAchieved;
    public int GoalPoint = 3;
public void conditionProgressed()
    {
        unlockPoint = unlockPoint += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockPoint >= GoalPoint) AfterAchieved?.Invoke();
    }
}
