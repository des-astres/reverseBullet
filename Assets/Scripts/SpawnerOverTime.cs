using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpawnerOverTime : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button startButton;
    [SerializeField]
    private float timePeriod;
    [SerializeField]
    private GameObject spawner;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    // Coroutine
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            CreateSpawner();
            yield return new WaitForSeconds(timePeriod);
        }
    }

    private void CreateSpawner()
    {
        var spawnerInstance = Instantiate(spawner, transform);
        var enemiesSpawner = spawnerInstance.GetComponent<EnemySpawner>();
    }

    public void StopSpawning()
    {
        if (SpawnCoroutine() == null) 
            return;
        StopCoroutine(SpawnCoroutine());
    }
}
