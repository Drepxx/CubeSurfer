using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeManager : MonoBehaviour
{
    public Texture[] texture = new Texture[3];
    public List<GameObject> cubes = new();
    public static CubeManager instance;
    // public GameObject SpawnCube;
    public GameObject playerParent;
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
                playerParent.transform.GetChild(i).transform.DOMoveY(-count, 0.1f * (playerParent.transform.childCount - i)).SetRelative();
            }
            totalCount += count;
            Player.instance.horizontalSpeed = 1;
            isObjectExit = false;
            Debug.Log(playerParent.transform.childCount);
            count = 0;
        }
    }
    public void Color(GameObject textureCube)
    {
        int rnd = Random.Range(0, 3);
        textureCube.GetComponent<MeshRenderer>().material.mainTexture = texture[rnd];
    }
    public void Add(GameObject collectedCube)
    {
        collectedCube.transform.tag = ("Player");
        cubes.Add(collectedCube);
        collectedCube.transform.SetParent(playerParent.transform);
        collectedCube.transform.position = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y - cubes.Count - totalCount, Player.instance.transform.position.z);
        playerParent.transform.DOMoveY(playerParent.transform.position.y + 1, 0.2f);
    }
    public int count = 0;
    public bool isObjectExit;
    public void Remove(GameObject stoppedCube)
    {
        Player.instance.horizontalSpeed = 0;
        stoppedCube.transform.SetParent(null);
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
}
