using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectibleCubes : MonoBehaviour
{
    // Start is called before the first frame update
    public static CollectibleCubes instance;
    public bool isDone;
    private void Start()
    {
        instance = this;
        CubeManager.instance.Color(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isDone == false)
        {
            CubeManager.instance.Add(gameObject);
            isDone = true;
            CameraScript.instance.offset = new Vector3(CameraScript.instance.offset.x - 0.5f, CameraScript.instance.offset.y + 0.5f, CameraScript.instance.offset.z - 0.1f);
            
        }

    }
}
