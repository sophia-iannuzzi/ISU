using UnityEngine;

public class gateController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private bool gateopen;

    void Start()
    {
        gateopen = false;
    }
    void Update()
    {
        if (player == null && GameObject.Find("player"))
        {
            player = GameObject.Find("player");
        }

        if (player != null && player.GetComponent<playerInventory>().money >= 15 && gateopen == false)
            {
                opengate();
            }

    }

    void opengate()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gateopen = true;
    }
}
