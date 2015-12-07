using UnityEngine;
using System.Collections;

public class ShootingGA : MonoBehaviour {

    [SerializeField]  
    private Rigidbody bulletPrefab = null;
    [SerializeField]
    private Transform barrel = null;
    [SerializeField]
    float cooldown = 3.0f;
    [SerializeField]
    private bool isCooledDown = true;
    

    /// <summary>
    /// makes sure the assets are found for the gun and the bullet
    /// </summary>
    public void Reset()
    {
        bulletPrefab = Resources.Load<Rigidbody>("Bullet");
        barrel = this.transform.Find("Barrel");
    }

    /// <summary>
    /// if the left mouse button is pressed a bullet is fired
    /// </summary>
    public void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            StartCoroutine("RigidbodyShoot");
        }
    }

    /// <summary>
    /// runs the function of shooting
    /// </summary>
    /// <returns></returns>
    private IEnumerator RigidbodyShoot()
    {
        if (isCooledDown)
        {
            Rigidbody clone = Instantiate(bulletPrefab,
                                           barrel.position,
                                           barrel.rotation) as Rigidbody;

            clone.velocity = barrel.forward * 3;

            isCooledDown = false;

            // this will stop the function for the duration of the cooldown.
            yield return new WaitForSeconds(cooldown);

            isCooledDown = true;
        }
    }

   
}
