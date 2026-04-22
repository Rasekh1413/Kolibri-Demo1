using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public string playerTag = "Player";
    public bool playOnce = false;

    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasPlayed && playOnce) return;
        if (!other.CompareTag(playerTag)) return;
        if (audioSource == null) return;

        audioSource.Play();
        hasPlayed = true;
    }
}
