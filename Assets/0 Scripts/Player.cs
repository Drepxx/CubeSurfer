using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;


public class Player : MonoBehaviour
{
    public static Player instance;
    public int speed;
    public float horizontalSpeed;
    public float slide;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        float horizontal = CnInputManager.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        transform.Translate(Vector3.back * horizontal);
        if (transform.position.z <= -1.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.5f);
        }
        else if (transform.position.z >= 1.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);


    }
}
