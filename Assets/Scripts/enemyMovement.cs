using System;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool chasing;
    private GameObject player;

    // public GameObject enemyparent;
    public float speed;

    float movedirectionx;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        chasing = false;
    }

    void Update()
    {
        if (chasing == true)
        {
            movedirectionx = player.transform.position.x - transform.position.x;
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
            // chasing = true;
            // movedirectionx = player.transform.position.x - transform.position.x;
            // GameObject enemyparent = transform.parent.gameObject;
            // float num = tangent((player.transform.position.x + transform.position.x) / (player.transform.position.z + transform.position.z));
            // // enemyparent.transform.Rotate(0.0f, movedirectionx, 0.0f);
            // Debug.Log(num);
        }
    }

    private float TangentControl(float v)
    {
        throw new NotImplementedException();
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
