using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Debug.Log("player hit");
            other.gameObject.GetComponent<playerHealth>().ChangeHealth(damage);
        }
    }

    void DoDamage()
    {

    }
}
