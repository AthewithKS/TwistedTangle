using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    // Start is called before the first frame update

    [SerializeField] List<Transform> nodes;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        // Ensure the LineRenderer position count is set to the number of nodes
        if (nodes != null && nodes.Count > 0)
        {
            lineRenderer.positionCount = nodes.Count;
        }
    }

    void Update()
    {
        if (nodes != null && nodes.Count > 0)
        {
            // Update the positions of the LineRenderer based on the nodes
            Vector3[] positions = nodes.ConvertAll(n => n.position).ToArray();
            lineRenderer.SetPositions(positions);
        }
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions);
        return positions;
    }

    public float GetWidth()
    {
        return lineRenderer.startWidth;
    }
}
