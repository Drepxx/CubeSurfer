using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    public Text coinText;

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coin:"+CubeManager.instance.coinCount;
    }
}
