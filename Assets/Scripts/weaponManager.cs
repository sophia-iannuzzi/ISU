using UnityEngine;
public class weaponManager : MonoBehaviour
{
    public GameObject[] weapons;

    public string attackname;


    public void list()
    {
        GameObject weaponhold = weapons[1];
        attackname = weaponhold.name;
    }
}
