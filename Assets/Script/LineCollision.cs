using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph.Legacy;
using UnityEngine;

[RequireComponent(typeof(LineController),typeof(MeshCollider))]
public class LineCollision : MonoBehaviour
{
    private LineController lc;
    private MeshCollider meshCollider;

    private void Awake()
    {
        lc = GetComponent<LineController>();
        meshCollider = GetComponent<MeshCollider>();
    }
    private void FixedUpdate()
    {
        GenerateMeshCollider();
    }
    public void GenerateMeshCollider()
    {
        Mesh mesh = new Mesh();

        // Bake the mesh from the LineRenderer to the mesh
        lc.lineRenderer.BakeMesh(mesh, true);

        // Get the vertices of the mesh
        Vector3[] vertices = mesh.vertices;

        // Convert each vertex from global to local space
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = transform.InverseTransformPoint(vertices[i]);
        }

        // Assign the transformed vertices back to the mesh
        mesh.vertices = vertices;

        // Update the MeshCollider with the new mesh
        meshCollider.sharedMesh = mesh;
    }
}
