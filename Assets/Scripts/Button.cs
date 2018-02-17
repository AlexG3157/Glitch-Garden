    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject prefabToSelect;
    public static GameObject selectedDefender;

    static GameObject clickedDefender;
    

    Color spriteColor = Color.white;

    // Use this for initialization
    void Start () {

        spriteColor.a = .4f;

        gameObject.GetComponent<SpriteRenderer>().color = spriteColor;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(clickedDefender != gameObject)
        {
            spriteColor.a = .4f;
            gameObject.GetComponent<SpriteRenderer>().color = spriteColor;
        }
        

	}

    private void OnMouseDown()
    {
        clickedDefender = gameObject;
        selectedDefender = prefabToSelect;
        spriteColor = Color.white;
        gameObject.GetComponent<SpriteRenderer>().color = spriteColor;
    }
}
