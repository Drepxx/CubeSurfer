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
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            CubeManager.instance.Color(gameObject.transform.GetChild(i).gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isDone == false)
        {
            CubeManager.instance.Add(gameObject);
            isDone = true;
            CameraScript.instance.MoveAway();
        }
    }
}
