using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnControls;


public class Player : MonoBehaviour
{
    public GameObject panel;
    public GameObject levelText;
    public static Player instance;
    public int speed;
    public float horizontalSpeed;
    [HideInInspector]
    public float slide;
    [HideInInspector]
    public bool isSlide;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        slide = CnInputManager.GetAxis("Vertical");
        if (slide!=0)
        {
            Slide();
        }
        if (isSlide==true||transform.position!=Vector3.zero)
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
    public void Slide()
    {
        isSlide = true;
        panel.SetActive(true);
        levelText.SetActive(false);
    }
}
