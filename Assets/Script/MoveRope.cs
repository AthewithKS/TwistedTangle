using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MoveRope : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    public Transform selectedObject;
    float OriginalzPos;
    float CloserzPos= -1f;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastForObjectSelect();
    }
    private void RaycastForObjectSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
        }
        else if(Input.GetMouseButton(0)&& selectedObject!=null)
        {
            MoveSelectedObject();
        }
        else if(Input.GetMouseButtonUp(0)&& selectedObject != null)
        {
            DeselectObject();
        }
    }
    private void SelectObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 10f, mask))
        {
            selectedObject = hit.transform;
            OriginalzPos = selectedObject.position.z;
            changeColor(selectedObject,Color.red);

            Vector3 newPosition = selectedObject.position;
            newPosition.z = selectedObject.position.z+CloserzPos;
            selectedObject.position = newPosition;
        }
    }
    
    private void MoveSelectedObject()
    {
        Vector3 mouspos = Input.mousePosition;
        mouspos.z = 10f;
        Vector3 worldPos = cam.ScreenToWorldPoint(mouspos);
        
        selectedObject.position = new Vector3(worldPos.x,worldPos.y,selectedObject.position.z);
    }
    private void DeselectObject()
    {
        changeColor(selectedObject, Color.green);

        Vector3 newPosition = selectedObject.position;
        newPosition.z = OriginalzPos;
        selectedObject.position = newPosition;

        selectedObject = null;
    }
    private void changeColor(Transform obj, Color color)
    {
        Renderer rendered = obj.GetComponent<Renderer>();
        if(rendered != null)
        {
            rendered.material.color = color;
        }
    }
}
