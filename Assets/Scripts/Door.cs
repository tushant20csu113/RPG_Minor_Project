using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    private bool isDoorOpen;
    private Animator doorAnimator;
 
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = transform.GetComponent<Animator>();
    }
    public bool CanInteract()
    {
        return !isDoorOpen;
    }

    public void Interact()
    {
        isDoorOpen = true;
        doorAnimator.SetTrigger("OpenDoor");
    }
    public ObjectType Type()
    {
        return ObjectType.DOOR;
    }
}
