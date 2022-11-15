using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Windows;

public class GFXEnemy : MonoBehaviour
{
    private AIPath aiPath;

    private Vector2 _direction = Vector2.down;

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activespriteRenderer;


    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        activespriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        if (aiPath.desiredVelocity.y > 0.1f)
        {
            SetDirection(Vector2.up, spriteRendererUp);
        }
        else if (aiPath.desiredVelocity.y < -0.1f)
        {
            SetDirection(Vector2.down, spriteRendererDown);
        }
        else if (aiPath.desiredVelocity.x < -0.1f)
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        }
        else if (aiPath.desiredVelocity.x > 0.1f)
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            SetDirection(Vector2.zero, activespriteRenderer);
        }


    }



    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        _direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activespriteRenderer = spriteRenderer;
        activespriteRenderer.idle = _direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequece();
        }
    }

    private void DeathSequece()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequeceEnded), 1.25f);
    }

    private void OnDeathSequeceEnded()
    {
        gameObject.SetActive(false);
    }
}
