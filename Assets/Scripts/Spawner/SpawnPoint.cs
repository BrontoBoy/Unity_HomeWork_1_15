using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    
    public Coin Spawn()
    {
        Coin coin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        
        return coin;
    }
}
