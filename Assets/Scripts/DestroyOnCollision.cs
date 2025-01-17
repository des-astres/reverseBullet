using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger enter started on game object {gameObject.name}");
        if (other.tag == "Player" || other.tag == "Projectile")
            Destroy(gameObject);
    }
}
