using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform player;
    public Transform startPoint;
    public Transform spawnPoint;
    public int totalFlowers = 7;
    public GameObject winText;

    private int collectedFlowers = 0;
    private bool spawnUnlocked = false;
    private bool hasWon = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;

        if (winText != null)
            winText.SetActive(false);
    }

    public void RegisterFlowerCollected()
    {
        if (hasWon) return;
        collectedFlowers++;
    }

    public void ActivateSpawnPoint()
    {
        spawnUnlocked = true;
    }

    public void RespawnPlayer()
    {
        if (player == null) return;

        Transform targetPoint = spawnUnlocked ? spawnPoint : startPoint;
        if (targetPoint == null) return;

        player.position = targetPoint.position;

        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb != null)
            playerRb.linearVelocity = Vector2.zero;
    }

    public void TryWin()
    {
        if (hasWon) return;
        if (collectedFlowers < totalFlowers) return;

        hasWon = true;

        if (winText != null)
            winText.SetActive(true);

        StartCoroutine(RestartAfterWin());
    }

    IEnumerator RestartAfterWin()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
