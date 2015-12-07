/************************
-------------------------
|*   BulletBehavior.cs *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/

using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour 
{
    [SerializeField]
    private float wait = 6.0f;
    [SerializeField]
    public int damage;
    [SerializeField]
    public GameObject explosion;

    /// <summary>
    /// Starts the countown for the shot to dissappear
    /// </summary>

    public void Start()
    {
        StartCoroutine("Death");
    }

    public void Update()
    {
        
    }



    /// <summary>
    /// Kills enemies on hit
    /// </summary>
    /// <param name="Other"></param>
    public void OnTriggerEnter(Collider Other)
    {
        print(Other.tag);
        if (Other.tag == "Enemy" || Other.tag == "Head" || Other.tag == "Baby" || Other.tag == "Boss")
        {
            if (Other.tag == "Baby")
            {
                Other.GetComponentInParent<EnemyHealthScript>().GetHurt(damage);
            }
            if (Other.tag == "Boss")
            {
                Other.GetComponent<NyxemBasicBehavior>().GetHurt(damage);
                Other.GetComponent<CodeRedBasicBehavior>().GetHurt(damage);
            }
            else
            {
                Other.GetComponent<EnemyHealthScript>().GetHurt(damage);
            }

        }
        if (Other.tag != "Gun" && Other.tag != "Player")
        {

            GameObject clone = Instantiate(explosion, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// puts a countdown timer on when it dissapates
    /// </summary>
    /// <returns></returns>
    public IEnumerator Death()
    {
        yield return new WaitForSeconds(wait);
            Destroy(this.gameObject);  
    }
}
