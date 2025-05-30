using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction attackAction;

    private Rigidbody rb;
    private GameObject parentholder;

    public GameObject arrow;
    public GameObject arrowspot;
    private Vector3 position;
    private arrowController arrowController;

    private Vector2 movement;
    private Vector3 movementvelocity;
    private float movementx;
    private float movementy;

    private Vector3 movedirection;

    public int speed;
    public GameObject cameraobject;

    private Animator playeranimatorController;
    public GameObject weaponparent;
    private string attack;

    private weaponManager weaponManager;
    private playerInventory playerInventory;

    void Start()
    {
    
        rb = GetComponentInParent<Rigidbody>();
        parentholder = transform.parent.gameObject; ;

        playeranimatorController = GetComponentInParent<Animator>();
        arrowController = arrow.GetComponent<arrowController>();

        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        weaponManager = weaponparent.GetComponent<weaponManager>();
        playerInventory = GetComponentInParent<playerInventory>();

        attack = weaponManager.attackname;
    }

    public void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();
        movementx = movement.x;
        movementy = movement.y;

        playeranimatorController.SetBool("walking", true);
    }



    void Update()
    {

        if (playeranimatorController.GetBool("attackover") == false)
        {
            Vector3 cameradirectionforward = new Vector3(cameraobject.transform.forward.x, 0.0f, cameraobject.transform.forward.z).normalized;
            Vector3 cameradirectionright = new Vector3(cameraobject.transform.right.x, 0.0f, cameraobject.transform.right.z).normalized;
            movedirection = cameradirectionright * movementx + cameradirectionforward * movementy;

            Vector3 movementvelocity = movedirection * speed;
            rb.linearVelocity = movementvelocity;
        }
        else
        {
            rb.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            ;
        }

        if (moveAction.IsPressed())
        {
            playeranimatorController.SetBool("walking", true);
        }
        else
        {
            playeranimatorController.SetBool("walking", false);
        }
    }
    void OnRotatecam(InputValue mouse)
    {
        if (playeranimatorController.GetBool("attackover") == false)
        {
            Vector2 mousemovement = mouse.Get<Vector2>();
            float movex = mousemovement.x;
            cameraobject.transform.Rotate(0.0f, movex, 0.0f);
            parentholder.transform.Rotate(0.0f, movex, 0.0f);

            movedirection = cameraobject.transform.forward * movementy;
            movedirection = movedirection + cameraobject.transform.right * movementx;
            movedirection.Normalize();
            movementvelocity = movedirection * speed;
            rb.linearVelocity = movementvelocity;
        }
        if (playeranimatorController.GetBool("aiming") == true)
        {
            Vector2 mousemovement = mouse.Get<Vector2>();
            float movex = mousemovement.x;
            cameraobject.transform.Rotate(0.0f, movex, 0.0f);
            parentholder.transform.Rotate(0.0f, movex, 0.0f);
        }
    }

    void OnAttack()
    {
        playeranimatorController.SetBool("walking", false);
        if (attack == "bow")
        {
            if (playeranimatorController.GetBool("aiming") == false)
            {
                playeranimatorController.Play("drawbow");
                playeranimatorController.SetBool("aiming", true);

            }
            else
            {
                Vector3 arrowoff = arrowspot.transform.position + new Vector3(0, 0.2f, 0);
                GameObject shotarrow = Instantiate(arrow, arrowoff, cameraobject.transform.rotation);

                playeranimatorController.SetBool("aiming", false);
                playeranimatorController.SetTrigger("attackover");
                shotarrow.GetComponent<Rigidbody>().AddForce(cameraobject.transform.forward.normalized * 500f);

            }
        }
        else
        {
            playeranimatorController.Play(attack + "attack");
        }
        playeranimatorController.SetTrigger("attackover");
    }
    void OnWeaponswitch()
    {
        if (playeranimatorController.GetBool("attackover") == false)
        {
            weaponManager.WeaponSwitch();
            attack = weaponManager.attackname;
        }
    }

    void OnPotionuse()
    {
        playerInventory.healthuse();
    }
}
