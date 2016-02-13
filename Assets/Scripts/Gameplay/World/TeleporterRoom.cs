using UnityEngine;
using System.Collections;

public class TeleporterRoom : MonoBehaviour
{
    [SerializeField]
    public Transform Deposit;
    [SerializeField]
    public bool taken;
    [SerializeField]
    public bool cleared;
    [SerializeField]
    public bool bossRoom;
    [SerializeField]
    public Transform ownDeposit;
    [SerializeField]
    private ParticleSystem sys0;
    [SerializeField]
    private ParticleSystem sys1;
    [SerializeField]
    private Material c0;
    [SerializeField]
    private Material c1;
    [SerializeField]
    private Material b0;
    [SerializeField]
    private Material b1;


    public void Update()
    {
        if(Deposit.GetComponentInParent<TeleporterRoom>().cleared)
        {

        }
    }



    public void OnTriggerEnter(Collider Other)

    {
        if(Other.tag == "Player")
        {
            Other.transform.position = Deposit.position;
            Other.transform.rotation = Deposit.rotation;
        }
    }






}
