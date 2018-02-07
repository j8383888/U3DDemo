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
            if (transform.position.x >= -9)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x <= 9)
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastTime >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            lastTime = Time.time;
        }
    }
}
