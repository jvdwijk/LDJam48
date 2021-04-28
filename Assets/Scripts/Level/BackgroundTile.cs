using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public SpriteRenderer Renderer => spriteRenderer;

    public event Action<Vector2> onPositionChange;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public Vector2 GetSize()
    {
        return spriteRenderer.bounds.size;
    }

    public void MoveTo(Vector2 newPosition)
    {
        transform.position = newPosition;
        onPositionChange?.Invoke(newPosition);
    }
}
