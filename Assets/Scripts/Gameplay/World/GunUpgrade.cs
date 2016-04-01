using UnityEngine;
using System.Collections;

public class GunUpgrade : MonoBehaviour {

    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private GunManager gControl = null;
    [SerializeField]
    private string objName;
    [SerializeField]
    private int gunID;
    [SerializeField]
    private float mod;
    [SerializeField]
    private GameObject p;
    enum Type
    {
        Speed,
        Damage,
        Reload,

    }
    [SerializeField]
    private Type typed;

    public void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
        gControl = p.GetComponent<GunManager>();
    }

    public void Update()
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
    public void OnTriggerEnter (Collider Other)
    {
        if (Other.tag == "Player")
        {
            p.GetComponent<PlayerController>().StartCoroutine(p.GetComponent<PlayerController>().Warner(objName));
            switch (typed)
            {
                case Type.Speed:
                    gControl.m_WeaponList[gunID].bulletSpeed += mod;
                    break;
                case Type.Damage:
                    gControl.m_WeaponList[gunID].baseDamage += (int)mod;
                    break;
                case Type.Reload:
                    gControl.m_WeaponList[gunID].reloadTime -= mod;
                    break;
                    
            }
            Destroy(this.gameObject);
        }
    }
}
