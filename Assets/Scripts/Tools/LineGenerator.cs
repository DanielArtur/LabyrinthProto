using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script generates lines for triangles using Unity's LineRenderer.
/// </summary>
public class LineGenerator : MonoBehaviour
{
    public static GameObject BlueLineRenderer;
    public static GameObject RedLineRenderer;



    public static LineRenderer[] edges;

    private void Start()
    {
        BlueLineRenderer = Resources.Load("LineForTriangles") as GameObject;
        RedLineRenderer = Resources.Load("RedLineForTriangles") as GameObject;



    }


    public static void CreateLinesForTriangles(List<Triangle> triangles)
    {

        edges = new LineRenderer[triangles.Count];

        for (int i = 0; i < triangles.Count; i++)
        {
            Vector3[] points = { triangles[i].v1.position, triangles[i].v2.position, triangles[i].v3.position, triangles[i].v1.position };

            LineRenderer newLine = Instantiate(BlueLineRenderer, Vector3.zero, Quaternion.identity).GetComponent<LineRenderer>();

            newLine.positionCount = 4;
            newLine.SetPositions(points);

            edges[i] = newLine;


        }





    }

    public static void AddRedLine(Vector3 p1, Vector3 p2)
    {
        Instantiate(RedLineRenderer, p1, Quaternion.identity);


    }


}
