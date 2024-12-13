using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform[] CylinerPoints;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount= CylinerPoints.Length;
        for (int i = 0; i < CylinerPoints.Length; i++) 
        {
            lineRenderer.SetPosition(i, CylinerPoints[i].position);
        }
    }
}
