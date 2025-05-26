using UnityEngine;
public class weaponManager : MonoBehaviour
{

    public int weaponnum;
    public GameObject[] weapons;
    private int[] wepdamages = {-1, -2};
    public int damage;
    public string attackname;

    void Start()
    {
        damage = wepdamages[weaponnum];
    }
    public void weaponSwitch()
    {
        GameObject weaponhold = weapons[weaponnum];
        attackname = weaponhold.name;
        foreach (GameObject weapon in weapons)
        {
            if (weapon.name != attackname)
            {
                weapon.SetActive(false);
            }
            else
            {
                weapon.SetActive(true);
                damage = wepdamages[weaponnum];
            }
        }
    }
}
