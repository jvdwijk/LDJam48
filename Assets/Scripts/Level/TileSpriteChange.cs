using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BackgroundTile))]
public class TileSpriteChange : MonoBehaviour
{
    private BackgroundTile tile;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite grass, dirt, gradientDirt, darkDirt;

    [SerializeField]
    private float darkDirtDepth = -100, surfaceDepth = 0;

    private void Awake()
    {
        tile = GetComponent<BackgroundTile>();
        spriteRenderer = tile.Renderer;
        tile.onPositionChange += UpdateSprite;
    }

    private void UpdateSprite(Vector2 newPosition)
    {
        float y = newPosition.y;
        spriteRenderer.enabled = true;
        if (y > surfaceDepth)
        {
            spriteRenderer.enabled = y < tile.GetSize().y;
            spriteRenderer.sprite = grass;
        }else if (y < darkDirtDepth)
        {
            spriteRenderer.sprite = y < darkDirtDepth - tile.GetSize().y ? darkDirt : gradientDirt;
        }
        else
        {
            spriteRenderer.sprite = dirt;
        }
    }

}
