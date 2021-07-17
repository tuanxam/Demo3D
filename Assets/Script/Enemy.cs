using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPS {

    public class Enemy : MonoBehaviour
    {
        public float lookRadius;

        public float maxhp;

        [HideInInspector]
        private float currenthp;


        private NavMeshAgent enemy_ai;

        public float Currenthp { get => currenthp;
            set {
                currenthp = value;
                Debug.Log(currenthp);
                Death();
            }  }

        void Start()
        {
            enemy_ai = GetComponent<NavMeshAgent>();
            Currenthp = maxhp;
        }

        void Update()
        {                     
            if(Vector3.Distance(PlayerController._instance.transform.position, transform.position) <= lookRadius)
            {
                enemy_ai.SetDestination(PlayerController._instance.transform.position);
            }
        }

        private void Death()
        {
            if(Currenthp <= 0)
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
    }
}
