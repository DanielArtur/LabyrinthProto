using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstantiateRandomRooms : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject[] RoomPrefabs;

    [Header("Settings")]
    [SerializeField] int RoomCount = 10;

    // Spawn Boundaries
    [SerializeField] int maxMinZ = 10;
    [SerializeField] int maxMinY = 3;
    [SerializeField] int maxMinX = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateRooms());
    }


    //public static List<Vector2> GeneratePoints(float radius, Vector2 sampleRegionSize)
    //{
    //    float cellSize = radius / MathF.Sqrt(2);

    //    int[,] grid = new int[Mathf.CeilToInt(sampleRegionSize.x/cellSize), Mathf.CeilToInt(sampleRegionSize.y/cellSize)]; 
    //    List<Vector2> points = new List<Vector2>();
    //    List<Vector2> spawnPoints = new List<Vector2>();

    //    spawnPoints.Add(sampleRegionSize / 2);

    //    while(spawnPoints.Count > 0)
    //    {
    //        int spawnIndex = Random.Range(0, spawnPoints.Count);
    //        Vector2 spawnCentre = spawnPoints[spawnIndex];

    //    }
    //}

    Vector3[] generatedRoomPositions;
    private IEnumerator GenerateRooms()
    {
        generatedRoomPositions = new Vector3[RoomCount - 1];

        int t = 0;
        while (t < RoomCount - 1)
        {
            Vector3 randomPos = new Vector3(Random.Range(-maxMinX, maxMinX), Random.Range(-maxMinY, maxMinY), Random.Range(-maxMinZ, maxMinZ));

            generatedRoomPositions[t] = Instantiate(RoomPrefabs[0], randomPos, Quaternion.identity).transform.position;
            Debug.Log("Cycle");

            t++;

            yield return null;
        }


        DelaunayTriangulation();
    }

    private void DelaunayTriangulation()
    {
        throw new NotImplementedException();
    }




    // Update is called once per frame
    void Update()
    {

    }
}
