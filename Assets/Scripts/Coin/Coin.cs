using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public System.Action<Coin> Collect;
    
    private void Awake()
    {
        Collect += OnCollect;
    }
    
    private void OnCollect(Coin coin)
    {
        Collect -= OnCollect;
        Destroy(gameObject);
    }
    
    private void OnDestroy()
    {
        Collect -= OnCollect;
    }
}
