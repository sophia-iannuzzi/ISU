using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class playerInventory : MonoBehaviour
{
    public int money;
    public int healthpotion;
    public int speedpotion;
    public int arrows;
    public int potioncost;
    public int speed;
    public TextMeshProUGUI moneytext;

    private playerHealth playerHealth;
    private playerController playerController;

    void Start()
    {
        playerHealth = GetComponent<playerHealth>();
        playerController = GetComponentInParent<playerController>();

        moneytext.text = "Money: " + money;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            Destroy(other.gameObject);
            money++;
            moneytext.text = "Money: " + money;
        }
        if (other.tag == "healthpotion")
        {
            if (money >= potioncost)
            {
                Destroy(other.gameObject);
                healthpotion++;
                money -= potioncost;
            }
            else
            {
                Debug.Log("not enough money");
            }
        }
        if (other.tag == "speedpotion")
        {
            if (money >= potioncost)
            {
                Destroy(other.gameObject);
                speedpotion++;
                money -= potioncost;
            }
            else
            {
                Debug.Log("not enough money");
            }
        }
        if (other.tag == "arrowitem")
        {
            Destroy(other.gameObject);
            arrowchange(1);
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

    public void speeduse()
    {
        if (speedpotion > 0)
        {
            Debug.Log("speed");
            speed = 10;
            speedpotion -= 1;
        }
        else
        {
            speed = 5;
        }
    }

    public void arrowchange(int amount)
    {
        arrows += amount;
    }
}
