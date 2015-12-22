﻿using UnityEngine;
using System.Collections;

public class GunPickup : MonoBehaviour 
{
    [SerializeField]
    private GunManager gControl = null;
    [SerializeField]
    private int gunID, ammoToAdd = 0;
    [SerializeField]
    Vector3 direction = new Vector3(0, 0, 0);
    [SerializeField]
    private bool notGun;



    public void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Player")
        {
            gControl = Other.GetComponent<GunManager>();

            if (!notGun)
            {
                gControl.m_WeaponList[gunID].owned = true;

            }
            gControl.m_WeaponList[gunID].ammo += ammoToAdd;
            Destroy(this.gameObject);
        }

    }
    
    public void Update()
    {
        this.transform.Rotate(direction * Time.deltaTime * 100);
    }

}
