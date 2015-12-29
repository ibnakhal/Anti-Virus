using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    [Header("Attachment Links")]

    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private PlayerController pCon;
    [SerializeField]
    private GunManager gMan;


    [Header("Player Stats")]

    [SerializeField]
    public int maxHp;
    [SerializeField]
    public int hP;
    [SerializeField]
    public int[] ammo;
    [SerializeField]
    private int ammo3;

    [SerializeField]
    private bool trojan;
    [SerializeField]
    private bool mal;

    [Header ("Technical")]
    [SerializeField]
    private bool game = false;
    [SerializeField]
    private bool searchlight = false;

    public void Start()
    {

        DontDestroyOnLoad(this.gameObject);
    }

    public void OnLevelWasLoaded(int level)
    {

            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                Debug.Log("POW");
                playerObject = GameObject.FindGameObjectWithTag("Player");
                pCon = playerObject.GetComponent<PlayerController>();
                gMan = playerObject.GetComponent<GunManager>();

                for (int x = 0; x < ammo.Length; x++)
                {
                    gMan.m_WeaponList[x].ammo = ammo[x];
                }
                pCon.maxHp = maxHp;
                pCon.health = hP;
                pCon.trojand = trojan;
                pCon.Maled = mal;

                game = true;
            }
    }



    public void Update()
    {
        /*if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            searchlight = true;
        }*/
        Debug.Log(game);
        if (game)
        {
            maxHp = pCon.maxHp;
            hP = pCon.health;
            trojan = pCon.trojand;
            mal = pCon.Maled;

            ammo[gMan.m_currentWeapon] = gMan.m_WeaponList[gMan.m_currentWeapon].ammo;
        }
    }
    


}
