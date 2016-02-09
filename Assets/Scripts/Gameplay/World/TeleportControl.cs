using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleportControl : MonoBehaviour {
    [SerializeField]
    private List<GameObject> TeleLocations;

    // Use this for initialization
   public void KickStarter()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Teleporter");
        foreach (GameObject cur in temp)
        {
            TeleLocations.Add(cur);
        }

        foreach (GameObject curr in TeleLocations)
        {
            TeleporterRoom currTeleRoom = curr.GetComponent<TeleporterRoom>();

            if (!currTeleRoom.taken)
            {
                GameObject rando = TeleLocations[Random.Range(0, TeleLocations.Count)];

                TeleporterRoom randTeleRoom = rando.GetComponent<TeleporterRoom>();

                while (randTeleRoom.taken || randTeleRoom == currTeleRoom)
                {
                    rando = TeleLocations[Random.Range(0, TeleLocations.Count)];
                    randTeleRoom = rando.GetComponent<TeleporterRoom>();
                }

                //if (!currTeleRoom.taken && !randTeleRoom.taken && rando != curr)
                currTeleRoom.Deposit = randTeleRoom.ownDeposit;
                randTeleRoom.Deposit = currTeleRoom.ownDeposit;
                currTeleRoom.taken = true;
                randTeleRoom.taken = true;
            }
        }
    }
}
