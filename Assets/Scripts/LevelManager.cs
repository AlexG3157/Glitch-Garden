using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start()
    {
        if(autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("autoLoad disabled");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
          
    }

    public void LoadLevel(string name) {
        Application.LoadLevel(name);
    }
    public void QuitRecuest() {
        Application.Quit();
    }

    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

   
}
