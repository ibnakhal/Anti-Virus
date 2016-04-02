/************************
-------------------------
|*   wormAI:           *| 
|*   SegmentFollow.cs  *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/
using UnityEngine;
using System.Collections;

public class SegmentFollow : MonoBehaviour {

    /// <summary>
    /// NOTE**** THIS CODE IS INCOMPLETE
    /// </summary>
    [SerializeField]
    public GameObject neighbor = null, head = null, potential = null;
    [SerializeField]
    private float lagTime = 0.045f;
    [SerializeField]
    wAI  wormAI;
    [SerializeField]
    private Material mat;




    public void Start()
    {
        head = GameObject.FindGameObjectWithTag("Head");
        wormAI = head.GetComponent<wAI>();
        StartCoroutine("Follower");
    }
    /// <summary>
    /// tells the block to follow the piece in front of it
    /// </summary>
    public void Update()
    {
        
        this.transform.Translate(Vector3.forward * Time.deltaTime * wormAI.force);


        //turns into a head
        if(neighbor == null)
        {
            this.GetComponentInChildren<Collider>().enabled = false;
            GameObject m_this = this.gameObject;
            m_this.AddComponent<wAI>();
            m_this.GetComponent<wAI>().rear = m_this.GetComponent<EnemyHealthScript>().wormRearNeighbor;
            //this.gameObject.AddComponent<Mesh>();
            m_this.AddComponent<MeshFilter>();
            m_this.AddComponent<MeshRenderer>();
            this.transform.localScale -= new Vector3(99, 99, 99);
            m_this.AddComponent<SphereCollider>();
            m_this.AddComponent<Rigidbody>();
            this.GetComponent<AudioSource>().Play();

            m_this.GetComponent<Rigidbody>().useGravity = false;
            m_this.GetComponent<Rigidbody>().angularDrag = 0;
            m_this.GetComponent<Collider>().isTrigger = false; 
            m_this.GetComponent<MeshFilter>().sharedMesh = potential.GetComponent<MeshFilter>().sharedMesh;
            m_this.GetComponent<MeshRenderer>().sharedMaterial = mat;
            

			



            
            
            Debug.Log("POKEPOLE");

			Destroy(this);

        }
    }
    /// <summary>
    /// Tells the body segment to look at the piece moving in front of it
    /// </summary>
    /// <returns></returns>
    public IEnumerator Follower()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(lagTime);

            
           // Debug.Log("Bodymove");
            
            //Debug.Log(wormAI.force);
			if (neighbor != null)
			{
            this.transform.LookAt(neighbor.transform);
			}
        }
    }



}

// uh this code is pretty simple and fine, is there a way to combine it with another script or is it only good if it's its own script