using UnityEngine;

public class dragonHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;
    private GameObject parentHolder;
    void Start()
    {
        parentHolder = transform.parent.gameObject;
        currenthealth = maxhealth;
    }

    void Update()
    {
        if (currenthealth <= 0)
        {
            Destroy(parentHolder);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            Debug.Log("fdfdf");
            currenthealth += other.GetComponentInParent<weaponManager>().damage;
        }
        if (other.tag == "arrow")
        {
            currenthealth += -1;
        }
    }
}
