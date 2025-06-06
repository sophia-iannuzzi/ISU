using UnityEngine;

public class dragonHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;
    private float deathtimer;
    private bool deathneed;
    private Animator dragonanimatorController;
    private GameObject parentHolder;
    void Start()
    {
        parentHolder = transform.parent.gameObject;
        dragonanimatorController = parentHolder.GetComponent<Animator>();

        currenthealth = maxhealth;
        deathtimer = 0;
        deathneed = true;
    }

    void Update()
    {
        if (currenthealth <= 0)
        {
            if (deathneed == true)
            {
                dragonanimatorController.Play("death");
                deathneed = false;
            }
            dragonanimatorController.Play("death");
            if (deathtimer > 5)
            {
                dragondeath();
            }
            deathtimer += Time.deltaTime;
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

    void dragondeath()
    {
        Destroy(parentHolder);
    }

    public void resetHealth()
    {
        currenthealth = maxhealth;
    }
}
