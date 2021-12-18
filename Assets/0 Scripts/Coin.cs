using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Coin : MonoBehaviour
{ public bool isDone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&isDone==false)
        {
            CubeManager.instance.collectCoin(gameObject);
            isDone = true;
            Destroy(gameObject);
        }
    }
}
