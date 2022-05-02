using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridMap
{
    private int _width;
    private int _height;
    private float _cellSize;
    private int[,] _gridArray;
    private TextMesh[,] _debugTextArray;

    public GridMap(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _gridArray = new int[_width, _height];
        _debugTextArray = new TextMesh[_width, _height];

        for (int i = 0; i < _gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < _gridArray.GetLength(1); j++)
            {
                _debugTextArray[i, j] = UtilsClass.CreateWorldText(_gridArray[i, j].ToString(), null, GetWorldPosition(i, j) +  new Vector3(_cellSize, _cellSize) * .5f, 12, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i , j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1 , j), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, _height), GetWorldPosition(_width, _height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        SetValue(2, 0, 45);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        y = Mathf.FloorToInt(worldPosition.y / _cellSize);
    }

    private bool ValidateGridPosition(int x, int y)
    {
        return x >= 0 && y >= 0 && x < _width && y < _height;
    }

    public void SetValue(int x, int y, int value)
    {
        if (!ValidateGridPosition(x, y)) return;

        _gridArray[x, y] = value;
        _debugTextArray[x, y].text = _gridArray[x, y].ToString();
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        GetXY(worldPosition, out int x, out int y);
        Debug.Log(x + " " + y);
        SetValue(x, y, value);
    }
}
