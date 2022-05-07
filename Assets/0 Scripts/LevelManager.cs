using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool testMode;
    [Header("Son Levelin Tam Sayisi")]
    public int levelCount = 9;
    [Header("Random.Range()'in parametreleri")]
    public int randomMin = 5;
    public int randomMax = 10;
    public Text levelText;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        if (!testMode) OpenCurrentLevel();
    }



    private void OpenCurrentLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("Level",0);
        if (currentLevel > levelCount)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            currentLevel = Random.Range(randomMin, randomMax);
            Instantiate(Resources.Load("Level" + currentLevel));
        }
        else
        {
            Instantiate(Resources.Load("Level" + currentLevel));
        }
        levelText.text = "Level " + (currentLevel + 1).ToString();
    }
}