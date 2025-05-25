using System.Collections.Generic;
using UnityEngine;

public class playerAnimateController : MonoBehaviour
{
    public GameObject handweapon;

    public string attack;

    private weaponManager weaponManager;

    void Start()
    {
        weaponManager = handweapon.GetComponent<weaponManager>();
        weaponManager.list();
        attack = weaponManager.attackname;
    }
    


}
