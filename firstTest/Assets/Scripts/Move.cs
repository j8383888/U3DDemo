using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    float lastTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
   
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (GridManager.GetInstance().canLeft(transform))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (GridManager.GetInstance().canRight(transform))
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (GridManager.GetInstance().canRotate(transform))
            {
                
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastTime >= 1)
        {
            lastTime = Time.time;

            if (GridManager.GetInstance().canDown(transform))
            {              
                transform.position += new Vector3(0, -1, 0);              
            }
            else
            {
                brickFinish();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            while(GridManager.GetInstance().canDown(transform))
            {
                transform.position += new Vector3(0, -1, 0);
            }
            brickFinish();
        }
    }

    public void brickFinish()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);
        //设置数据
        GridManager.GetInstance().setData(transform);
        //移除组件
        Destroy(transform.GetComponent<Move>());
        //检测是否可移除方块
        GridManager.GetInstance().deleteFullRows();

        //播放下一个俄罗斯方块
        FindObjectOfType<Spawner>().PlayNext();
    }

}
