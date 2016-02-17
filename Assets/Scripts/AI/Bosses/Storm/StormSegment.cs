using UnityEngine;
using System.Collections;

public class StormSegment : MonoBehaviour {
    [SerializeField]
    public GameObject front, head, potential;
    [SerializeField]
    private float lagTime;
    [SerializeField]
    StormAI ai;
    [SerializeField]
    private Material potentialMat;
	// Use this for initialization
	void Start () {
        ai = head.GetComponent<StormAI>();
        StartCoroutine(Follower());
	}

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * ai.force);


        if (front == null)
        {
            this.GetComponentInChildren<Collider>().enabled = false;
            GameObject m_this = this.gameObject;
            m_this.AddComponent<wAI>();
            //this.gameObject.AddComponent<Mesh>();
            m_this.AddComponent<MeshFilter>();
            m_this.AddComponent<MeshRenderer>();
            this.transform.localScale -= new Vector3(99, 99, 99);
            m_this.AddComponent<SphereCollider>();
            m_this.AddComponent<Rigidbody>();


            m_this.GetComponent<Rigidbody>().useGravity = false;
            m_this.GetComponent<Rigidbody>().angularDrag = 0;
            m_this.GetComponent<Collider>().isTrigger = false;
            m_this.GetComponent<MeshFilter>().sharedMesh = potential.GetComponent<MeshFilter>().sharedMesh;
            m_this.GetComponent<MeshRenderer>().sharedMaterial = potentialMat;
            Destroy(this);
        }
    }
     public IEnumerator Follower()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(lagTime);


            // Debug.Log("Bodymove");

            //Debug.Log(wormAI.force);
            if (front != null)
            {
                this.transform.LookAt(front.transform);
            }
        }
    }
}
