using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.instance.speed = 0;
            StartCoroutine(Wait());

        }



    }
    public IEnumerator Wait()
    {
        for (int j = CubeManager.instance.playerParent.transform.childCount - 1; j >= 0; j--)
        {
            CubeManager.instance.playerParent.transform.GetChild(j).DOScale(Vector3.zero, 0.1f).OnComplete(() =>

            {
                Destroy(CubeManager.instance.playerParent.transform.GetChild(j).gameObject);
                for (int i = CubeManager.instance.playerParent.transform.childCount - 1; i >= 0; i--)
                {
                    CubeManager.instance.playerParent.transform.GetChild(i).transform.DOMoveY(-1, 0.1f).SetRelative();
                }


            });
            yield return new WaitForSeconds(0.2f);
        }
    }
}
