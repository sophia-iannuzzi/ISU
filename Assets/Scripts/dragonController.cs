using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class dragonController : MonoBehaviour
{

    public GameObject prefab;
    private NavMeshAgent agent;
    private Animator dragonanimatorController;
    private dragonAttack dragonAttack;
    private dragonHealth dragonHealth;
    [SerializeField] private bool chasing;

    public float attackrange;
    public float chaserange;
    private GameObject player;

    private float time;
    private Vector3 ogposition;
    private Quaternion ogrotation;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dragonanimatorController = GetComponent<Animator>();
        dragonAttack = GetComponentInChildren<dragonAttack>();
        dragonHealth = GetComponentInChildren<dragonHealth>();

        ogposition = transform.position;
        ogrotation = transform.rotation;
        time = 0;
        chasing = false;
    }

    void Update()
    {
        if (player != null && player.GetComponent<playerHealth>().death == true)
        {
            Reset();
        }
        if (player != null && chasing == true)
        {
            float distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance <= chaserange)
            {
                if (distance <= attackrange && time > 6)
                {
                    attack();
                }
                else if (dragonanimatorController.GetBool("attackdone") == false)
                {
                    dragonAttack.boxcollider.enabled = false;
                    chase();
                }
                time += Time.deltaTime;
            }
            else
            {
                chasing = false;
            }
        }
    }

    void patrol()
    {
        //choose point to walk to 
    }
    void chase()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance > attackrange)
        {
            dragonanimatorController.SetBool("walking", true);
            agent.SetDestination(player.transform.position);
        }
    }

    void attack()
    {
        dragonanimatorController.SetBool("walking", false);
        agent.SetDestination(transform.position);

        dragonAttack.SetCollider();
        time = 0;
        chasing = false;

        dragonanimatorController.Play("attack");
        dragonanimatorController.SetTrigger("attackdone");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
            if (player == null)
            {
                player = other.gameObject;
            }
            chasing = true;
        }
    }

    void Reset()
    {
        Instantiate(prefab, ogposition, ogrotation);
        Destroy(gameObject);
    }


}
