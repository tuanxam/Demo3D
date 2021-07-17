using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class GunController : MonoBehaviour
    {
        public GameObject parExplo_Prefab;
        public TrailEffect trail_Prefab;

        [SerializeField]
        private Transform _head;
        [SerializeField]
        private Camera _fpsCam;

        [SerializeField]
        private bool _isFullAuto;

        [SerializeField]
        private int _fireRate;
        [SerializeField]
        private int _magazines;
        private float _nextShootTime;

        // Start is called before the first frame update
        void Start()
        {
            _nextShootTime = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = _head.rotation;

            if (Input.GetKeyDown(KeyCode.X))
            {
                _isFullAuto = !_isFullAuto;
            }

            //Shoot
            if (_isFullAuto)
            {
                if (Input.GetButton("Fire1") && Time.time >= _nextShootTime)
                {
                    _nextShootTime = Time.time + 1 / _fireRate;
                    var ray = new Ray(_fpsCam.transform.position, _fpsCam.transform.forward);
                    RaycastHit hit;
                    bool isHitSomething = Physics.Raycast(ray, out hit, float.PositiveInfinity);
                    Debug.DrawRay(_fpsCam.transform.position, _fpsCam.transform.forward * 10f, Color.blue);
                    if (isHitSomething)
                    {
                        Debug.Log($"Hit {hit.collider.name}");
                        _magazines--;

                        if(hit.collider.CompareTag("enemy"))
                        {
                            hit.collider.gameObject.GetComponent<Enemy>().Currenthp -= 1;
                            var g = Instantiate(parExplo_Prefab, hit.point, Quaternion.identity);
                            Destroy(g, 1f);

                           TrailEffect trail = Instantiate(trail_Prefab, transform.position, Quaternion.identity);
                           trail.Move(hit.collider.gameObject.transform.position - transform.position);
                        }
                    }
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    var ray = new Ray(_fpsCam.transform.position, _fpsCam.transform.forward);
                    RaycastHit hit;
                    bool isHitSomething = Physics.Raycast(ray, out hit, float.PositiveInfinity);
                    Debug.DrawRay(_fpsCam.transform.position, _fpsCam.transform.forward * 10f, Color.blue);
                    if (isHitSomething)
                    {
                        Debug.Log($"Hit {hit.collider.name}");
                        _magazines--;
                    }
                }
            }
        }
    }
}
