using UnityEngine;
using System.Collections;

public class BFXMasterHealth : MonoBehaviour {

    [SerializeField]
    private GameObject[] pieces;
    [SerializeField]
    private int masterHpMax;
    [SerializeField]
    private int masterHealth;
    [SerializeField]
    private int temphealth;
    [SerializeField]
    private float healthRatio;
    [SerializeField]
    private int ratioThreshold;
    [SerializeField]
    private bool bugsOut;
    [SerializeField]
    private GameObject[] nextStage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        healthRatio = masterHealth / masterHpMax;

        if(healthRatio<=ratioThreshold && !bugsOut)
        {
            bugsOut = true;

            for(int x = 0; x<nextStage.Length; x++)
            {
                nextStage[x].SetActive(true);
                nextStage[x].GetComponent<BFXStageChange>().Kickstart();
            }

        }

	}


    public void HealthCheck()
    {
        temphealth = 0;
        for(int x = 0; x < pieces.Length; x++)
        {
            temphealth += pieces[x].GetComponent<ILYBFXHealth>().health; 
        }
        masterHealth = temphealth;
    }
}
