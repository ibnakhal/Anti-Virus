using UnityEngine;
using System.Collections;

public class CryoAI : MonoBehaviour {


    [SerializeField]
    private GameObject player;
    [SerializeField]
    private bool triggered = false;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int calibration;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private bool lefty = false;
    [SerializeField]
    private bool righty = false;
    [SerializeField]
    private GameObject minime;
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");


	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.LookAt(player.transform.position);
        if(triggered)
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if(lefty && isActiveAndEnabled)
        {
            Debug.Log("Rotation Confirmed");
            minime.transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);

        }
        if(righty && isActiveAndEnabled)
        {
            minime.transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed);

        }

    }



    public void OnTriggerEnter( Collider Other)
    {
        if(Other.transform.gameObject == player)
        {
            StartCoroutine(Charge());
            triggered = true;
        }
    }


    public IEnumerator Charge()
    {
        while (isActiveAndEnabled)
        {
            lefty = true;
            righty = false;
            yield return new WaitForSeconds(5);
            lefty = false;
            righty = true;
            yield return new WaitForSeconds(5);
        }
    }



}
