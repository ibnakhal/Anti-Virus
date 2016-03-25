/************************
-------------------------
|*   Weapon.cs         *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/
using UnityEngine;
using System.Collections;
//using System;
[System.Serializable]

[RequireComponent(typeof(Animator))]
public class Weapon
{
    public enum GunType
    {
        Rigidbody,
        Raycast,
    }

    public LayerMask shootingMask;


    //TODO*******************
    public string weaponName;
    public GunType gunType;
    public GameObject gunModel;
    public float reloadTime;
    //forces the prefab to have a script on it
    public GameObject bulletPrefab;
    public Transform[] barrel;
    public Transform target;
    public float bulletSpeed;
    public int ammo;
    public float rateOfFire;
    public float range;
    public int bulletCount;
    public float spread = 5;
    [SerializeField]
    public int baseDamage = 1;
    public float damageReductionOverDistance;
    public float areaOfEffectBaseDamage;
    public float areaOfEffectRange;
    public bool hasGravity;
    public Animation master;
    public AnimationClip lAnimation;
    public AnimationClip uAnimation;
    public AudioClip audioC;
    public bool isloaded = false;
	public bool cooldown = false;
    public bool owned = false;


    public void Load()
    {
        if (owned && !isloaded)
        {
            Debug.Log("LoadPass");
            gunModel.SetActive(true);
			gunModel.GetComponent<Animation>().Play(lAnimation.name);
  //          master.Play(lAnimation.name);
            isloaded = true;
        }
    }

    public void Unload()
    {

       	
        isloaded = false;
        cooldown = false;
    }



    public void Fire()
    {

            Vector2 ScreenCenter = new Vector2(Screen.height/2, Screen.width/2);

        //Ray rayB = Camera.main.ScreenPointToRay(ScreenCenter);

        RaycastHit hitty;
        Transform camsform = Camera.main.transform;
        Ray rayB = new Ray(camsform.position, camsform.forward);
        Physics.Raycast(rayB, out hitty, 3000.0f, shootingMask);

        Vector3 vectora = (hitty.point - barrel[0].transform.position).normalized;
        Debug.Log("FIRE!");
        switch (gunType)
        {
            case GunType.Rigidbody:
                for (int x = 0; x < bulletCount; x++)
                {
                    Debug.Log("InTheCase");
                    GameObject clone = MonoBehaviour.Instantiate(bulletPrefab, barrel[x].position, barrel[x].rotation) as GameObject;
                    Debug.Log(clone);
                    clone.GetComponent<BulletBehavior>().damage = baseDamage;

                    clone.GetComponent<Rigidbody>().velocity = (vectora * bulletSpeed);
                    ammo--;
                }
                cooldown = true;

                break;



            case GunType.Raycast:
                 for (int x = 0; x < bulletCount; x++)
                {
                Ray cast = new Ray(barrel[x].position, barrel[x].forward);
                RaycastHit hit;
                bool rerun = Physics.Raycast(cast, out hit, range);
                Debug.Log(rerun);
                if (rerun == true && ammo > 0)
                {
                    Debug.Log("LOG");
                    if (hit.transform.tag == "Enemy" || hit.transform.tag == "Head" || hit.transform.tag == "Baby" || hit.transform.tag == "Boss")
                    {
                        Debug.Log("HIT");
                        GameObject enemy = hit.transform.gameObject;
                            enemy.gameObject.SendMessage("GetHurt", baseDamage);

                        }
                    }

                }
                ammo --;
                break;
        }
    }
}






