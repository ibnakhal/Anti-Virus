/************************
-------------------------
|*   Beamscript.cs     *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]

public class Beamscript : MonoBehaviour 
{

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
		line.SetWidth(0.1f, 0.25f);
	}
	
	void Update()
	{
       
		Ray ray = new Ray (this.transform.position, this.transform.forward);
		if(Physics.Raycast(ray, out hit, range))
		{
            if (Input.GetMouseButton(0))
            {
                if (gManage.m_WeaponList[gManage.m_currentWeapon].ammo > 0)
                {
                    line.enabled = true;
                    //line.SetPosition(0, this.transform.position);
                    //line.SetPosition(1, hit.point + hit.normal);
                }
            }
            else
                line.enabled = false;
		}
		
	}
}