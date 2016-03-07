/************************
-------------------------
|*   CameraControl.cs  *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/
using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
    [SerializeField]  
    private Transform player = null, cameraPivot = null;
    [SerializeField]
    private string horizontalInput = "Mouse X", verticalInput = "Mouse Y";
    [SerializeField]
    private float minY = -80f, maxY = 80f, rotationY = 0;
    [SerializeField]
    private float mouseSensitivity;

    /// <summary>

    /// </summary>
    public void Start()
    {
        
    }
    // some comments on whats going on here
    public void Reset()
    {
        player = this.transform;
        cameraPivot = GetComponentInChildren<Camera>().transform.parent;
        Cursor.visible = false;
    }

    public void Update()
    {

        if(Time.timeScale == 0)
        {
            return;
        }

       // rotates the player left/right
        float leftRight = Input.GetAxis(horizontalInput) * mouseSensitivity;
        player.Rotate(0, leftRight, 0);



        //look up and down
        float upDown = Input.GetAxis(verticalInput) * mouseSensitivity;
        rotationY -= upDown;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        cameraPivot.eulerAngles = new Vector3(rotationY, cameraPivot.eulerAngles.y, cameraPivot.eulerAngles.z);
    }
}

