using UnityEngine;
using System.Collections;

public class LootBox : MonoBehaviour {



    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject DeathParticles;
    [SerializeField]
    private GameObject toDie;
    public GameObject[] drops;
    [SerializeField]
    private int dropPercent, truepercent;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Instantiate(DeathParticles, this.transform.position, this.transform.rotation);

            Destroy(toDie);

            truepercent = Random.Range(0, 101);
            if (truepercent <= dropPercent)
            {
                GameObject clone = Instantiate(drops[Random.Range(0, drops.Length + 1)], this.transform.position, drops[Random.Range(0, drops.Length + 1)].transform.rotation) as GameObject;

            }
        }


    }


    public void GetHurt(int Damage)
    {
        health -= Damage;

    }






}
