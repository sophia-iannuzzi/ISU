using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;

    private GameObject parentholder;
    public GameObject coin;

    void Start()
    {
        parentholder = transform.parent.gameObject;
    }

    void Update()
    {
        if (currenthealth <= 0)
        {
            Debug.Log("bad dead");
            Destroy(parentholder);
            Instantiate(coin, transform.position, transform.rotation);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            Debug.Log("bad hit");
            currenthealth += other.GetComponentInParent<weaponManager>().damage;
        }
        if (other.tag == "arrow")
        {
            Debug.Log("bad arrow hit");
            currenthealth += -1;
        }
    }
}
