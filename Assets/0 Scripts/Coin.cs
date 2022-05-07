using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Coin : MonoBehaviour
{ public bool isDone;
    Vector3 firstPosition;
    public AnimationCurve animationCurve;
    private void Start()
    {
        firstPosition = transform.position;
        CoinMove();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&isDone==false)
        {
            CubeManager.instance.CollectCoin(gameObject);
            isDone = true;
            Destroy(gameObject);
        }
    }
    public void CoinMove()
    {
        transform.DOMove(Vector3.up * .2f,1).SetRelative().SetLoops(-1,LoopType.Yoyo);

    }
}
