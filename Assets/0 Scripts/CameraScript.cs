using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{   public static CameraScript instance;
    public Transform target;
    public Vector3 offset;
    public float smooth;
    private void Start()
    {
        instance = this;
        offset = new Vector3(-4, 4, -1.6f) ;
    }
    void Update()
    {
        if (target==null)
        {
            return;
        }
        Vector3 desiredPosition = target.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
        transform.position = SmoothedPosition;
    }
    public void MoveAway(int childCount)
    {
        offset += Vector3.up * 0.2f*childCount + Vector3.left * 1f*childCount;
    }
    public void MoveClose()
    {
        offset -= Vector3.up * 0.2f + Vector3.left * 1f;
    }
}
