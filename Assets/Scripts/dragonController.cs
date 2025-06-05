using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class dragonController : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator dragonanimatorController;
    [SerializeField] private bool chasing;

    private bool attacking;
    public float attackrange;
    public float chaserange;
    private GameObject player;

    private float time;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dragonanimatorController = GetComponent<Animator>();
        time = 0;
        chasing = false;
        attacking = false;
    }

    void Update()
    {
        if (player != null)
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
                    chase();
                }
                time += Time.deltaTime;
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
        time = 0;

        agent.SetDestination(transform.position);

        dragonanimatorController.Play("attack");
        dragonanimatorController.SetTrigger("attackdone");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            if (player == null)
            {
                player = other.gameObject;
            }
        }
    }
}
