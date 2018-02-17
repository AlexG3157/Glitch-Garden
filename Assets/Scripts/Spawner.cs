using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabArray;

    private void Update()
    {
        foreach ( GameObject thisAtacker in prefabArray)
        {
            if (isTimeToSpawn(thisAtacker))
            {
                Spawn(thisAtacker);
            }
        }
    }

    void Spawn(GameObject myGameObject)
    {

       GameObject newGameObject = Instantiate(myGameObject, transform.position, Quaternion.identity) as GameObject;

        newGameObject.transform.parent = transform;

    }

    bool isTimeToSpawn(GameObject attackerGameObject)
    {

        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSeconds = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn capped by fps");
        }

        float threshold = spawnsPerSeconds * Time.deltaTime / 5;

        if(Random.value < threshold)
        {
            return true;
        }

        return false;
    }

}
