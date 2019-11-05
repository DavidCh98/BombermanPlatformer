using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothTime = .5f; 
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 30f;
    public float greatestDistance;
    private Vector3 velocity;
    private Camera cam;
    private GameObject player1;
    private GameObject player2;



    void Start()
    {
        player1 = GameObject.Find("CharacterA");
        player2 = GameObject.Find("CharacterB");
        cam = GetComponent<Camera>();
    }
    void LateUpdate() 
    {
        if(targets.Count == 0)
        {
            return;
        }
        Move();  
        Zoom();
    }

    void Move() 
    {
        Vector3 centerPoint = GetCenterPoint();    
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
  
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance()/zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        float dist = Vector3.Distance(player1.transform.position,player2.transform.position); 
        return dist;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
