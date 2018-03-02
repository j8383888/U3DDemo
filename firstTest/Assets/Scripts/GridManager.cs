using UnityEngine;

public class GridManager
{

    private const int WIDTH = 20;
    private const int HEIGHT = 20;

    public Transform[,] grid = new Transform [WIDTH, HEIGHT];
    private static GridManager instance;

    public static GridManager GetInstance()
    {
        if(null == instance)
        {
            instance = new GridManager();
        }
        return instance;
    }

    /// <summary>
    /// 一行满了
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool isRowFull(int y)
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

    /// <summary>
    /// 能左移动
    /// </summary>
    /// <param name="transf"></param>
    /// <returns></returns>
    public bool canLeft(Transform transf)
    {
        foreach (Transform child in transf)
        {
            if (child.position.x <= 0)
            {
                return false;
            }
            if (grid[Mathf.RoundToInt(child.position.x) - 1, Mathf.RoundToInt(child.position.y)] != null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 能右移动
    /// </summary>
    /// <param name="transf"></param>
    /// <returns></returns>
    public bool canRight(Transform transf)
    {
        foreach (Transform child in transf)
        {
            if (child.position.x >= 19)
            {
                return false;
            }
            if (grid[Mathf.RoundToInt(child.position.x) + 1, Mathf.RoundToInt(child.position.y)] != null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 能下移动
    /// </summary>
    /// <param name="transf"></param>
    /// <returns></returns>
    public bool canDown(Transform transf)
    {
        foreach (Transform child in transf)
        {    
            
            if (child.position.y <= 0.5)
            {
                return false;
            }
            if (grid[Mathf.RoundToInt(child.position.x), Mathf.RoundToInt(child.position.y) - 1] != null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 能旋转
    /// </summary>
    /// <param name="transf"></param>
    /// <returns></returns>
    public bool canRotate(Transform transf)
    {
        transf.Rotate(0, 0, -90);
        foreach (Transform child in transf)
        {
            if (child.position.y <= 0.5 || child.position.x < -0.1 || child.position.x > 19)
            {
                transf.Rotate(0, 0, +90);
                return false;
            }
            if (grid[Mathf.RoundToInt(child.position.x), Mathf.RoundToInt(child.position.y)] != null)
            {
                transf.Rotate(0, 0, +90);
                return false;
            }
        }
        return true;
    }


    /// <summary>
    /// 删除某一行
    /// </summary>
    /// <param name="y"></param>
    public void deleteRow(int y)
    {
        //删除某一行的所有
        for (int x = 0; x < WIDTH; ++x)
        {
            UnityEngine.Object.Destroy(grid[x, y].gameObject);          
            grid[x, y] = null;
        }
        GameManager.getInstance().GUIManager.addScore();
    }
    /// <summary>
    /// 设置数据
    /// </summary>
    /// <param name="transf"></param>
    public void setData(Transform transf)
    {
        foreach (Transform item in transf)
        {
            int x = Mathf.RoundToInt(item.position.x);
            int y = Mathf.RoundToInt(item.position.y);
            grid[x, y] = item;
        }  
    }
    /// <summary>
    /// 检测是否满行
    /// </summary>
    public void deleteFullRows()
    {
        for (int y = 0; y < HEIGHT;)
        {
            if (isRowFull(y))
            {
                deleteRow(y);

                decreaseRowAbove(y + 1);
            }
            else
            {
                y++;
            }
        }
    }

    //从指定的行数开始检查该行和该行以上的位置，把上面的数据搬到下面
    //1、复制该行的数据到下一行
    //2、清空该行数据
    //3、视觉上的，改变原来的方块的位置 (Y + (-1))
    public void decreaseRowAbove(int y)
    {
        for (; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];   
                    grid[x, y - 1].position += new Vector3(0, -1, 0);
                    grid[x, y] = null;
                }
            }
        }
    }
}
