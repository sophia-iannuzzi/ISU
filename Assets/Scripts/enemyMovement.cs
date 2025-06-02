using System;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool chasing;
    public GameObject player;

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
            // movedirectionx = player.transform.position.x - transform.position.x;
            // float movedirectionz = player.transform.position.z - transform.position.z;
            // Vector3 movedirection = new Vector3(movedirectionx, 0.0f, movedirectionz).normalized;
            // rb.linearVelocity = movedirection * speed;
        }
        float thing1 = transform.parent.gameObject.transform.position.x - player.transform.position.x;
        float thing2 = transform.parent.gameObject.transform.position.z - player.transform.position.z;
        Vector2 thing3 = new Vector2(thing1, thing2) * -1;
        transform.parent.gameObject.transform.Rotate(0.0f, thing3.y, 0.0f);
        

        // Quaternion rotation = Quaternion.Euler(0.0f, movedirectionx * 25, 0.0f);
        // float rot = rotation.y + rotation.x;
        // transform.parent.gameObject.transform.Rotate(0.0f, rot, 0.0f);
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
            // GameObject enemyparent = transform.parent.gameObject;
            // float num = tangent((player.transform.position.x + transform.position.x) / (player.transform.position.z + transform.position.z));
            // // enemyparent.transform.Rotate(0.0f, movedirectionx, 0.0f);
            // Debug.Log(num);
             movedirectionx = player.transform.position.x - transform.position.x;
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
