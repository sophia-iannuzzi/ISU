using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

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
        mainText.text = "Life: 5/5";
        deathtimer = 0;
        death = false;
    }

    void Update()
    {
        if (death == true)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            //player animation
            if (deathtimer > 3)
            {
                playerDeath();
            }
            deathtimer += Time.deltaTime;
        }
        if (currenthealth <= 0)
        {
            mainText.text = "Life: 0/" + maxhealth;
            death = true;
        }
    }

    public void ChangeHealth(int amount)
    {
        currenthealth = currenthealth + amount;
        mainText.text = "Life: " + currenthealth + "/" + maxhealth;
    }

    void playerDeath()
    {
        Debug.Log("You died");
        transform.position = new Vector3(0, 0, 0);
        currenthealth = maxhealth;
        mainText.text = "Life: " + currenthealth + "/" + maxhealth;

        death = false;
        deathtimer = 0;

        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
