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
    public GameObject weaponparent;
    private string attack;

    private weaponManager weaponManager;

    void Start()
    {
        rb = character.GetComponent<Rigidbody>();

        playeranimatorController = character.GetComponent<Animator>();

        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        weaponManager = weaponparent.GetComponent<weaponManager>();
        weaponManager.weaponSwitch();
        attack = weaponManager.attackname;
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

        if (playeranimatorController.GetBool(attack) == false)
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
            playeranimatorController.SetBool(attack, true);
            rb.linearVelocity = new Vector3(0, 0, 0);
        }
        else
        {
            playeranimatorController.SetBool(attack, false);
        }
    }
    void OnRotatecam(InputValue mouse)
    {
        if (playeranimatorController.GetBool(attack) == false)
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
