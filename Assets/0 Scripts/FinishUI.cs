using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    public Text Coin;
    private void Update()
    {
        Coin.text=("Coin:" + PlayerPrefs.GetInt("Coin"));
    }
}
