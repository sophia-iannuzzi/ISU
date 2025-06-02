using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class playerHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;
    public TextMeshProUGUI mainText;
    public Image pic;

    void Start()
    {
        mainText.text = "Life: 5/5";
    }

    public void ChangeHealth(int amount)
    {
        currenthealth = currenthealth + amount;
        mainText.text = "Life: " + currenthealth + "/5";
        if (currenthealth <= 0)
        {
            Debug.Log("You died");
            transform.position = new Vector3(0, 0, 0);
            currenthealth = 5;
            mainText.text = " ";
        }
    }
}
