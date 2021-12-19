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
            if (other.gameObject.transform.name=="Player")
            {
                Player.instance.speed = 0;
                Player.instance.horizontalSpeed = 0;
                CubeManager.instance.GameOver();
            }
            else if (Player.instance.speed!=0&&other.gameObject.transform.name!="GameObject")
            {
                CubeManager.instance.Remove(other.gameObject);
                CameraScript.instance.MoveClose();
            }
        }

    }
}
