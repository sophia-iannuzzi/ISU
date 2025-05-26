using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;
    public GameObject weaponparent;

    private weaponManager weaponManager;

    void Start()
    {
        weaponManager = weaponparent.GetComponent<weaponManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            Debug.Log("bad hit");
            currenthealth += weaponManager.damage;
        }
        if (currenthealth < 0)
        {
            Debug.Log("dead bad");
        }
    }
}
