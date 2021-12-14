using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDone;
    public static Barrier instance;
    private void Start()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isDone == false)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player!=null)
            {
                Player.instance.speed = 0;
            }
            else
            {
                CubeManager.instance.Remove(other.gameObject);
                CameraScript.instance.offset= new Vector3(CameraScript.instance.offset.x + 0.5f, CameraScript.instance.offset.y - 0.5f, CameraScript.instance.offset.z + 0.1f);
            }
        }

    }
}
