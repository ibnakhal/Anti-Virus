using UnityEngine;
using System.Collections;

public class TeleporterRoom : MonoBehaviour
{
    [SerializeField]
    public Transform Deposit;
    [SerializeField]
    public bool taken;
    [SerializeField]
    public Transform ownDeposit;

    public void OnTriggerEnter(Collider Other)

    {
        if(Other.tag == "Player")
        {
            Other.transform.position = Deposit.position;
            Other.transform.rotation = Deposit.rotation;
        }
    }






}
