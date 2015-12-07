using UnityEngine;
using System.Collections;

public class LaserRender : MonoBehaviour {

    [SerializeField]
    private Vector2 mouse;
    [SerializeField]
    private RaycastHit hit;
    [SerializeField]
    private float range = 100.0f;
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private Material lineMaterial;
    [SerializeField]
    private GunManager gManage;
    [SerializeField]
    private GameObject pCon = null;

    void Start()
    {
        pCon = GameObject.FindGameObjectWithTag("Player");
        gManage = pCon.GetComponent<GunManager>();
        line = this.GetComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.GetComponent<Renderer>().material = lineMaterial;
        line.SetWidth(0.2f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, this.transform.forward*75);

	
	}
}
