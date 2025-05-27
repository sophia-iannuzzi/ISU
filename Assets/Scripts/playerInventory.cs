using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerInventory : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI moneytext;

    void OnWeaponswitch()
    {
        Debug.Log("swtich");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            Destroy(other.gameObject);
            money++;
            moneytext.text = "Money: " + money;
        }
    }
}
