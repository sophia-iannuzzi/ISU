using UnityEngine;

public class dragonAttack : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            other.gameObject.GetComponent<playerHealth>().ChangeHealth(-damage);
        }
    }
}
