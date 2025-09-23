using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public event System.Action<Coin> Collected;
    
    public void Collect()
    {
        Collected?.Invoke(this);
    }
}