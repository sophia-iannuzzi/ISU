using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction attackAction;
    public bool speedused;

    private Rigidbody rb;
    private GameObject parentholder;

    public GameObject arrow;
    public GameObject arrowspot;

    private Vector2 movement;
    public Vector3 movementvelocity;
    private float movementx;
    private float movementy;

    private Vector3 movedirection;

    public int speed;
    public int startspeed;
    public GameObject cameraobject;

    private Animator playeranimatorController;
    public GameObject weaponparent;
    public float arrowspeed;
    private string attack;

    [SerializeField] private AudioClip attacksound;


    private weaponManager weaponManager;
    private playerInventory playerInventory;
    private float time;

    public bool death;

    void Start()
    {
        Cursor.visible = false;

        startspeed = speed;
        rb = GetComponentInParent<Rigidbody>();
        parentholder = transform.parent.gameObject; ;

        playeranimatorController = GetComponentInParent<Animator>();

        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        weaponManager = weaponparent.GetComponent<weaponManager>();
        playerInventory = GetComponentInParent<playerInventory>();

        attack = weaponManager.attackname;

        speedused = false;
        death = false;
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
        if (speedused == true)
        {
            time += Time.deltaTime;
            if (time > 3)
            {
                time = 0;
                speed = startspeed;
                speedused = false;
            }
        }
        if (playeranimatorController.GetBool("attackover") == false && death == false)
        {
            weaponManager.currentweapon.GetComponent<Collider>().enabled = false;
            Vector3 cameradirectionforward = new Vector3(cameraobject.transform.forward.x, 0.0f, cameraobject.transform.forward.z).normalized;
            Vector3 cameradirectionright = new Vector3(cameraobject.transform.right.x, 0.0f, cameraobject.transform.right.z).normalized;
            movedirection = cameradirectionright * movementx + cameradirectionforward * movementy;

            Vector3 movementvelocity = movedirection * speed;
            rb.linearVelocity = movementvelocity;
        }
        else
        {
            rb.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
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
        if (playeranimatorController.GetBool("attackover") == false && death == false)
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
            if (playerInventory.arrows > 0)
            {
                if (playeranimatorController.GetBool("aiming") == false)
                {
                    playeranimatorController.Play("drawbow");
                    playeranimatorController.SetBool("aiming", true);

                    playeranimatorController.SetTrigger("attackover");

                }
                else
                {
                    Vector3 arrowoff = arrowspot.transform.position + new Vector3(0, 0.2f, 0);
                    GameObject shotarrow = Instantiate(arrow, arrowoff, cameraobject.transform.rotation);

                    playeranimatorController.SetBool("aiming", false);
                    shotarrow.GetComponent<Rigidbody>().AddForce(cameraobject.transform.forward.normalized * arrowspeed);

                    playerInventory.arrowchange(-1);
                }
            }
        }
        else
        {
            weaponManager.currentweapon.GetComponent<Collider>().enabled = true;
            playeranimatorController.Play(attack + "attack");
            playeranimatorController.SetTrigger("attackover");

            soundFXmanager.instance.playsoundeffect(attacksound, transform);
        }
    }
    void OnWeaponswitch()
    {
        if (playeranimatorController.GetBool("attackover") == false)
        {
            weaponManager.WeaponSwitch();
            attack = weaponManager.attackname;
        }
    }

    void OnHealthuse()
    {
        playerInventory.healthuse();
    }

    void OnSpeeduse()
    {
        speedused = true;
        playerInventory.speeduse();
        speed = playerInventory.speed;
    }

    public void deathtrue()
    {
        death = true;
    }

    public void deathfalse()
    {
        playeranimatorController.SetBool("walking", false);
        death = false;
    }
}
