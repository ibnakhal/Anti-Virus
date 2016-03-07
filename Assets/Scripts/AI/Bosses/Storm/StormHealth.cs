/***************************
----------------------------
|*   StormHealth.cs       *|
|*   Ibrahim Nakhal       *|
|*   Student              *|
|*   AAU Game Design      *|
----------------------------
***************************/

using UnityEngine;
using System.Collections;

public class StormHealth : MonoBehaviour
{

    [SerializeField]
    public int health = 10;
    [SerializeField]
    public GameObject deathParticles, wormRearNeighbor = null;
    [SerializeField]
    public GameObject[] drops;
    [SerializeField]
    private int dropPercent, truepercent;



    // Update is called once per frame
    void Update()
    {


        if (health <= 0)
        {
            Instantiate(deathParticles, this.transform.position, this.transform.rotation);
            if (wormRearNeighbor != null)
            {
                wormRearNeighbor.GetComponent<StormSegment>().front = null;
            }

for (int x = 0; x<5;x++)
            {
                Instantiate(drops[0], transform.position, transform.rotation);
            }


            Destroy(this.gameObject);
        }
    }



    public void GetHurt(int dmg)
    {
        health -= dmg;
        Debug.Log("I AM HIT AND MY HP IS " + health);
    }
}
