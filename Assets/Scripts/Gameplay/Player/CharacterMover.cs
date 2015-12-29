/************************
-------------------------
|*   CharacterMover.cs *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/

using UnityEngine;
using System.Collections;
// Enforces attatchment of reqquired componenet
[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour 
{
    //Variables being declared
    [SerializeField] 
    private Vector3 velocity = Vector3.zero;
    private CharacterController controller = null;
    
    
    /// <summary>
    /// On level start retrieves reference to the PlayerController
    /// to ensure communication between the two scripts
    /// </summary>
 
    public void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }
    /// <summary>
    /// Makes sure the player does not exponentially speed up
    /// and drift off when there is a lack of input by resetting
    /// velocity to zero every frame. Additionally prevents vertical 
    /// floating if the character is already on the ground.
    /// </summary>
    public void ZeroOutVelocity()
    {
        velocity.z = 0;
        velocity.x = 0;

        if (controller.isGrounded == true)
        {
            velocity.y = 0;
        }
    }

    /// <summary>
    /// updates the velocity every frame to move the character
    /// </summary>
    public void Move(float forwardBack, float leftRight)
    {
        velocity += transform.forward * forwardBack;
        velocity += transform.right * leftRight;
    }

    /// <summary>
    /// sets the turn capacity
    /// </summary>
    public void Turn(float turnRate)
    {
        this.transform.Rotate (0, turnRate * Time.deltaTime, 0);
    }

    /// <summary>
    /// Lets the camera move via mouse
    /// </summary>
    public void LookAt(Transform target)
    {
        Vector3 lookAtPoint = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(lookAtPoint);
    }
    /// <summary>
    /// Jump! Self explanatory right? 
    /// runs a check to see if the player is on the ground first
    /// NO DOUBLE JUMPS!!
    /// </summary>
    public void Jump(float speed)
    {
        if (controller.isGrounded == true)
        {
            velocity.y = speed;
        }
    }
    /// <summary>
    /// allows the character to move by applying the velocity
    /// </summary>
    public void LateUpdate()
    {
        velocity += Physics.gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
