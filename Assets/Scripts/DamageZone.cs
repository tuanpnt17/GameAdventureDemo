using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();
        if (player == null)
            return;

        if (player.Health <= 0)
            return;
        player.ChangeHealth(-1);
    }
}
