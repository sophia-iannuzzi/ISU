using UnityEngine.AI;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator goblinAnimationController;
    private bool chasing;
    public GameObject player;

    public float speed;
    public float attackrange;

    float movedirectionx;
    void Start()
    {
        goblinAnimationController = GetComponent<Animator>();
        chasing = false;

    }

    void Update()
    {
        if (chasing == true && goblinAnimationController.GetBool("attacking") == false)
        {
            goblinAnimationController.SetBool("walking", true);
            agent.SetDestination(player.transform.position);
            if (Vector2.Distance(player.transform.position, transform.position) < attackrange)
            {
                attack();
            }
        }
        if (player != null && Vector2.Distance(player.transform.position, transform.position) > attackrange)
        {
            goblinAnimationController.SetBool("attacking", false);
        }
    }

    void attack()
    {
        agent.SetDestination(transform.position);
        goblinAnimationController.SetBool("walking", false);
        goblinAnimationController.SetBool("attacking", true);
        goblinAnimationController.Play("attack");
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
