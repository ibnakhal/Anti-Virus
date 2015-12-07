using UnityEngine;
using System.Collections;

public class SpinnerMovement : MonoBehaviour {



    [SerializeField]
    private float mSpeed;
    [SerializeField]
    private bool infiniteRun = true;
    [SerializeField]
    Transform player;
    [SerializeField]
    private float turnSpeedCalibration;
    [SerializeField]
    private int turnCounter;

	// Use this for initialization
	void Start () {
        //StartCoroutine(Looking());
	}
	
	// Update is called once per frame
	void Update () {


         this.transform.Translate(Vector3.forward * Time.deltaTime * mSpeed);

        
        Vector3 targeting = new Vector3(player.position.x, player.transform.position.y, player.position.z);
        Quaternion targetDir = Quaternion.LookRotation(targeting - this.transform.position);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetDir, Time.deltaTime * turnSpeedCalibration);
	}

    public IEnumerator Looking()
    {
        while (infiniteRun == true)
        {
            yield return new WaitForSeconds(turnSpeedCalibration);
            for (int x = 0; x < turnCounter; x++)
            {
                Vector3 targeting = new Vector3(player.position.x, player.transform.position.y, player.position.z);
                this.transform.LookAt(targeting);
            }

        }
    }
}
