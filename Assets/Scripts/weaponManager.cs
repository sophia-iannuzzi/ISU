using UnityEngine;
using TMPro;
public class weaponManager : MonoBehaviour
{

    public int weaponnum;
    public GameObject[] weapons;
    public int[] wepdamages = { -1, -2, 0};
    public int damage;
    public string attackname;

    public GameObject currentweapon;

    public TextMeshProUGUI weapontext;

    void Start()
    {
        weaponnum = 0;


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
                currentweapon = weapon;
                damage = wepdamages[weaponnum];
                damage = wepdamages[weaponnum];
                weapontext.text = weapon.name;
            }
        }
    }
    public void WeaponSwitch()
    {
        Debug.Log("weapon switch");
        weaponnum++;
        if (weaponnum >= 3)
        {
            weaponnum = 0;
        }
        damage = wepdamages[weaponnum];

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
                currentweapon = weapon;
                damage = wepdamages[weaponnum];
                weapontext.text = weapon.name;
            }
        }
    }
}
