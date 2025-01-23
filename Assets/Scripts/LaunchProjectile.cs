using UnityEngine;
using UnityEngine.InputSystem;
public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 10000f;
    public GameObject ship;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //d�pr�ci�; remplacer par nouveau syst�me d'input
        { 
            Vector3 Position = ship.transform.position;
            GameObject ball = Instantiate(projectile, Position, Quaternion.identity);
            Vector3 force = launchVelocity * transform.forward;
            ball.GetComponent<Rigidbody>().AddRelativeForce(force);
        }  
    }
}
