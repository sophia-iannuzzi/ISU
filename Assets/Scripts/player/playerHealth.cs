using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.InputSystem;

public class playerHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;
    public float deathtimer;
    public bool death;
    public TextMeshProUGUI mainText;
    public Image pic;

    void Start()
    {
        mainText.text = "5";
        deathtimer = 0;
        death = false;
    }

    void Update()
    {
        if (death == true)
        {
            gameObject.GetComponentInChildren<PlayerInput>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponentInChildren<playerController>().deathtrue();

            gameObject.GetComponent<Animator>().Play("death");
            if (deathtimer > 3)
            {
                playerDeath();
            }
            deathtimer += Time.deltaTime;
        }
        if (currenthealth <= 0)
        {
            mainText.text = "0";
            death = true;
        }
    }

    public void ChangeHealth(int amount)
    {
        currenthealth = currenthealth + amount;
        mainText.text = "" + currenthealth;
    }

    void playerDeath()
    {

        gameObject.GetComponentInChildren<playerController>().deathfalse();
        transform.position = new Vector3(0, 0, 0);
        currenthealth = maxhealth;
        mainText.text = "" + currenthealth;

        death = false;
        deathtimer = 0;
        gameObject.GetComponent<Animator>().Play("idle");
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponentInChildren<PlayerInput>().enabled = true;
    }
}
