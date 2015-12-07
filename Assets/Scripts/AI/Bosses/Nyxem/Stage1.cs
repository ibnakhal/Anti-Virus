using UnityEngine;
using System.Collections;


public class Stage1 : MonoBehaviour
{

    
    [Header("Targeting")]
    [SerializeField]
    private Vector3 hiddenvector;




    [Header("UI")]
    [SerializeField]
    private AudioSource aSource;
    [SerializeField]
    private Color startColor;
    [SerializeField]
    private Color endColor;
    [SerializeField]
    private Renderer rend;




    [SerializeField]
    Transform[] spPoints;
    [SerializeField]
    Transform player;
    [SerializeField]
    private bool infinite = true, Done = true, pulsing = false, hitPlayer = false, charging = false;
    [SerializeField]
    public int pulseDamage, stage;
    [SerializeField]
    private GameObject pulseField;
    [SerializeField]
    private float pTime, fTime, radius, radialLock, radialLimit, force, lerpValue, timer, duration;


    [SerializeField]
    private AudioClip chargeClip, dischargeClip;

    public enum StateType
    {
        Fire,
        Pulse,
        size,

    }

    private NyxemBasicBehavior nyx;
    [SerializeField]
    private int shotLimit, totalCount;
    void Start()
    {
        StartCoroutine("Started");
        //boolNum = new bool[(int)boolType.size];
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nyx = GameObject.FindGameObjectWithTag("Boss").GetComponent<NyxemBasicBehavior>();
        radialLock = radius;
        hiddenvector = pulseField.gameObject.transform.localScale;


    }

    void Update()
    {
        if(charging)
        {
            timer += Time.deltaTime;

            lerpValue = (timer / duration);
            rend.material.color = Color.Lerp(startColor, endColor, lerpValue);
        }
        if(pulsing)
        {
            timer += Time.deltaTime;

            lerpValue = (timer / duration);
            rend.material.color = Color.Lerp(endColor,startColor, lerpValue);
        }
        else if (!charging && !pulsing)
        {
            lerpValue = 0;
        }
    }


    public IEnumerator Fire()
    {
        Done = false;
        while (totalCount < shotLimit)// && boolNum[(int)boolType.Firing])
        {
            yield return new WaitForSeconds(fTime);
            int r = Random.Range(0, nyx.spPoints.Length);
            Vector3 VectorD = (player.position - nyx.spPoints[r].position);
            //Raycast to find out if it goes through Nyxem, if so re-roll DONE!
            Ray cast = new Ray(nyx.spPoints[r].position, VectorD);
            RaycastHit hit;
            bool infoReturn = Physics.Raycast(cast, out hit, 100);
            if (infoReturn)
            {
                if (hit.transform.tag == "Boss")
                {
                    print("I HIT MYSELF");
                    r = Random.Range(0, nyx.spPoints.Length);
                }
                else if (hit.transform.tag == "Player")
                {

                    GameObject clone = Instantiate(nyx.bullet, nyx.spPoints[r].position, nyx.spPoints[r].rotation) as GameObject;
                    clone.GetComponent<Rigidbody>().velocity = (VectorD * Time.deltaTime * 50);
                    totalCount++;
                }
            }

            print(VectorD);
            print("BLARGHARGHARGHAREH");

        }
        totalCount = 0;
        Done = true;
    }

    public IEnumerator Started()
    {
        while (infinite)
        {
            yield return new WaitForSeconds(1);
            if (Done)
            {
                int s = Random.Range(0, ((int)StateType.size-stage));
                StateType state = (StateType)s;
                string name = state.ToString();
                print(name);
                StartCoroutine(name);
            }

        }

    }

    public IEnumerator Pulse()
    {
        Done = false;

        aSource.clip = chargeClip;
        duration = chargeClip.length;
        charging = true;
        aSource.Play();

        
        
        yield return new WaitForSeconds(aSource.clip.length);
        aSource.clip = dischargeClip;
        duration = dischargeClip.length;
        aSource.Play();
        charging = false;
        lerpValue = 0;

        pulsing = true;
        while (pulsing && radius < radialLimit)
        {
            Collider[] hits = Physics.OverlapSphere(this.transform.position, radius);
            foreach (Collider hit in hits)
            {
                if (hit != this.GetComponent<Collider>())
                {
                    Rigidbody hitRigidbody = hit.GetComponent<Rigidbody>();
                    if (hitRigidbody != null)
                        hitRigidbody.AddExplosionForce(force, this.transform.position, radius);

                }

                if (hit.transform.tag == "Player" && !hitPlayer)
                {
                    print("Locked");
                    PlayerController playerC = hit.GetComponent<PlayerController>();

                    playerC.Ouch(pulseDamage);
                    hitPlayer = true;
                }
 
            }
            yield return new WaitForSeconds(0.0001f);
            radius += 0.5f;
           // print(radius);
            pulseField.gameObject.transform.localScale += new Vector3(0.0021F, 0.0021f, 0.0021f);
            print (pulseField.gameObject.transform.localScale);
        }
        pulsing = false;
        lerpValue = 0;
        timer = 0;
        Done = true;
        radius = radialLock;
        hitPlayer = false;
        pulseField.gameObject.transform.localScale = hiddenvector;
       
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, radius);
    }


    public void StageChanger()
    {
        stage += -1;
    }
}

