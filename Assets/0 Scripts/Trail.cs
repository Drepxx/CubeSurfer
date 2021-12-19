using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    void LateUpdate()
    {
        transform.position =new Vector3(Player.instance.transform.position.x,0.002f,Player.instance.transform.position.z);
       
    }
}
