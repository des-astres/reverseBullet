using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class SpawnerOverTime : MonoBehaviour
{
    [SerializeField]
    private float timePeriod;
    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    // Coroutine
    private IEnumerator SpawnCoroutine()
    {
        // Exemples de conditions
        /*CreateSpawner();
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(10);
        yield return new WaitUntil(() => isNewSpawnRequest);
        isNewSpawnRequest = false;
        CreateSpawner();*/

        while (true)
        {
            CreateSpawner();
            yield return new WaitForSeconds(timePeriod);
        }
    }

    /*
    public void RequestNewSpawner()
    {
        isNewSpawnRequest = true;
    }*/
    private void CreateSpawner()
    {
        var spawnerInstance = Instantiate(spawner, transform);
        var enemiesSpawner = spawnerInstance.GetComponent<EnemySpawner>();
        // enemiesSpawner.SetPlayer(player.transform);
    }

    public void StopSpawning()
    {
        if (SpawnCoroutine() == null) 
            return;
        StopCoroutine(SpawnCoroutine());
    }
}
