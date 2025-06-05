using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class dragonController : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator dragonanimatorController;
    private dragonAttack dragonAttack;
    [SerializeField] private bool chasing;

    public float attackrange;
    public float chaserange;
    private GameObject player;

    private float time;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dragonanimatorController = GetComponent<Animator>();
        dragonAttack = GetComponentInChildren<dragonAttack>();
        time = 0;
        chasing = false;
    }

    void Update()
    {
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
        dragonAttack.SetCollider();
        time = 0;
        chasing = false;

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
            chasing = true;
        }
    }
}
