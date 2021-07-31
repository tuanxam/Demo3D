using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FPS
{
    public class FlyingObjectController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _scaleUp;
        [SerializeField]
        private Vector3 _scaleDown;

        // Start is called before the first frame update
        void Start()
        {
            // Example tween... Scaling effect...
            //var scalingTween = transform.DOScale(_scaleUp, 2f).OnComplete(() =>
            //{
            //    transform.DOScale(_scaleDown, 2f);
            //});

            // Example sequence....
            Sequence scaleSeq = DOTween.Sequence();
            scaleSeq.Append(transform.DOScale(_scaleUp, 2f));
            scaleSeq.Append(transform.DOScale(_scaleDown, 2f));
            scaleSeq.Append(transform.DOMove(PlayerController._instance.transform.position, 5f));
            scaleSeq.SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Flash);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
