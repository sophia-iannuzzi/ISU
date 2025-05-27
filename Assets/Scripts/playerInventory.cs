using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerInventory : MonoBehaviour
{
    public int money;
    public int healthpotion;
    public TextMeshProUGUI moneytext;

    private playerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<playerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            Debug.Log("coin picup");
            Destroy(other.gameObject);
            money++;
            moneytext.text = "Money: " + money;
        }
    }

    public void healthuse()
    {
        if (healthpotion > 0 && playerHealth.currenthealth < playerHealth.maxhealth)
        {
            Debug.Log("use health");
            healthpotion = healthpotion - 1;
            playerHealth.ChangeHealth(1);
        }
    }
}
