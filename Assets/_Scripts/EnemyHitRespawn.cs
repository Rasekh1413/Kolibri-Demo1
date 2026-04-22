using UnityEngine;

public class EnemyHitRespawn : MonoBehaviour
{
    public string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;
        if (GameManager.Instance == null) return;

        GameManager.Instance.RespawnPlayer();
    }
}
