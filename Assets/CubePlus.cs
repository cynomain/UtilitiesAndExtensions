using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class CubePlus : MonoBehaviour
{
    [Header("Faces")]
    public bool Top = true;
    public bool Bottom = true;
    public bool Front = true;
    public bool Back = true;
    public bool Right = true;
    public bool Left = true;
    [Header("Offset and Size")]
    public Vector3 Offset = new Vector3(0, 0, 0);
    public Vector3 Size = new Vector3(1, 1, 1);

    private MeshFilter filter;

    private void Awake()
    {
        filter ??= GetComponent<MeshFilter>();
        filter.sharedMesh = BuildCube(Offset, Size);
    }

    public Mesh BuildCube(Vector3 offset, Vector3 size)
    {
        Vector3[] vertices = {
        new Vector3 (0, 0, 0),
        new Vector3 (1, 0, 0),
        new Vector3 (1, 1, 0),
        new Vector3 (0, 1, 0),
        new Vector3 (0, 1, 1),
        new Vector3 (1, 1, 1),
        new Vector3 (1, 0, 1),
        new Vector3 (0, 0, 1),
       };

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].Scale(size);
            vertices[i] += offset;
        }
        /*
        int[] triangles = {
        0, 2, 1, //face front
		0, 3, 2,
        2, 3, 4, //face top
		2, 4, 5,
        1, 2, 5, //face right
		1, 5, 6,
        0, 7, 4, //face left
		0, 4, 3,
        5, 4, 7, //face back
		5, 7, 6,
        0, 6, 7, //face bottom
		0, 1, 6
    };
        */
        List<int> triangles = new List<int>();
        if (Front)
        {
            triangles.Add(0);
            triangles.Add(2);
            triangles.Add(1);

            triangles.Add(0);
            triangles.Add(3);
            triangles.Add(2);
        }
        if (Top)
        {
            triangles.Add(2);
            triangles.Add(3);
            triangles.Add(4);

            triangles.Add(2);
            triangles.Add(4);
            triangles.Add(5);
        }
        if (Right)
        {
            triangles.Add(1);
            triangles.Add(2);
            triangles.Add(5);

            triangles.Add(1);
            triangles.Add(5);
            triangles.Add(6);
        }
        if (Left)
        {
            triangles.Add(0);
            triangles.Add(7);
            triangles.Add(4);

            triangles.Add(0);
            triangles.Add(4);
            triangles.Add(3);
        }
        if (Back)
        {
            triangles.Add(5);
            triangles.Add(4);
            triangles.Add(7);

            triangles.Add(5);
            triangles.Add(7);
            triangles.Add(6);
        }
        if (Bottom)
        {
            triangles.Add(0);
            triangles.Add(6);
            triangles.Add(7);

            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(6);
        }

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();

        return mesh;
    }

    public void RebuildCube()
    {
        filter.sharedMesh = BuildCube(Offset, Size);
    }

    private void OnValidate()
    {
        filter ??= GetComponent<MeshFilter>();
        RebuildCube();
    }
}
