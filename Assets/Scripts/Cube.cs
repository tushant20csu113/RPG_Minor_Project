using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour,IInteractables
{
    private bool isPicked;
    public bool CanInteract()
    {
        return !isPicked;
    }

    public void Interact()
    {
        isPicked = true;
        Destroy(gameObject);
        Debug.Log("Cube picked");
    }
}
