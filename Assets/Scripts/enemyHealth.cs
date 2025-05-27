using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;

    private GameObject parentholder;
    private GameObject coin;

    void Start()
    {
        parentholder = transform.parent.gameObject;
        coin = parentholder.transform.GetChild(0).gameObject;
        coin.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            Debug.Log("bad hit");
            
            currenthealth += other.GetComponentInParent<weaponManager>().damage;
        }
        if (currenthealth <= 0)
        {
            Debug.Log("bad dead");
            // parentholder.transform.GetChild(1).gameObject.SetActive(false);
            // parentholder.transform.GetChild(2).gameObject.SetActive(false);
            // parentholder.meshRenderer.SetActive(false);
            // coin.SetActive(true);
        }
    }
}
