using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //private InputActionReference resetActionReference;
    private InputActionReference moveActionReference;
    [SerializeField]
    private float speed = 7.0f;

    private Vector3 A;
    private Vector3 B;
    private float startTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        A = new Vector3(0, 0, 0);
        B = new Vector3(1, 0, 1);
        startTime = Time.time;
        //resetActionReference.action.Enable();
        moveActionReference.action.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        //Oscillate
        /*float x = Mathf.Sin(2 * Mathf.PI * 2 * Time.time);
        transform.position = new Vector3(x, 0, 0); */

        //Reset time if spacebar pressed
        /*if (resetActionReference.action.phase == InputActionPhase.Performed)
            startTime = Time.time;*/

        //Move from A to B
        /* float timeSinceStart = Time.time - startTime;
         Vector3 newPosition = Vector3.Lerp(A, B, timeSinceStart);*/

        //Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        //transform.Translate(frameMovement3D);
        //transform.position += frameMovement3D;

        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x, 0, frameMovement.y);
        Vector3 newPosition = transform.position + frameMovement3D * speed * Time.deltaTime;
        Vector3 direction = newPosition - transform.position; //diff entre nouvelle et ancienne position
        if (direction.magnitude != 0)
        {
            Quaternion playerOrientation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = playerOrientation;
        }
        transform.position = newPosition;
    }
}
