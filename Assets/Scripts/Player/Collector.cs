using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }
}