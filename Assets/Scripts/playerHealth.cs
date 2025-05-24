using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth;

    public void ChangeHealth(int amount)
    {
        currenthealth = currenthealth + amount;
    }
}
