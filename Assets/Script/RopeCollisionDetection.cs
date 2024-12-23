using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RopeCollisionDetection : MonoBehaviour
{
    public GameObject startRope, endRope,ParentGameObject;
    public float countDown;
    float StartTime=5f;
    public bool isMoving;
    public bool isColliding;
    private void OnEnable()
    {
        countDown = StartTime;
    }
    private void Update()
    {
        ColorofRope();
        if (!isMoving &&!isColliding)
        {
            StartTimer();
        }
    }
    private void ColorofRope()
    {
        Renderer startRopeColor = startRope.GetComponent<Renderer>();
        Renderer endRopeColor = endRope.GetComponent<Renderer>();
        if (startRopeColor.material.color == Color.red || endRopeColor.material.color==Color.red)
        {
            isMoving = true;
            isColliding = false;
        }
        else isMoving = false;
    }
    private void StartTimer()
    {
        if(countDown>-1f)
        {
            countDown -= Time.deltaTime;
        }
        if(countDown <= 0)
        {
            AudioManager.Instance.PlaySfx("Despawn");
            Destroy(ParentGameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rope"))
        {
            isColliding = true;
            countDown = StartTime;
        }
    }
}
