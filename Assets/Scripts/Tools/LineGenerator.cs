using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script generates lines for triangles using Unity's LineRenderer.
/// </summary>
public class LineGenerator : MonoBehaviour
{

    
    public static LineRenderer[] edges;

    public static void CreateLinesForTriangles(List<Triangle> triangles, GameObject objectWithLineRenderer)
    {

        edges = new LineRenderer[triangles.Count];

        for (int i = 0; i < triangles.Count; i++)
        {
            Vector3[] points = { triangles[i].v1.position, triangles[i].v2.position, triangles[i].v3.position };

            LineRenderer newLine = Instantiate(objectWithLineRenderer, Vector3.zero, Quaternion.identity).GetComponent<LineRenderer>();

            newLine.positionCount = 3;
            newLine.SetPositions(points);

            edges[i] = newLine;


        }





    }



}
