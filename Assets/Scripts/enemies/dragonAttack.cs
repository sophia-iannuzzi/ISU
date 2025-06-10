using UnityEngine;

public class dragonAttack : MonoBehaviour
{
    public int damage;
    public Collider boxcollider;

    void Start()
    {
        boxcollider = GetComponent<Collider>();
        boxcollider.enabled = false;
    }

    public void SetCollider()
    {
        boxcollider.enabled = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            other.gameObject.GetComponent<playerHealth>().ChangeHealth(-damage);
            boxcollider.enabled = false;
            Debug.Log("dra att");
        }
    }
}
