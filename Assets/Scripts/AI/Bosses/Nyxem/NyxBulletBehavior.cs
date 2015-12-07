using UnityEngine;
using System.Collections;

public class NyxBulletBehavior : MonoBehaviour {


    [SerializeField]
    private GameObject explosion;


public void OnTriggerEnter(Collider Other)
    {
        if(Other.tag != "Boss" && Other.tag != "Nyxem Shot Point" && Other.tag != "Untagged" && Other.tag != "Bullet" && Other.tag != "Gun")
        {
            gameObject.GetComponentInChildren<ParticleEmitter>().emit = false;
            GameObject clone = Instantiate(explosion, this.transform.position, this.transform.rotation) as GameObject;
            StartCoroutine(Die());
        }

    }


    public IEnumerator Die()
    {
    yield return new WaitForSeconds(2);
    Destroy(this.gameObject);
    }
}
