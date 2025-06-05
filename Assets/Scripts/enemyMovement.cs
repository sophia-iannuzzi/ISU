using UnityEngine.AI;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator goblinAnimationController;
    private dragonAttack dragonAttack;
    [SerializeField] private bool chasing;
    public GameObject player;

    public float speed;
    public float attackrange;

    float movedirectionx;


    void Start()
    {
        goblinAnimationController = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        dragonAttack = GetComponentInChildren<dragonAttack>();
        chasing = false;

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
        else if (chasing != true)
        {
            patrol();
        }
    }

    void attack()
    {
        // dragonAttack.attack();
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
        agent.SetDestination(newpos);
        goblinAnimationController.SetBool("walking", true);
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
