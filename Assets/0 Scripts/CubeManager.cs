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


    public void Awake()
    {
        instance = this;

    }

    private void Update()
    {
        if (isObjectExit)
        {
           // Player.instance.transform.DOMoveY(-count, 0.2f).SetRelative();
            
            Player.instance.horizontalSpeed = 1;
            isObjectExit = false;
            count = 0;
        }
    }
    public void Color(GameObject textureCube)
    {
        
        int rnd = Random.Range(0, 3);
        textureCube.GetComponent<MeshRenderer>().material.mainTexture=texture[rnd];


    }
    public void Add(GameObject collectedCube)
    {

        collectedCube.transform.tag = ("Player");
        cubes.Add(collectedCube);
        collectedCube.transform.SetParent(Player.instance.transform);
        collectedCube.transform.position = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y - cubes.Count, Player.instance.transform.position.z);
        Player.instance.transform.DOMoveY(Player.instance.transform.position.y + 1, 0.2f);

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
