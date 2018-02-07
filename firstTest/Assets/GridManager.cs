using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager  {

    private  const int WIDTH = 10;
    private  const int HEIGHT = 20;

    public Transform[,] grid = new Transform[WIDTH, HEIGHT];
    private static GridManager instance;

    public GridManager GetInstance()
    {
        if(null == instance)
        {
            instance = this;
        }
        return instance;
    }

    public bool IsRowFull(int y)
    {
        for (int i = 0; i < WIDTH; i++)
        {
            if (grid[i, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public bool outsideBorder(Transform transf)
    {
        return (transf.position.x >= -9 || transf.position.x <= 9 || transf.position.y >= -10);
    }

    public bool isValidGridPos(Transform transf)
    {
        foreach (Transform child in transf)
        {
            if (outsideBorder(child))
            {
                return false;
            }
        }
        return true;

    }
}
