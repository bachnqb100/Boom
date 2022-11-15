using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite idleSprite;
    public Sprite[] animationSprites;

    public float animationTime = 0.25f;
    private int animationIndex;

    public bool loop = true;
    public bool idle = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    private void NextFrame()
    {
        animationIndex++;

        if (loop && animationIndex >= animationSprites.Length)
        {
            animationIndex = 0;
        }

        if (idle)
        {
            spriteRenderer.sprite = idleSprite;
        } else if (animationIndex >= 0 && animationIndex < animationSprites.Length)
        {
            spriteRenderer.sprite = animationSprites[animationIndex];
        } 
    }
}
