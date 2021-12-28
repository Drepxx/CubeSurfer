using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeManager : MonoBehaviour
{
    //[HideInInspector]
    public Texture[] texture = new Texture[3];
    public GameObject gameOver;
    public List<GameObject> cubes = new();
    public static CubeManager instance;
   // [HideInInspector]
    public GameObject playerParent;
    [HideInInspector]
    public int totalCount = 0;

    public void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isObjectExit)
        {
            for (int i = playerParent.transform.childCount - 1; i >= 0; i--)
            {
                playerParent.transform.GetChild(i).transform.DOMoveY(-count, 0.03f * (playerParent.transform.childCount - i)).SetRelative();
            }
            totalCount += count;
            Player.instance.horizontalSpeed = 1;
            isObjectExit = false;
            count = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
    public void Color(GameObject textureCube)
    {
        int rnd = Random.Range(0, 3);
        textureCube.GetComponent<MeshRenderer>().material.mainTexture = texture[rnd];
    }
    public void Add(GameObject collectedCube)
    {
        int childCount = collectedCube.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            collectedCube.transform.GetChild(0).transform.tag = ("Player");
            cubes.Add(collectedCube.transform.GetChild(0).gameObject);
            collectedCube.transform.GetChild(0).position= new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y - cubes.Count - totalCount, Player.instance.transform.position.z);
            collectedCube.transform.GetChild(0).SetParent(playerParent.transform);
            if (i==childCount-1)
            {
                Destroy(collectedCube);
            }
        }
        playerParent.transform.DOMoveY(playerParent.transform.position.y + childCount, 0.2f);
        
    }
    [HideInInspector]
    public int count = 0;
    [HideInInspector]
    public bool isObjectExit;
    public void Remove(GameObject stoppedCube)
    {
        Player.instance.horizontalSpeed = 0;
        stoppedCube.transform.SetParent(null);
        Destroy(stoppedCube, 1f);
        stoppedCube.tag = ("Untagged");
        cubes.Remove(stoppedCube);
        count++;
        StartCoroutine(Wait());
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.23f);
        isObjectExit = true;
    }
    public int coinCount = 0;
    public GameObject coin;
    public GameObject panel;
    public Sequence seq;
    public void CollectCoin(GameObject collectedCoin)
    {
        seq = DOTween.Sequence();
        coinCount++;
       GameObject coinUI= Instantiate(coin, Camera.main.WorldToScreenPoint(collectedCoin.transform.position), panel.transform.rotation, panel.transform);
        seq.Append(coinUI.transform.DOMove(panel.transform.position, 2));
        seq.Join(coinUI.transform.DOScale(Vector3.one * 0.45f, 2)).OnComplete(()=> { Destroy(coinUI); });
        
    }
    public void GameOver()
    {
        GameObject goldUI = GameObject.Find("UI");
        goldUI.SetActive(false);
        gameOver.SetActive(true);
    }

}
