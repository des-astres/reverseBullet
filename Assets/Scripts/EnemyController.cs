using UnityEngine;
using Unity.VisualScripting;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    [SerializeField]
    Transform target;

    private void Start()
    {
        target = FindFirstObjectByType<PlayerController>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Vector3 newPosition = transform.position + direction.normalized * speed * Time.deltaTime;
        transform.position = newPosition;
        if (direction.magnitude != 0)
        {
            Quaternion playerOrientation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = playerOrientation;
        }
    }
}

