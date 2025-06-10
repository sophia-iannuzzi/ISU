using UnityEngine;

public class dragonHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;
    private float deathtimer;
    public bool deathneed;
    private Animator dragonanimatorController;
    private GameObject parentHolder;
    public GameObject frogobject;
    private Transform transformfrog;
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
                transformfrog = parentHolder.transform;
                dragonanimatorController.Play("death");
                deathneed = false;
            }
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
        transformfrog.position = new Vector3(transformfrog.position.x, 1, transformfrog.position.z);
        Destroy(parentHolder);
        Instantiate(frogobject, transformfrog.position, transformfrog.rotation);
    }

    public void resetHealth()
    {
        currenthealth = maxhealth;
    }
}
