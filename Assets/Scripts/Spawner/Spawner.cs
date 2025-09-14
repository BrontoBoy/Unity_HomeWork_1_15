using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    private const float SpawnDelay = 2f;
    
    [SerializeField] private SpawnPoint[] _spawnPoints;
    
    private bool _isSpawningActive = false;
    private WaitForSeconds _spawnWait;
    
    private void OnEnable()
    {
        _spawnWait = new WaitForSeconds(SpawnDelay);
        StartSpawning();
    }

    private void OnDisable()
    {
        StopSpawning();
    }

    public void StartSpawning()
    {
        if (_isSpawningActive)
        {
            return;
        }

        _isSpawningActive = true;
        StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        _isSpawningActive = false;
    }

    private IEnumerator SpawnRoutine()
    {
        while (_isSpawningActive)
        {
            SpawnSingleCoin();
            
            yield return _spawnWait;
        }
    }

    private void SpawnSingleCoin()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        SpawnPoint chosenSpawnPoint = _spawnPoints[randomIndex];
        Coin coin = chosenSpawnPoint.Spawn();
    }
}
