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
    public TextMeshProUGUI speedpotiontext;
    public TextMeshProUGUI healthpotiontext;
    public TextMeshProUGUI arrowtext;
    public TextMeshProUGUI warningtext;
    private bool warningon;
    private float warningtime;

    private playerHealth playerHealth;
    private playerController playerController;

    [SerializeField] AudioClip healsound;
    [SerializeField] AudioClip speedsound;
    [SerializeField] AudioClip moneysound;

    void Start()
    {
        playerHealth = GetComponent<playerHealth>();
        playerController = GetComponentInParent<playerController>();

        healthpotion = 0;
        speedpotion = 0;
        money = 0;
        arrows = 0;
        moneytext.text = "" + money;

        warningtext.transform.parent.gameObject.SetActive(false);
        warningon = false;
        warningtime = 0;
    }

    void Update()
    {
        moneytext.text = "" + money;
        speedpotiontext.text = "" + speedpotion;
        healthpotiontext.text = "" + healthpotion;
        arrowtext.text = "" + arrows;

        if (warningon == true)
        {
            if (warningtime > 3)
            {
                warningtext.transform.parent.gameObject.SetActive(false);
                warningtime = 0;
                warningon = false;
            }
            else
            {
                warningtime += Time.deltaTime;
            }
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            Destroy(other.gameObject);
            money++;
            moneytext.text = "" + money;
            soundFXmanager.instance.playsoundeffect(moneysound, transform);
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
                warning("not enough money");
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
                warning("not enough money");
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
        if (healthpotion > 0)
        {
            if (playerHealth.currenthealth < playerHealth.maxhealth)
            {
                soundFXmanager.instance.playsoundeffect(healsound, transform);
                healthpotion = healthpotion - 1;
                playerHealth.ChangeHealth(1);
            }
            else
            {
                warning("max health");
            }
        }
        else
        {
            warning("no potions");
        }
    }

    public void speeduse()
    {
        if (speedpotion > 0)
        {
            soundFXmanager.instance.playsoundeffect(speedsound, transform);
            speed = 10;
            speedpotion -= 1;
        }
        else
        {
            warning("no potions");
            speed = 5;
        }
    }

    public void arrowchange(int amount)
    {
        arrows += amount;
    }

    void warning(string warning)
    {
        warningtext.text = warning;
        warningtext.transform.parent.gameObject.SetActive(true);
        warningon = true;
        warningtime = 0;
    }
}
