using UnityEngine;
using UnityEngine.InputSystem;   // NEW input system
//using UnityEvent
using UnityEngine.Events;
using UnityEngine.UI;

public class move_directionscript : MonoBehaviour
{
    [field:SerializeField]
    public UnityEvent OnCollect { get; set; }

    [field: SerializeField]
    public UnityEvent OnHitEnemy { get; set; }

    [field: SerializeField]
    public UnityEvent OnDeath { get; set; }


    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            input.x = -1;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            input.x = 1;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            input.y = 1;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            input.y = -1;

        // Flip the bird so it faces the horizontal movement direction.
        if (input.x > 0)
            spriteRenderer.flipX = true;
        else if (input.x < 0)
            spriteRenderer.flipX = false;

        rb.linearVelocity = input * speed;
    }
}
