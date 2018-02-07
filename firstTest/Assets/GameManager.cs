using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :MonoBehaviour
{ 

    public static GameManager instance;


    public GameManager getInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
          return instance;
    }

    
}
