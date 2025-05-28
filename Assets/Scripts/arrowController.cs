using UnityEngine;

public class arrowController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject arrow;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();

    }

    public void launch()
    {
        Debug.Log("arrow launched");
        // Instantiate(arrow);

    }
}
