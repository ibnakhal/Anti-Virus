using UnityEngine;
using System.Collections;

public class RoomTexter : MonoBehaviour {

    [SerializeField]
    private Material masterMat;
    [SerializeField]
    private GameObject[] meshPieces;

	// Use this for initialization
	void Start () {



        StartCoroutine(StartUp());





	}
	
	// Update is called once per frame
	void Update () {
	
	}




    public IEnumerator StartUp()
    {
        yield return new WaitForEndOfFrame();

        meshPieces = GameObject.FindGameObjectsWithTag("wall");

        for (int x = 0; x < meshPieces.Length; x++)
        {
            meshPieces[x].GetComponent<Renderer>().material = masterMat;
        }

    }
}
