using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
namespace FPS
{
    public class Enemy : MonoBehaviour, IShootable
    {
        public float lookRadius;
        public float maxhp;

        [SerializeField]
        private MeshRenderer _meshRenderer;
        [SerializeField]
        private Color _colorHit;
        [SerializeField]
        private Color _colorNormal;
        [SerializeField]
        private float _changeColorTime;

        private float currenthp;
        private NavMeshAgent enemy_ai;

        public float CurrentHp
        {
            get => currenthp;
            set
            {
                currenthp = value;
                Debug.Log(currenthp);
                Sequence seq = DOTween.Sequence();
                seq.Append(_meshRenderer.material.DOBlendableColor(_colorNormal, _changeColorTime));
                seq.Append(_meshRenderer.material.DOBlendableColor(_colorHit, _changeColorTime));
                seq.Append(_meshRenderer.material.DOBlendableColor(_colorNormal, _changeColorTime));
                Death();
            }
        }

        void Start()
        {
            enemy_ai = GetComponent<NavMeshAgent>();
            CurrentHp = maxhp;
        }

        void Update()
        {
            if (Vector3.Distance(PlayerController._instance.transform.position, transform.position) <= lookRadius)
            {
                enemy_ai.SetDestination(PlayerController._instance.transform.position);
            }
        }

        private void Death()
        {
            if (CurrentHp <= 0)
            {
                Destroy(gameObject);
            }
        }

        // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        //private void OnDrawGizmosSelected()
        //{

        //}

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }

        public void InstantiateEffect(GameObject effectPrefab, Vector3 hitPosition, Quaternion rotation, float destroyTime)
        {
            var hitEffect = Instantiate(effectPrefab, hitPosition, rotation);
            Destroy(hitEffect, destroyTime);
        }
    }
}
