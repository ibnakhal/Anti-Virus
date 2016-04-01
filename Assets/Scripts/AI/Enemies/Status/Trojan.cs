using UnityEngine;
using System.Collections;

public class Trojan : MonoBehaviour {
    [SerializeField]
    public bool trojan = false;
    [SerializeField]
    private PlayerController pC;
    [SerializeField]
    private float time;
    [SerializeField]
    private float timeSlow;
    [SerializeField]
    private string alert;
    [SerializeField]
    private int infectionTimeframe;
    [SerializeField]
    private float mod;


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
        StartCoroutine(Troj());
        trojan = true;
        StartCoroutine(pC.Warner(alert));

    }


    public IEnumerator Troj()
    {
        if(!trojan)
        {
            for (int x = 0; x < infectionTimeframe; x++)
            {
                pC.runSpeed -= mod;
                pC.jumpSpeed -= mod;
                pC.turnSpeed -= mod;
                yield return new WaitForSeconds(timeSlow);
                
            }
            yield return new WaitForSeconds(time);
            for (int x = 0; x < infectionTimeframe; x++)
            {
                pC.runSpeed += mod;
                pC.jumpSpeed += mod;
                pC.turnSpeed += mod;
                yield return new WaitForSeconds(timeSlow);  
            }

        }
    }
}
