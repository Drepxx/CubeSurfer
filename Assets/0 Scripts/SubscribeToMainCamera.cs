using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscribeToMainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        CameraScript.instance.target = gameObject.transform;
    }

}
