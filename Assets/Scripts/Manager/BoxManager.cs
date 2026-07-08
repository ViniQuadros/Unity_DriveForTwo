using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxManager : MonoBehaviour
{
    public GameObject boxPrefab;
    [SerializeField] private Transform[] spawnPoints;

    void Start()
    {
        SpawnBox();
    }

    public void SpawnBox()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
