using UnityEngine;
using UnityEngine.AI;

public class frogController : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject win;
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("player");
        Instantiate(win);
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
