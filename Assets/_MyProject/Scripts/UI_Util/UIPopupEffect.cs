using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FPS
{
    public class UIPopupEffect : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _scaleUp;
        [SerializeField]
        private Vector3 _scaleDown;
        [SerializeField]
        private float _duration;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnEnable()
        {
            // Popup effect
            Sequence seq = DOTween.Sequence();
            seq.Append(transform.DOScale(_scaleUp, _duration));
            seq.Append(transform.DOScale(_scaleDown, _duration));
            seq.Append(transform.DOScale(Vector3.one, _duration));
        }
    }
}
