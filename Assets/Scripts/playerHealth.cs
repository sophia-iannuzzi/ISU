using UnityEngine;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;
    public TextMeshProUGUI mainText;

    void Start()
    {
        mainText.text = "Life: 5";
    }

    public void ChangeHealth(int amount)
    {
        currenthealth = currenthealth + amount;
        mainText.text = "Life: " + currenthealth;
        if (currenthealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
