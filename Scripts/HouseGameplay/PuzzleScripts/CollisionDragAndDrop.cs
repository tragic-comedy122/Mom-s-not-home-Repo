using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDragAndDrop : MonoBehaviour
{
    public Camera cam;
    public Transform sphere;
    public float distanceFromCamera;
    Rigidbody r;
    public float gravity;

    void Start(){
        distanceFromCamera = Vector3.Distance(sphere.position, cam.transform.position);
        r = sphere.GetComponent<Rigidbody>();
    }

    Vector3 lastPos;

    void OnMouseDrag(){
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = cam.ScreenToWorldPoint(pos);
            r.velocity = (pos - sphere.position) * 10;
    }
    
    void OnMouseUp(){
        r.velocity = Vector3.zero;
    }
    void Update(){
        r.AddForce(new Vector3(0f,gravity, 0f));
    }
}