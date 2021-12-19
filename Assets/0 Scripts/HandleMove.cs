using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HandleMove : MonoBehaviour
{
    public GameObject slideMove;
    public Sequence seq;
    public float firstPosition;
    private void Start()
    {
        firstPosition = transform.position.x;
        seq = DOTween.Sequence();
        Move();
    }
    void Update()
    {
        if (Player.instance.isSlide==true)
        {
            slideMove.SetActive(false);
        }
    }
    public void Move()
    {
        seq.Append(transform.DOMoveX(750, 1f))
            .Append(transform.DOMoveX(firstPosition, 1f)).SetLoops(-1);
    }
}
