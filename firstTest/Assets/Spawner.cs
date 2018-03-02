using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject[] groups;
    // Use this for initialization
    void Start () {
        PlayNext();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 播放
    /// </summary>
    public void PlayNext()
    {
        int i = Random.Range(0, groups.Length);
        GameObject ins = Instantiate(groups[i], transform.position, Quaternion.identity) as GameObject;
        ins.AddComponent<Move>();
    }
}
