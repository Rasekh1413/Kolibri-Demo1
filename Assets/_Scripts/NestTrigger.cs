using UnityEngine;

public class NestTrigger : MonoBehaviour
{
    public string playerTag = "Player";
    public bool isSpawnNest = false;
    public bool isEndNest = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;
        if (GameManager.Instance == null) return;

        if (isSpawnNest)
            GameManager.Instance.ActivateSpawnPoint();

        if (isEndNest)
            GameManager.Instance.TryWin();
    }
}
