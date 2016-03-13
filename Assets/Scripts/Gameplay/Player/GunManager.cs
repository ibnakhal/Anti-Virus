/************************
-------------------------
|*   GunManager.cs     *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/

using UnityEngine;
using System.Collections;
using System;
[RequireComponent(typeof(AudioSource))]
public class GunManager : MonoBehaviour {

    [SerializeField]
    public Weapon[] m_WeaponList = new Weapon[2];
    [SerializeField]
    public int m_currentWeapon = 0, lastWeapon;
    [SerializeField]
    private AudioClip aClip;
    [SerializeField]
    private AudioSource aSource;
    [SerializeField]
    public bool firing = false, weaponChange = false;
    public void Start()
    {
        m_currentWeapon = 0;

        aSource = GetComponent<AudioSource>();
        
    }


    public IEnumerator waiter(float rate)
    {

            m_WeaponList[m_currentWeapon].cooldown = true;
            yield return new WaitForSeconds(rate);
            m_WeaponList[m_currentWeapon].cooldown = false;

    }


    public void Update()
    {
        if (Input.GetMouseButton(0) && m_WeaponList[m_currentWeapon].isloaded == true && m_WeaponList[m_currentWeapon].ammo>0 && m_WeaponList[m_currentWeapon].cooldown == false && weaponChange == false)
        {
            m_WeaponList[m_currentWeapon].Fire();
            Debug.Log("Firin");

            Debug.Log("WeaponChange is " + weaponChange);
            if (!firing)
            {
                
                if (m_WeaponList[m_currentWeapon].gunType == Weapon.GunType.Raycast)
                {
                    aSource.loop = true;
                }

                aClip = m_WeaponList[m_currentWeapon].audioC;
                aSource.clip = aClip;
                aSource.Play();
                firing = true;
            }

           
            
        }
        else
        {
            if (firing)
            {
                if (m_WeaponList[m_currentWeapon].gunType == Weapon.GunType.Raycast)
                {
                    aSource.Stop();
                    aSource.loop = false;

                }
                    StartCoroutine(waiter(m_WeaponList[m_currentWeapon].rateOfFire));
               
            }
            firing = false;

        }



        string inputThisFrame = Input.inputString;


        //use try{} catch{} to gracefully handle errors / exceptions
        try
        {

            int inputAsInt = Convert.ToInt32(inputThisFrame);


            if (inputAsInt >= 1 && inputAsInt <= m_WeaponList.Length)
            {
                if (m_WeaponList[m_currentWeapon].isloaded == true)
                {

                    StartCoroutine(Unload(inputAsInt));
                }
                else
                {
                    m_currentWeapon = inputAsInt - 1;
                    m_WeaponList[m_currentWeapon].Load();
                    weaponChange = false;

                }
            }

            // FIX THIS******** if(m_currentWeapon < 1 || m_currentWeapon)



        }

        catch (FormatException)
        {
            //did not hit a number key
        }

    }


	public IEnumerator Unload(int inputAsInt)

	{
            weaponChange = true;
            lastWeapon = m_currentWeapon;
            m_WeaponList[m_currentWeapon].gunModel.GetComponent<Animation>().Play(m_WeaponList[m_currentWeapon].uAnimation.name);
            yield return new WaitForSeconds(m_WeaponList[m_currentWeapon].uAnimation.length);
            m_WeaponList[lastWeapon].gunModel.SetActive(false);
            m_WeaponList[m_currentWeapon].Unload();
            m_currentWeapon = inputAsInt - 1;
            m_WeaponList[m_currentWeapon].Load();
            weaponChange = false;

	}

    public void AmmoUp(int ammotypes, int ammoCount)
    {
        m_WeaponList[ammotypes].ammo = m_WeaponList[ammotypes].ammo + ammoCount;
    }

}
