using UnityEngine;

public class gateController : MonoBehaviour
{
    public GameObject player;
    private bool gateopen = false;
    void Update()
    {
        if (player.GetComponent<playerInventory>().money >= 1 && gateopen == false)
        {
            opengate();
        }
    }

    void opengate()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.SetActive(false);
    }
}
