using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer renderer;

    public SpriteRenderer Renderer => renderer;

    private void Reset()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public Vector2 GetSize()
    {
        return renderer.bounds.size;
    }

    public void MoveTo(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
}
