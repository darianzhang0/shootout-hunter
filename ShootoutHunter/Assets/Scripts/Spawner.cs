using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// outlaw, boy, robber, cowboy, proscpector, woman, outlaw2, bandit, cactus man, 
// prisoner, good cow, bad cow, delorean

public class Spawner : MonoBehaviour

{
    public Transform[] spawnPoints;
    public GameObject[] assets;

    public Transform[] stampedeSpawnPoints;
    public GameObject goodCow;
    public GameObject badCow;

    public Transform[] deloreanSpawnPoints;
    public GameObject delorean;

    private float timeToSpawn = 2.0f;
    public float timeBetweenSpawns = 0.7f;

    public bool[] positions = new bool[15];

    void Start()
    {
        timeToSpawn = 2.0f;

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = false;
        }
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawn)
        {
            AssetSpawner();
            timeToSpawn = Time.timeSinceLevelLoad + timeBetweenSpawns;
        }

    }

    void AssetSpawner()
    {
        int spawnOdds = Random.Range(0, 99);

        if (spawnOdds < 93)
        {
            int randomAssetIndex = 0;
            do
            {
                randomAssetIndex = Random.Range(0, spawnPoints.Length);
            }
            while (positions[randomAssetIndex] == true);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i == randomAssetIndex)
                {
                    int Asset = Random.Range(0, assets.Length);
                    Instantiate(assets[Asset], spawnPoints[i].position, Quaternion.identity);
                    positions[randomAssetIndex] = true;
                    AssetFinder(randomAssetIndex, Asset);
                }
            }

            Debug.Log("Normal");
        }

        else if (spawnOdds < 98)
        {
            int randomCowIndex = Random.Range(0, stampedeSpawnPoints.Length);
            int anotherRandomCowIndex = Random.Range(0, stampedeSpawnPoints.Length);

            while (randomCowIndex == anotherRandomCowIndex)
            {
                anotherRandomCowIndex = Random.Range(0, stampedeSpawnPoints.Length);
            }

            for (int i = 0; i < stampedeSpawnPoints.Length; i++)
            {
                if (i == randomCowIndex || i == anotherRandomCowIndex)
                {
                    Instantiate(badCow, stampedeSpawnPoints[i].position, Quaternion.identity);
                }

                else
                {
                    Instantiate(goodCow, stampedeSpawnPoints[i].position, Quaternion.identity);
                }
            }

            Debug.Log("Stampede");
        }

        else
        {
            int randomDeloreanIndex = Random.Range(0, deloreanSpawnPoints.Length);

            for (int i = 0; i < deloreanSpawnPoints.Length; i++)
            {
                if (i == randomDeloreanIndex)
                {
                    Instantiate(delorean, deloreanSpawnPoints[i].position, Quaternion.identity);
                }
            }

            Debug.Log("Delorean");
        }

    }

    void AssetFinder(int spawnPointIndex, int assetIndex)
    {
        switch (assets[assetIndex].name)
        {
            case "Outlaw":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Outlaw.spawnTimer));
                break;
            case "Boy":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Boy.spawnTimer));
                break;
            case "Robber":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Robber.spawnTimer));
                break;
            case "Cowboy":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Cowboy.spawnTimer));
                break;
            case "Prospector":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Prospector.spawnTimer));
                break;
            case "Woman":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Woman.spawnTimer));
                break;
            case "Outlaw2":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Outlaw2.spawnTimer));
                break;
            case "Bandit":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Bandit.spawnTimer));
                break;
            case "CactusMan":
                StartCoroutine(AssetDestroyer(spawnPointIndex, CactusMan.spawnTimer));
                break;
            case "Prisoner":
                StartCoroutine(AssetDestroyer(spawnPointIndex, Prisoner.spawnTimer));
                break;
            default:
                Debug.Log("No Asset Found");
                break;
        }
    }

    IEnumerator AssetDestroyer(int spawnPointIndex, float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        positions[spawnPointIndex] = false;
    }

}

// old Spawner Script
/*
public class Spawner : MonoBehaviour

{
    public Transform[] spawnPoints;
    public GameObject[] assets;

    public Transform[] stampedeSpawnPoints;
    public GameObject goodCow;
    public GameObject badCow;

    public Transform[] deloreanSpawnPoints;
    public GameObject delorean;

    private float timeToSpawn = 2.0f;
    public float timeBetweenSpawns = 0.7f;

    void Start()
    {
        timeToSpawn = 2.0f;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= timeToSpawn)
        {
            AssetSpawner();
            timeToSpawn = Time.timeSinceLevelLoad + timeBetweenSpawns;
        }

    }

    void AssetSpawner()
    {
        int spawnOdds = Random.Range(0, 99);

        if (spawnOdds < 93)
        {
            int randomAssetIndex = Random.Range(0, spawnPoints.Length);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i == randomAssetIndex)
                {
                    int j = Random.Range(0, assets.Length);
                    Instantiate(assets[j], spawnPoints[i].position, Quaternion.identity);
                }
            }

            Debug.Log("Normal");
        }

        else if (spawnOdds < 98)
        {
            int randomCowIndex = Random.Range(0, stampedeSpawnPoints.Length);
            int anotherRandomCowIndex = Random.Range(0, stampedeSpawnPoints.Length);

            while (randomCowIndex == anotherRandomCowIndex)
            {
                anotherRandomCowIndex = Random.Range(0, stampedeSpawnPoints.Length);
            }

            for (int i = 0; i < stampedeSpawnPoints.Length; i++)
            {
                if (i == randomCowIndex || i == anotherRandomCowIndex)
                {
                    Instantiate(badCow, stampedeSpawnPoints[i].position, Quaternion.identity);
                }

                else
                {
                    Instantiate(goodCow, stampedeSpawnPoints[i].position, Quaternion.identity);
                }
            }

            Debug.Log("Stampede");
        }

        else
        {
            int randomDeloreanIndex = Random.Range(0, deloreanSpawnPoints.Length);

            for (int i = 0; i < deloreanSpawnPoints.Length; i++)
            {
                if (i == randomDeloreanIndex)
                {
                    Instantiate(delorean, deloreanSpawnPoints[i].position, Quaternion.identity);
                }
            }

            Debug.Log("Delorean");
        }

    }
}
 */
