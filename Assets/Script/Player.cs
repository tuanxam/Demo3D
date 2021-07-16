using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Player : MonoBehaviour
    {
        public static Player _instace;
        public float move_speed;
        public CharacterController characterController;
        public float gravity;
        public float jumpspeed;
        private float _dirY;

    private void Awake()
    {
        _instace = this;
    }
    void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            Move();
        }
        private void Move()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;



            if (Input.GetKeyDown(KeyCode.Space))
            {
                _dirY = jumpspeed;
            }

            _dirY -= gravity * Time.deltaTime;

            move.y = _dirY;
            characterController.Move(move * move_speed * Time.deltaTime);
        }

    }


