using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {


    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int[] weaponOwned;
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GunManager gunM;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.health = health;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            health = player.health;
            maxHealth = player.maxHp;

        }

	
	}
}
