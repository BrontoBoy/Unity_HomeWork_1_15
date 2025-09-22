using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 100;
    
    private IObjectPool<Coin> _pool;
    
    public Coin GetCoin() => Pool.Get();
    public void ReturnCoin(Coin coin) => Pool.Release(coin);
    
    public IObjectPool<Coin> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<Coin>(
                    createFunc: CreateCoin,
                    actionOnGet: OnGetCoin,
                    actionOnRelease: OnReleaseCoin,
                    actionOnDestroy: OnDestroyCoin,
                    collectionCheck: true,
                    defaultCapacity: _defaultCapacity,
                    maxSize: _maxSize
                );
            }
            
            return _pool;
        }
    }
    
    private Coin CreateCoin()
    {
        Coin coin = Instantiate(_coinPrefab, transform);
        coin.gameObject.SetActive(false);
        
        return coin;
    }
    
    private void OnGetCoin(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }
    
    private void OnReleaseCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
        coin.transform.SetParent(transform);
    }
    
    private void OnDestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}