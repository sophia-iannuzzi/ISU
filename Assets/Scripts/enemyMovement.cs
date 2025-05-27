using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool chasing;
    private GameObject player;
    public float speed;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        chasing = false;
    }

    void Update()
    {
        if (chasing == true)
        {
            float movedirectionx = player.transform.position.x - transform.position.x;
            float movedirectionz = player.transform.position.z - transform.position.z;
            Vector3 movedirection = new Vector3(movedirectionx, 0.0f, movedirectionz).normalized;
            rb.linearVelocity = movedirection * speed;
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
            rb.linearVelocity = new Vector3(0, 0, 0);
        }
    }
}
