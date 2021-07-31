using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        [SerializeField]
        private int _damage;

        private float _nextShootTime;
        private Vector3 _gunStartPosition;

        // Start is called before the first frame update
        void Start()
        {
            _nextShootTime = 0f;
            _gunStartPosition = transform.localPosition;
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
                        //Debug.Log($"Hit {hit.collider.name}");
                        var shootable = hit.collider.GetComponent<IShootable>();
                        if (shootable != null)
                        {
                            shootable.CurrentHp -= _damage;
                            shootable.InstantiateEffect(parExplo_Prefab, hit.point, Quaternion.identity, 1.0f);

                           //TrailEffect trail = Instantiate(trail_Prefab, transform.position, Quaternion.identity);
                           //trail.Move(hit.collider.gameObject.transform.position - transform.position);
                        }
                    }

                    // Apply gun shake.
                    transform.DOShakePosition(0.2f, 0.01f);
                    _magazines--;
                }
                else
                {
                    // Reset gun position.
                    transform.localPosition = _gunStartPosition;
                    //transform.DOMove(_gunStartPosition, 0.1f);
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
