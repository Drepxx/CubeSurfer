using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FinishLine : MonoBehaviour
{
    public GameObject particle;
    public bool isDone;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isDone==false)
        {
            PlayerPrefs.SetInt("Cube", CubeManager.instance.cubes.Count);
            PlayerPrefs.SetInt("Coin", CubeManager.instance.coinCount);
            PlayerPrefs.Save();
            Player.instance.speed = 0;
            Player.instance.horizontalSpeed = 0;
            GameObject spawnedParticle=Instantiate(particle,new Vector3( CubeManager.instance.playerParent.transform.position.x,0, CubeManager.instance.playerParent.transform.position.z), Quaternion.identity);
            isDone = true;
            StartCoroutine(Wait(spawnedParticle));
            
        }
    }
    public IEnumerator Wait(GameObject spawnedParticle)
    {
        for (int j = CubeManager.instance.playerParent.transform.childCount - 1; j >= 0; j--)
        {
            CubeManager.instance.playerParent.transform.GetChild(j).DOScale(Vector3.zero, 0.1f).OnComplete(() =>
            {  
                
                for (int i = CubeManager.instance.playerParent.transform.childCount - 1; i >= 0; i--)
                {
                    CubeManager.instance.playerParent.transform.GetChild(i).transform.DOMoveY(-1, 0.1f).SetRelative();
                }
            });
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        spawnedParticle.SetActive(false);
    }
}
