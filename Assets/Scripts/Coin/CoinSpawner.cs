using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    private const float SpawnDelay = 2f;
    
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private CoinPool _coinPool;
    
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
        if (_coinPool == null)
        {
            return;
        }
        
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        Coin coin = _coinPool.GetCoin();
        coin.transform.position = _spawnPoints[randomIndex].position;
        coin.Collected += OnCoinCollected;
    }
    
    private void OnCoinCollected(Coin coin)
    {
        coin.Collected -= OnCoinCollected;
        _coinPool.ReturnCoin(coin);
    }
}