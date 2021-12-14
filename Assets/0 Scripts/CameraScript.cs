using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{   public static CameraScript instance;
    public Transform target;
    public Vector3 offset;
    float smooth;
    private void Start()
    {
        instance = this;
        //offset = new Vector3(-10, 5, -2);
        offset = new Vector3(-4, 4, -1.6f) ;
    }
    void Update()
    {
        transform.position = target.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, target.position, smooth);
        transform.position = SmoothedPosition;
    }
}
