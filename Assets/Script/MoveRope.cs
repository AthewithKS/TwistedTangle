using System;
using UnityEngine;

public class MoveRope : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    public Transform selectedObject=null;
    Vector3 OriginalPos;
    float Closer_z_Pos= -1f;

    //For anchor setup
    private float rayDistance = 3f;
    public LayerMask anchorMask;
    public float offset;

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
            AudioManager.Instance.PlaySfx("Pick");
            SelectObject();
        }
        else if(Input.GetMouseButton(0)&& selectedObject!=null)
        {
            MoveSelectedObject();
        }
        else if(Input.GetMouseButtonUp(0)&& selectedObject != null)
        {
            //DeselectObject();
            TrySnapToAnchor();
        }
    }
    private void SelectObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 10f, mask))
        {
            selectedObject = hit.transform;
            OriginalPos = selectedObject.position;
            changeColor(selectedObject,Color.red);

            Vector3 newPosition = selectedObject.position;
            newPosition.z = selectedObject.position.z+Closer_z_Pos;
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
    private void TrySnapToAnchor()
    {
        Ray ray = new Ray(selectedObject.position, Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit,rayDistance,anchorMask))
        {
            AudioManager.Instance.PlaySfx("Place");
            selectedObject.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z -offset);
        }
        else
        {
            AudioManager.Instance.PlaySfx("Cancel");
            selectedObject.position = OriginalPos;
        }
        changeColor(selectedObject, Color.green);
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
