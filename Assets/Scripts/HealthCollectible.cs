using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player == null)
            return;
        if (player.Health >= player.MaxHealth)
            return;
        player.ChangeHealth(1);
        Destroy(gameObject);
    }
}
