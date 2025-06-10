using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;

public class enemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator goblinAnimationController;
    private dragonAttack dragonAttack;
    private Vector3 start;
    public bool chasing;
    public bool death;
    public GameObject player;
    public float attackrange;

    float movedirectionx;


    void Start()
    {
        goblinAnimationController = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        start = transform.position;
        dragonAttack = GetComponentInChildren<dragonAttack>();
        chasing = false;
        death = false;

    }

    void Update()
    {
        if (chasing == true && goblinAnimationController.GetBool("attackdone") == false)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < attackrange)
            {
                attack();
            }
            else
            {
                goblinAnimationController.SetBool("walking", true);
                agent.SetDestination(player.transform.position);
            }
        }
        else if (chasing == false && death == false)
        {
            patrol();
        }
    }

    void attack()
    {
        agent.SetDestination(transform.position);
        goblinAnimationController.SetBool("walking", true);
        goblinAnimationController.SetTrigger("attackdone");
        goblinAnimationController.Play("attack");
    }

    void patrol()
    {
        float numx = Random.Range(-10, 10);
        float numz = Random.Range(-10, 10);
        Vector3 newpos = new Vector3(transform.position.x + numx, 0.0f, transform.position.z + numz);
        if (Vector2.Distance(newpos, start) < 10)
        {
            agent.SetDestination(newpos);
            goblinAnimationController.SetBool("walking", true);
        }
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

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            chasing = false;
            agent.SetDestination(transform.position);
            goblinAnimationController.SetBool("walking", false);
        }
    }
}
