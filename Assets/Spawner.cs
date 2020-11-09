using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float Time_Btw_Spwn = 2f;

    public bool randomiseSpawnPoint;
    public float minSpawnPoint;
    public float maxSpawnPoint;
    public GameObject asteroidPrefab;
    private float timer;
    void Update()
    {
        timer -= Time.deltaTime;//просто таймер

        if(timer <= 0)
        {
            SpawnAsteroid();
            ResetTimer();
        }
    }
    private void SpawnAsteroid()//тут спавним астероид причем в рандомном месте диапазона
    {
        Vector2 currentPosition = transform.position;
        if(randomiseSpawnPoint)
        {
            float randomPos = UnityEngine.Random.Range(minSpawnPoint,maxSpawnPoint);
            currentPosition += (Vector2)transform.right * randomPos;
        }
       GameObject asteroid = Instantiate(asteroidPrefab);
        asteroid.transform.position = currentPosition;
        asteroid.transform.rotation = transform.rotation;
    }

    private void ResetTimer()
    {
        timer = Time_Btw_Spwn;
    }
}
