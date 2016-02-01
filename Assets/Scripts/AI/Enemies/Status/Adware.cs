using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Adware : MonoBehaviour {

    public bool triggered;
    private PlayerController pC;

    [Header("RNG")]
    [SerializeField]
    int x;
    [SerializeField]
    int y;
    [SerializeField]
    int z;

    [Header ("Status Traits")]
    [SerializeField]
    private GameObject[] ads;
    [SerializeField]
    private string alert;
    [SerializeField]
    private int timeLimit;

    



    // Use this for initialization
    void Start () {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        pC = p.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Infect()
    {
        triggered = true;
        StartCoroutine(Adwared());
        pC.Warner(alert);
    }

    public IEnumerator Adwared()
    {
        while(triggered)
        {
            x = Random.Range(0, ads.Length);
            ads[x].SetActive(true);
            y = Random.Range(0, timeLimit);
            yield return new WaitForSeconds(y);
            ads[x].SetActive(false);
            z = Random.Range(0, timeLimit);
            yield return new WaitForSeconds(z);

        }
        ads[x].SetActive(false);
    }



}
