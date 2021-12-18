using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectibleCubes : MonoBehaviour
{
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
            CameraScript.instance.MoveAway(gameObject.transform.childCount);
            CubeManager.instance.Add(gameObject);
            isDone = true;
        }
    }
}
