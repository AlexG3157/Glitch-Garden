using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    StarDisplay starDisplay;
    GameObject parent;

    void Start()
    {

        parent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    void OnMouseDown()
    {
        int cost = Button.selectedDefender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(cost) == StarDisplay.Status.SUCCESS)
        {
            Vector2 defenderPos = SnapToGrid(CalculateWorldPointOfMouseClick());
            GameObject newDef = Instantiate(Button.selectedDefender, defenderPos, Quaternion.identity) as GameObject;
            newDef.transform.parent = parent.transform;
        }
        else
        {
            Debug.Log("Insuficient credits");
        }
        
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float x = Input.mousePosition.x, y = Input.mousePosition.y;
        float distance = 10;
        // distance doesn´t matter, 10 just looks cool 

        Vector3 weirdTriplet = new Vector3(x, y, distance);

        Vector2 worldPosition = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPosition;

    }

    Vector2 SnapToGrid(Vector2 rawPos)
    {
        int newX = Mathf.RoundToInt( rawPos.x), newY = Mathf.RoundToInt( rawPos.y);

        return new Vector2(newX, newY);
    }
}
