using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    LevelManager levelMan;

    private void Start()
    {
        levelMan = GameObject.FindObjectOfType<LevelManager>();
        print(levelMan);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Attacker attacker = collider.GetComponent<Attacker>();
        print("lose");
        if (attacker)
        {
            levelMan.LoadLevel("Lose");
        }

    }

}
