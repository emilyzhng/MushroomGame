using UnityEngine;
using System.Collections.Generic;

public class LootSpawner : MonoBehaviour
{
    public GameObject[] mushroomPrefabs;
    public Transform[] spawnPoints;

    public int numgoal1 = 0;
    public int numgoal2 = 0;
    public int mushindex1;
    public int mushindex2;
    private List<Transform> availableSpawns;

    void Start()
    {

        goalAssignPerDay();
        Debug.Log("Hh " + ButtonManager.Day );
        availableSpawns = new List<Transform>(spawnPoints);

        GoalSpawn();
        SpawnMushroom();
    }

    public void goalAssignPerDay()
    {
        if (ButtonManager.Day == 1) //Day 1 Goals
        {
            mushindex1 = 0;
            numgoal1 = 5;
        }
        else if (ButtonManager.Day == 2) //Day 2 Goals
        {
            mushindex1 = 2;
            numgoal1 = 5;
        }
        else if (ButtonManager.Day == 3) //Day 3 Goals
        {
            mushindex1 = 0;
            numgoal1 = 4;
            mushindex2 = 2;
            numgoal2 = 4;
        }
    }

    public void GoalSpawn() //First do the ones that need to be spawned at least
    {
        // Mush #1 Slot
        for (int i = 0; i < numgoal1 && availableSpawns.Count > 0; i++)
        {
            int randomSpawn = Random.Range(0, availableSpawns.Count);

            Instantiate(
                mushroomPrefabs[mushindex1],
                availableSpawns[randomSpawn].position,
                Quaternion.identity);

            availableSpawns.RemoveAt(randomSpawn);
        }

        // Mush #2 Slot
        for (int i = 0; i < numgoal2 && availableSpawns.Count > 0; i++)
        {
            int randomSpawn = Random.Range(0, availableSpawns.Count);

            Instantiate(
                mushroomPrefabs[mushindex2],
                availableSpawns[randomSpawn].position,
                Quaternion.identity);

            availableSpawns.RemoveAt(randomSpawn);
        }
    }

    public void SpawnMushroom() // Spawn Rest of Spots Randomly
    {
        foreach (Transform spawnPoint in availableSpawns)
        {
            int randomMushroomIndex = Random.Range(0, mushroomPrefabs.Length);

            Instantiate(
                mushroomPrefabs[randomMushroomIndex],
                spawnPoint.position,
                Quaternion.identity);
        }
    }
}