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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playeranimatorController = GetComponent<Animator>();
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

        rb.linearVelocity = movementvelocity;
    }

    void Update()
    {
        if (moveAction.IsPressed())
        {
            playeranimatorController.SetBool("move", true);
        }
        else
        {
            playeranimatorController.SetBool("move", false);
        }
        // if (attackAction.IsPressed())
        // {
        //     playeranimatorController.SetBool("attack", true);
        // }
        // else
        // {
        //     playeranimatorController.SetBool("attack", false);
        // }
    }
    void OnRotatecam(InputValue mouse)
    {
        Vector2 mousemovement = mouse.Get<Vector2>();
        float movex = mousemovement.x;
        cameraobject.transform.Rotate(0.0f, movex, 0.0f);
        transform.Rotate(0.0f, movex, 0.0f);

        movedirection = cameraobject.transform.forward * movementy;
        movedirection = movedirection + cameraobject.transform.right * movementx;
        movedirection.Normalize();
        movementvelocity = movedirection * speed;

        rb.linearVelocity = movementvelocity;
    }

}
