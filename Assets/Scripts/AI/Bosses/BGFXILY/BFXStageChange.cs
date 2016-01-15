using UnityEngine;
using System.Collections;

public class BFXStageChange : MonoBehaviour {

    [SerializeField]
    private float radius;
    [SerializeField]
    private float radialLimit;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Kickstart()
    {
        StartCoroutine(NextStage());
    }


    public IEnumerator NextStage()
    {
        while (radius < radialLimit)
        {
            yield return new WaitForSeconds(0.05f);
            radius += 0.5f;
            this.gameObject.transform.localScale += new Vector3(0.021F, 0.021f, 0.021f);
        }


    }
}
