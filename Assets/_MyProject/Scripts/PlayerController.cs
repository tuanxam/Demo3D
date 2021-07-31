﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController _instance;
        [SerializeField]
        private CharacterController _characterController;
        [SerializeField]
        private float _movementSpeed = 2.0f;

        [SerializeField]
        private float _jumpHeight = 2.4f;
        [SerializeField]
        private float _gravityValue = 9.81f;
        [SerializeField]

        private Vector3 _playerJumpVelocity;
        private bool _isGrounded;

        [SerializeField]
        private float _checkGroundLength = 1f;
        [SerializeField]
        private LayerMask _groundMask;
        private float _dirY;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
                Destroy(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Biết được đang nhấn lên hay xuống, trái hay phải.
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");  // Trong trường hợp này. Vertical sẽ là trục Z của chúng ta.
            var move = transform.forward * z + transform.right * x; // * cho direction forward(trục z) và right(trục x).

            // Apply movement. 

            //_isGrounded = _characterController.isGrounded;

            //var ray = new Ray(transform.position, Vector3.down);
            //var hitInfo = new RaycastHit();
            //var hitSomething = Physics.Raycast(ray, out hitInfo, _checkGroundLength, _groundMask);
            //if (hitSomething)
            //{
            //    //Debug.Log($"Hit {hitInfo.collider.name}");
            //    _isGrounded = true;
            //}

            // Check for reset jump velocity.
            //if (_isGrounded && _playerJumpVelocity.y < 0)
            //{
            //    _playerJumpVelocity.y = -2.0f;
            //}

            //if (Input.GetButtonDown("Jump") && _isGrounded)
            //{
            //    // Apply jump here.
            //    move.y = _jumpHeight;
            //    //_playerJumpVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            //}

            // Check if player stands on ground.
            var ray = new Ray(transform.position, Vector3.down);
            var hitInfo = new RaycastHit();
            _isGrounded = Physics.Raycast(ray, out hitInfo, _checkGroundLength, _groundMask);

            // Apply jump action.
            if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _dirY = _jumpHeight; 
            }
            // Apply gravity here.
            _dirY -= _gravityValue * Time.deltaTime;
            move.y = _dirY;
            _characterController.Move(move * _movementSpeed * Time.deltaTime);
            // _characterController.Move(_playerJumpVelocity * Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, Vector3.down * _checkGroundLength, Color.red);
        }
    }
}
