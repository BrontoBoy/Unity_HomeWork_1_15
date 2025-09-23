using UnityEngine;
using System.Collections;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    private const float SpawnDelay = 2f;
    
    [SerializeField] private int _defaultPoolCapacity = 10;
    [SerializeField] private int _maxPoolSize = 100;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    
    private bool _isSpawningActive = false;
    private WaitForSeconds _spawnWait;
    private IObjectPool<Coin> _coinPool;
    
    private void OnEnable()
    {
        InitializePool();
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

    private void InitializePool()
    {
        _coinPool = new ObjectPool<Coin>(
            createFunc: CreateCoin,
            actionOnGet: OnCoinGet,
            actionOnRelease: OnCoinRelease,
            actionOnDestroy: OnCoinDestroy,
            collectionCheck: true,
            defaultCapacity: _defaultPoolCapacity,
            maxSize: _maxPoolSize
        );
    }
    
    private Coin CreateCoin()
    {
        Coin coin = Instantiate(_coinPrefab, transform);
        coin.gameObject.SetActive(false);
        coin.Collected += OnCoinCollected;
        
        return coin;
    }
    
    private void OnCoinGet(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }
    
    private void OnCoinRelease(Coin coin)
    {
        coin.gameObject.SetActive(false);
        coin.transform.SetParent(transform);
    }
    
    private void OnCoinDestroy(Coin coin)
    {
        coin.Collected -= OnCoinCollected;
        Destroy(coin.gameObject);
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
        if (_coinPool == null || _spawnPoints.Length == 0)
        {
            return;
        }
        
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        Coin coin = _coinPool.Get();
        coin.transform.position = _spawnPoints[randomIndex].position;
    }
    
    private void OnCoinCollected(Coin coin)
    {
        _coinPool.Release(coin);
    }
}