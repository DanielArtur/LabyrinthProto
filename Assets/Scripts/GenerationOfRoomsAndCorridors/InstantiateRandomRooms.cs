using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstantiateRandomRooms : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject[] RoomPrefabs;
    [SerializeField] GameObject LineRendererPrefab;


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

    /// <summary>
    /// 1st step: Generate rooms with random positions
    /// </summary>
    /// <returns></returns>
    private IEnumerator GenerateRooms()
    {

        List<Vector3> generatedRoomPositions = new List<Vector3>();


        for (int i = 0; i < RoomCount; i++)
        {
            // Generate random position for a new room:
            Vector3 randomPos = new Vector3(Random.Range(-maxMinX, maxMinX), Random.Range(-maxMinY, maxMinY), Random.Range(-maxMinZ, maxMinZ));

            // Create room
            GameObject newRoom = Instantiate(RoomPrefabs[0], randomPos, Quaternion.identity);

            // Store the position of this room:
            generatedRoomPositions.Add(newRoom.transform.position);

            Debug.Log("Cycle");



            yield return null;
        }

        // Step 2: Create triangles from the location of the rooms usin Incremental triangulation with Dalaunay algorithm to get even triangles: 
        List<Triangle> newTriangles = DelaunayTriangulation.TriangulateByFlippingEdges(generatedRoomPositions);
        
        // Step 3.5: Create LineRenderers to mark those triangles in 3d-world. This is done for debugging. 
        //LineGenerator.CreateLinesForTriangles(newTriangles, LineRendererPrefab);
    }




    // Update is called once per frame
    void Update()
    {

    }
}
