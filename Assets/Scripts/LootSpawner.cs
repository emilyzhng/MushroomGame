using UnityEngine;
using System.Collections.Generic;

public class LootSpawner : MonoBehaviour
{
    public GameObject[] mushroomPrefabs;
    public Transform[] spawnPoints;

    public int numgoal1 = 0;
    public int numgoal2 = 0;
    public int mushindex1 = 0;
    public int mushindex2 = 2;
    public int mushindex3;
    public int numgoal3;

    private List<Transform> availableSpawns;

    void Start()
    {
        goalAssignPerDay();
        Debug.Log("Day " + ButtonManager.Day);

        FilterSpawnPoints();

        GoalSpawn();
        SpawnMushroom();
    }

    public void goalAssignPerDay()
    {
        if (ButtonManager.Day == 1)
        {
            mushindex1 = 0;
            numgoal1 = 2;

            mushindex2 = 2;
            numgoal2 = 2;
        }
        else if (ButtonManager.Day == 2)
        {
            mushindex1 = 2;
            numgoal1 = 3;

            mushindex2 = 4;
            numgoal2 = 3;
        }
        else if (ButtonManager.Day == 3)
        {
            mushindex2 = 4;
            numgoal2 = 2;
            mushindex2 = 2;
            numgoal2 = 2;
            mushindex2 = 6;
            numgoal2 = 3;

        }
    }

    public void FilterSpawnPoints()
    {
        availableSpawns = new List<Transform>();

        foreach (Transform point in spawnPoints)
        {
            SpawnPoint spawn = point.GetComponent<SpawnPoint>();

            if (spawn != null && spawn.region == ButtonManager.Day)
            {
                availableSpawns.Add(point);
            }
        }
    }

    public void GoalSpawn()
    {
        // Goal Mushroom 1
        for (int i = 0; i < numgoal1 && availableSpawns.Count > 0; i++)
        {
            int randomSpawn = Random.Range(0, availableSpawns.Count);

            Instantiate(
                mushroomPrefabs[mushindex1],
                availableSpawns[randomSpawn].position,
                Quaternion.identity
            );

            availableSpawns.RemoveAt(randomSpawn);
        }

        // Goal Mushroom 2
        for (int i = 0; i < numgoal2 && availableSpawns.Count > 0; i++)
        {
            int randomSpawn = Random.Range(0, availableSpawns.Count);

            Instantiate(
                mushroomPrefabs[mushindex2],
                availableSpawns[randomSpawn].position,
                Quaternion.identity
            );

            availableSpawns.RemoveAt(randomSpawn);
        }
    }

    public void SpawnMushroom()
{
    foreach (Transform spawnPoint in availableSpawns)
    {
        int randomMushroomIndex;

        if (ButtonManager.Day == 1)
        {
            // Only mushrooms 0 and 1
            randomMushroomIndex = Random.Range(0, 4);
        }
        else if (ButtonManager.Day == 2)
        {
            // Mushrooms 0,1,2
            randomMushroomIndex = Random.Range(2, 6);
        }
        else
        {
            randomMushroomIndex = Random.Range(2, mushroomPrefabs.Length);
        }

        Instantiate(
            mushroomPrefabs[randomMushroomIndex],
            spawnPoint.position,
            Quaternion.identity
        );
    }
}
}