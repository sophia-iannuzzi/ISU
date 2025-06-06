using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;

    private float deathtimer;

    private GameObject parentholder;
    public GameObject coin;

    void Start()
    {
        parentholder = transform.parent.gameObject;
        deathtimer = 0;
    }

    void Update()
    {
        if (currenthealth <= 0)
        {
            transform.parent.gameObject.transform.Find("badmovement").GetComponent<Collider>().enabled = false;
            if (deathtimer == 0)
            {
                GetComponentInParent<Animator>().Play("death");
            }
            if (deathtimer > 3)
            {
                death();
            }
            deathtimer += Time.deltaTime;
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

    void death()
    {
        Destroy(parentholder);
        Instantiate(coin, transform.position, transform.rotation);
    }
}
