using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Adware : MonoBehaviour {
    public bool triggered;
    [SerializeField]
    private GameObject[] ads;
    [SerializeField]
    private int timeLimit;
    private PlayerController pC;
    // Use this for initialization
    void Start () {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        pC = p.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator Adwared()
    {
        while(triggered)
        {
            int x = Random.Range(0, ads.Length);
            ads[x].SetActive(true);
            int y = Random.Range(0, timeLimit);
            yield return new WaitForSeconds(y);
            ads[x].SetActive(false);
            int z = Random.Range(0, timeLimit);
            yield return new WaitForSeconds(z);

        }
    }



}
