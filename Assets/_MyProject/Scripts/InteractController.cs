using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class InteractController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            bool isHitSomething = Physics.Raycast(ray, out hit, float.PositiveInfinity);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.blue);
            if (isHitSomething)
            {
                if (hit.collider.CompareTag("Item"))
                {
                    Debug.Log($"Hit {hit.collider.name}");
                }
            }
        }
    }
}
