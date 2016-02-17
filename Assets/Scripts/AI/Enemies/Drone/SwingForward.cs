using UnityEngine;
using System.Collections;

public class SwingForward : MonoBehaviour {
    [SerializeField]
    private Malware mal;
    [SerializeField]
    private GameObject death;

    public void Start()
    {
    }
    public void Update()
    {

    }

    public void OnCollisionEnter(Collision coolide)
    {
        Collider other = coolide.collider;
        if(other.tag == "Player")
        {
            Debug.Log("Woof");
            mal = other.GetComponentInChildren<Malware>();
            mal.Infect();
            Instantiate(death, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
