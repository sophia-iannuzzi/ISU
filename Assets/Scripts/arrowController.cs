using UnityEngine;

public class arrowController : MonoBehaviour
{

    private GameObject arrow;
    void Start()
    {
        arrow = transform.parent.gameObject;
        Destroy(arrow, 10);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "movementview")
        {
            Destroy(GetComponentInParent<Rigidbody>());
            Destroy(arrow, 4);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Destroy(arrow);
    }
}
