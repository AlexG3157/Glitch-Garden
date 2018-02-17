using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float lvlDuration;
    public Text text;

    AudioSource audio;
    LevelManager lvlMan;
    float pct;
    Slider slider;
    bool levelIsEnded = false;

    void Start () {

        lvlMan = GameObject.FindObjectOfType<LevelManager>();
        slider = GetComponent<Slider>();
        audio = GetComponent<AudioSource>();
        
	}
	
	void Update () {

        float pct = Time.timeSinceLevelLoad / lvlDuration;
        slider.value = pct;
      

        if(pct >= 1 && !levelIsEnded)
        {
            audio.Play();
            text.text = "You Survived!!"; 
            Invoke("LevelFinished", audio.clip.length);
            levelIsEnded = true;
        }
	}

    void LevelFinished()
    {

        lvlMan.LoadNextLevel();
    }
}
