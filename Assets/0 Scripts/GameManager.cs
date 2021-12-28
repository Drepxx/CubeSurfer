using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    void Awake()
    {
        PlayerPrefs.GetInt("Level", 0);
    }
    private void Start()
    {
       
    }
}
