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
    private Transform currentspot;
    private GameObject player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        dragonanimatorController = GetComponent<Animator>();
        chasing = false;
        attacking = false;
    }

    void Update()
    {
        if (chasing == true)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < attackrange && attacking == false)
            {
                transform.LookAt(player.transform);
                currentspot = player.transform;
                attack();
            }
            else if (attacking == true)
            {
                transform.LookAt(currentspot);
            }
            else
            {
                chase();
            }
        }

    }

    void patrol()
    {
        //choose point to walk to 
    }
    void chase()
    {
        dragonanimatorController.SetBool("walking", true);
        agent.SetDestination(player.transform.position);
    }

    void attack()
    {
        attacking = true;
        
        agent.SetDestination(transform.position);
        transform.LookAt(currentspot);
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
            Debug.Log("en");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            dragonanimatorController.SetBool("walking", false);
            chasing = false;
        }
    }
}
