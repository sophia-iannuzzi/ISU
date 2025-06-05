using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public int damage;

    public void SetCollider()
    {
        // gameObject.GetComponent<Collider>().SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Debug.Log("player hit");
            other.gameObject.GetComponent<playerHealth>().ChangeHealth(-damage);
        }
    }
}
