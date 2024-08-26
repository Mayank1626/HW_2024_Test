using System.Collections;
using UnityEngine;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab;
    public Transform[] spawnPoints;
    public float minPulpitDestroyTime = 4f; 
    public float maxPulpitDestroyTime = 5f; 
    public float pulpitSpawnTime = 2.5f;

    private void Start()
    {
        StartCoroutine(SpawnPulpit());
    }

    private IEnumerator SpawnPulpit()
    {
        while (true)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(pulpitPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(pulpitSpawnTime);
        }
    }
}
