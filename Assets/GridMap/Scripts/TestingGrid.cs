using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TestingGrid : MonoBehaviour
{
    private GridMap _grid;

    private void Start()
    {
        _grid = new GridMap(4, 2, 10f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _grid.SetValue(UtilsClass.GetMouseWorldPosition(), 20);
        }
    }

}
