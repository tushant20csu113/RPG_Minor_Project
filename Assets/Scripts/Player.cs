using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;
    private Animator playerAnimator;
    private CharacterController player;
    public float interactionDistance;


    private float forwardMovement;
    private float rotationMovement;
    private Vector3 direction;
    private bool isRunning;
    private bool isRunningBackward;
    Camera cam;

    public static event Action<string> keyPickUp = delegate { };
    public static Player Instance { get;private set;}
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        player = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
 
    }

    // Update is called once per frame
    void Update()
    {
        forwardMovement = Input.GetAxis("Vertical");
        rotationMovement = Input.GetAxis("Horizontal");
      
        direction = transform.forward;
        //direction.z=forwardMovement;
        player.SimpleMove(direction *forwardMovement* moveSpeed);
        player.transform.Rotate(Vector3.up * rotationSpeed * rotationMovement * Time.deltaTime);
        //Debug.Log("Velocity " + transform.InverseTransformDirection(player.velocity).z);
        if (transform.InverseTransformDirection(player.velocity).z > 0 && !isRunning && !isRunningBackward)
        {
            isRunning = true;
            playerAnimator.SetBool("isRunning", true);
        }
        else if(transform.InverseTransformDirection(player.velocity).z < 0 && !isRunningBackward && !isRunning)
        {
            isRunningBackward = true;
            playerAnimator.SetBool("isRunningBackward", true);
        }
        else if (transform.InverseTransformDirection(player.velocity).z == 0 && (isRunning || isRunningBackward))
        {
            isRunning = false;
            isRunningBackward = false;
            playerAnimator.SetBool("isRunningBackward", false);
            playerAnimator.SetBool("isRunning", false);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            ObjectInteract();
        }
    }
    void ObjectInteract()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
                if(interactable.objectType()=="Key")
                   keyPickUp("KeyPicked");
            }
        }

    }
}
