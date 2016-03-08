/***************************
----------------------------
|*   EnemyHealthScript.cs *|
|*   Ibrahim Nakhal       *|
|*   Student              *|
|*   AAU Game Design      *|
----------------------------
***************************/

using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

    [SerializeField]
    public int health = 10;
    [SerializeField]
    public GameObject deathParticles, wormRearNeighbor = null;
    [SerializeField]
    public GameObject[] drops;
    [SerializeField]
    private int dropPercent, truepercent;
  


	// Update is called once per frame
	void Update () {
	

        if (health <= 0)
        {
            Debug.Log("DEAD");
            Instantiate(deathParticles, transform.position, transform.rotation);
            if (wormRearNeighbor != null)
            {
                wormRearNeighbor.GetComponent<SegmentFollow>().neighbor = null;
            }

            truepercent = Random.Range(0, 101);
            if (truepercent <= dropPercent)
            {
                GameObject clone = Instantiate(drops[Random.Range(0, drops.Length + 1)], this.transform.position, drops[Random.Range(0, drops.Length + 1)].transform.rotation) as GameObject;
                
            }

            gameObject.GetComponentInParent<SegmentControl>().Parts.Remove(gameObject);
            Destroy(this.gameObject);
        }
	}



    public void GetHurt(int dmg)
    {
        health -= dmg;
        Debug.Log("I AM HIT AND MY HP IS " + health);
    }
}
