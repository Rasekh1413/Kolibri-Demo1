using UnityEngine;

public class FlowerCollect : MonoBehaviour
{
    public string playerTag = "Player";
    [Range(0f, 1f)]
    public float collectedBrightness = 0.3f;

    private SpriteRenderer spriteRenderer;
    private Collider2D[] colliders;
    private bool collected = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliders = GetComponents<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;
        if (!other.CompareTag(playerTag)) return;

        if (GameManager.Instance != null)
            GameManager.Instance.RegisterFlowerCollected();

        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            spriteRenderer.color = new Color(
                collectedBrightness,
                collectedBrightness,
                collectedBrightness,
                color.a
            );
        }

        foreach (Collider2D col in colliders)
            col.enabled = false;

        collected = true;
    }
}
