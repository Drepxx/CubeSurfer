using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FinishLine : MonoBehaviour
{
    public GameObject particle;
    public bool isDone;
    public GameObject FinishUI;
    public GameObject UI;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isDone == false)
        {
            
            Player.instance.speed = 0;
            Player.instance.horizontalSpeed = 0;
            GameObject spawnedParticle = Instantiate(particle, new Vector3(CubeManager.instance.playerParent.transform.position.x, 0, CubeManager.instance.playerParent.transform.position.z), Quaternion.identity);
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
            CameraScript.instance.MoveClose();
        }
        yield return new WaitForSeconds(0.5f);
        spawnedParticle.SetActive(false);
      
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + CubeManager.instance.coinCount);
        PlayerPrefs.Save();
        UI.SetActive(false);
        FinishUI.SetActive(true);
    }
}
