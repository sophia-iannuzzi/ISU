using UnityEngine;
using TMPro;
public class weaponManager : MonoBehaviour
{

    public int weaponnum;
    public GameObject[] weapons;
    private int[] wepdamages = { -1, -2 };
    public int damage;
    public string attackname;

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
        if (weaponnum >= 2)
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
                damage = wepdamages[weaponnum];
                weapontext.text = weapon.name;
            }
        }
    }
}
