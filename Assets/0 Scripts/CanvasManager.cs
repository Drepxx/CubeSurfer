using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    public Text coinText;
    public Text cubeText;
    // Update is called once per frame
    void Update()
    {
        coinText.text = " x "+CubeManager.instance.coinCount;
        cubeText.text = "Cube:" + CubeManager.instance.cubes.Count;
    }
}
