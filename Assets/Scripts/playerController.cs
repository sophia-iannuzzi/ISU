using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    private InputAction moveAction;
    private InputAction attackAction;

    private Rigidbody rb;
    private Vector2 movement;
    private Vector3 movementvelocity;
    private float movementx;
    private float movementy;

    private Vector3 movedirection;

    public int speed;
    public GameObject cameraobject;

    private Animator playeranimatorController;
    public GameObject character;

    void Start()
    {
        rb = character.GetComponent<Rigidbody>();

        playeranimatorController = character.GetComponent<Animator>();

        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

    }


    void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();
        movementx = movement.x;
        movementy = movement.y;

        movedirection = cameraobject.transform.forward * movementy;
        movedirection = movedirection + cameraobject.transform.right * movementx;
        movedirection.Normalize();
        Vector3 movementvelocity = movedirection * speed;

        if (playeranimatorController.GetBool("sword") == false)
        {
            rb.linearVelocity = movementvelocity;
        }
    }


    void Update()
    {
        if (moveAction.IsPressed())
        {
            playeranimatorController.SetBool("walking", true);
        }
        else
        {
            playeranimatorController.SetBool("walking", false);
        }
        if (attackAction.IsPressed())
        {
            playeranimatorController.SetBool("sword", true);
            rb.linearVelocity = new Vector3(0, 0, 0);
        }
        else
        {
            playeranimatorController.SetBool("sword", false);
        }
    }
    void OnRotatecam(InputValue mouse)
    {
        if (playeranimatorController.GetBool("sword") == false)
        {
            Vector2 mousemovement = mouse.Get<Vector2>();
            float movex = mousemovement.x;
            cameraobject.transform.Rotate(0.0f, movex, 0.0f);
            character.transform.Rotate(0.0f, movex, 0.0f);

            movedirection = cameraobject.transform.forward * movementy;
            movedirection = movedirection + cameraobject.transform.right * movementx;
            movedirection.Normalize();
            movementvelocity = movedirection * speed;
            rb.linearVelocity = movementvelocity;
        }
    }

}
