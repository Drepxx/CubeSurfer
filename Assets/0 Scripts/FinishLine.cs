using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FinishLine : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("aa");
            Player.instance.speed = 0;
            Instantiate(particle,new Vector3( CubeManager.instance.playerParent.transform.position.x,0, CubeManager.instance.playerParent.transform.position.z), Quaternion.identity);
            particle.Play(true);
            StartCoroutine(Wait());
            particle.Stop();
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
