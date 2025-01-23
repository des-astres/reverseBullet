using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const string ANIMATOR_BOOL_IS_RUNNING = "IsRunning";

    [SerializeField] Animator animator;

    [SerializeField]
    private InputActionReference moveActionReference;

    [SerializeField]
    private float speed = 7.0f;

    private Vector3 A;
    private Vector3 B;
    private float startTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        A = new Vector3(0, 0, 0);
        B = new Vector3(1, 0, 1);
        startTime = Time.time;
        moveActionReference.action.Enable();
    }

    private void Update()
    {
        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x, 0, frameMovement.y);
        Vector3 newPosition = transform.position + frameMovement3D * speed * Time.deltaTime;
        Vector3 direction = newPosition - transform.position;
        bool isMoving = direction.magnitude != 0;
        if (isMoving)
        {
            Quaternion playerOrientation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = playerOrientation;
        }
        animator.SetBool(ANIMATOR_BOOL_IS_RUNNING, isMoving);
        transform.position = newPosition;
    }
}
