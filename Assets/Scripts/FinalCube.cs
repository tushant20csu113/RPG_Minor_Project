using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCube : MonoBehaviour,IInteractables
{
    private bool isPicked;
    public bool CanInteract()
    {
        return !isPicked;
    }

    public void Interact()
    {
        isPicked = true;
        MissionProgress.keyCount++;
        MissionProgress.missionText = "Mission Passed";
        Destroy(gameObject);    
    }
}
