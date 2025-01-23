using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Vector3 startPosition = new Vector3(0, 0, 0);

    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, 2.0f);
    }

    void Spawn()
    {
        Vector3 Position = startPosition + Random.insideUnitSphere * 5;
        Instantiate(Enemy, Position, Quaternion.identity);
    }
}
