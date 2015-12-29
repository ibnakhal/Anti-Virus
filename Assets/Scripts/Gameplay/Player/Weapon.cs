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
    private int baseDamage = 1;
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
        Vector3 vectora = (target.position - gunModel.transform.position);
        Debug.Log("FIRE!");
        switch (gunType)
        {
            case GunType.Rigidbody:
                for (int x = 0; x < bulletCount; x++)
                {
                    GameObject clone = MonoBehaviour.Instantiate(bulletPrefab, barrel[x].position, barrel[x].rotation) as GameObject;
                    Debug.Log(clone);
                    clone.GetComponent<BulletBehavior>().damage = baseDamage;

                    clone.GetComponent<Rigidbody>().velocity = (vectora * bulletSpeed * Time.deltaTime);
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
                        if (hit.transform.tag == "Baby")
                        {
                            enemy.GetComponentInParent<EnemyHealthScript>().GetHurt(baseDamage);
                        }
                        if (hit.transform.tag == "Boss")
                        {
                            enemy.GetComponent<NyxemBasicBehavior>().GetHurt(baseDamage);
                        }
                        else
                        {
                            enemy.GetComponent<EnemyHealthScript>().GetHurt(baseDamage);
                        }
                    }
                }

                }
                ammo --;
                break;
        }
    }
}






