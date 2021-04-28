using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicBackgroundScroller : MonoBehaviour
{

    [SerializeField]
    private BackgroundTile tilePrefab;

    [SerializeField]
    private Camera cam;

    private BackgroundTile[] background;
    private float[] columnPositions;
    private float[] rowPositions;

    private int backgroundGridWidth;
    private int backgroundGridHeight;

    private float camHeight;
    private float camWidth;

    private Vector2 tileSize;

    private Bounds backgroundBounds;

    private void Reset()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Bounds camBounds = GetCameraBounds();

        while (true)
        {
            if (camBounds.max.x > backgroundBounds.max.x)
            {
                MoveLowestColumnToHighest();
            }
            else if (camBounds.min.x < backgroundBounds.min.x)
            {
                MoveHighestColumnToLowest();
            }
            else if (camBounds.max.y > backgroundBounds.max.y)
            {
                MoveLowestRowToHighest();
            } 
            else if (camBounds.min.y < backgroundBounds.min.y)
            {
                MoveHighestRowToLowest();
            }
            else
            {
                break;
            }
        }
    }

    private Bounds GetCameraBounds()
    {
        Vector3 camPosition = cam.transform.position;
        Vector3 camSize = new Vector3(camWidth, camHeight, 0);
        Bounds cameraBounds = new Bounds(camPosition, camSize);
        return cameraBounds;
    }

    private void MoveLowestColumnToHighest()
    {
        var outerColumnIndices = GetOuterValueIndices(columnPositions);
        int lowestColumn = outerColumnIndices.Item1;
        int highestColumn = outerColumnIndices.Item2;
        float highestColumnX = columnPositions[highestColumn];

        MoveColumn(lowestColumn, highestColumnX + tileSize.x);
        MoveBounds(tileSize.x, 0);
    }

    private void MoveHighestColumnToLowest()
    {
        var outerColumnIndices = GetOuterValueIndices(columnPositions);
        int highestColumn = outerColumnIndices.Item2;
        int lowestColumn = outerColumnIndices.Item1;
        float lowestColumnX = columnPositions[lowestColumn];

        MoveColumn(highestColumn, lowestColumnX - tileSize.x);
        MoveBounds(-tileSize.x, 0);
    }

    private void MoveLowestRowToHighest()
    {
        var outerColumnIndices = GetOuterValueIndices(rowPositions);
        int lowestColumn = outerColumnIndices.Item1;
        int highestRow = outerColumnIndices.Item2;
        float highestRowX = rowPositions[highestRow];

        MoveRow(lowestColumn, highestRowX + tileSize.y);
        MoveBounds(0, tileSize.y);
    }

    private void MoveHighestRowToLowest()
    {
        var outerColumnIndices = GetOuterValueIndices(rowPositions);
        int highestRow = outerColumnIndices.Item2;
        int lowestRow = outerColumnIndices.Item1;
        float lowestRowX = rowPositions[lowestRow];

        MoveRow(highestRow, lowestRowX - tileSize.y);
        MoveBounds(0, -tileSize.y);
    }

    private (int, int) GetOuterValueIndices(float[] array)
    {
        int lowest = 0;
        int highest = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[lowest])
            {
                lowest = i;
            }

            if (array[i] > array[highest])
            {
                highest = i;
            }
        }
        return (lowest, highest);
    }

    private void MoveColumn(int column, float position)
    {
        for (int i = 0; i < backgroundGridHeight; i++)
        {
            int currentTileIndex = column + backgroundGridWidth * i;
            BackgroundTile currentTile = background[currentTileIndex];
            Vector2 currentTilePosition = currentTile.transform.position;
            currentTilePosition.x = position;
            currentTile.MoveTo(currentTilePosition);
        }
        columnPositions[column] = position;
    }

    private void MoveRow(int row, float position)
    {
        for (int i = 0; i < backgroundGridWidth; i++)
        {
            int currentTileIndex = row * backgroundGridWidth + i;
            BackgroundTile currentTile = background[currentTileIndex];
            Vector2 currentTilePosition = currentTile.transform.position;
            currentTilePosition.y = position;
            currentTile.MoveTo(currentTilePosition);
        }
        rowPositions[row] = position;
    }

    private void MoveBounds(float x, float y)
    {
        Vector3 center = backgroundBounds.center;
        center.x += x;
        center.y += y;
        backgroundBounds.center = center;
    }

    private void Awake()
    {
        CreateBackground();

    }

    private void CreateBackground()
    {
        camHeight = cam.orthographicSize * 2;
        camWidth = cam.orthographicSize * cam.aspect * 2;

        tileSize = tilePrefab.GetSize();

        backgroundGridWidth = Mathf.CeilToInt(camWidth  / tileSize.x) + 1;
        backgroundGridHeight = Mathf.CeilToInt(camHeight / tileSize.y) + 1;

        background = new BackgroundTile[backgroundGridWidth * backgroundGridHeight];
        columnPositions = new float[backgroundGridWidth];
        rowPositions = new float[backgroundGridHeight];

        for (int y = 0; y < backgroundGridHeight; y++)
        {
            CreateRow(y);
        }

    }

    private void CreateRow(int rowCount)
    {
        for (int x = 0; x < backgroundGridWidth; x++)
        {
            BackgroundTile tile = CreateTile();
            Vector2 initialPosition = CalculateInitialPosition(x, rowCount);
            tile.transform.parent = transform;
            tile.MoveTo(initialPosition);

            background[rowCount * backgroundGridWidth + x] = tile;

            columnPositions[x] = tile.transform.position.x;
            rowPositions[rowCount] = tile.transform.position.y;

            backgroundBounds.Encapsulate(tile.Renderer.bounds);
        }
        
    }

    private BackgroundTile CreateTile()
    {
        return Instantiate(tilePrefab);
    }

    private Vector2 CalculateInitialPosition(int x, int y)
    {
        Vector2 position = new Vector2();
        position.x = cam.transform.position.x - camWidth / 2 + tileSize.x * x;
        position.y = cam.transform.position.y - camHeight / 2 + tileSize.y * y;
        return position;
    }

    private void OnDrawGizmos()
    {
        Bounds cameraBounds = GetCameraBounds();
        //Gizmos.DrawCube(cameraBounds.center, cameraBounds.size);

        Bounds backBounds = backgroundBounds;
        Gizmos.DrawWireCube(backBounds.center, backBounds.size);
    }

}
