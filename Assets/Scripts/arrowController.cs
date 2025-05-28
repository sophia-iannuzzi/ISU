using UnityEngine;

public class arrowController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject arrow;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void launch()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("arrow launched");
        rb.AddForce(0.0f, 10, 0.0f);

    }
}
