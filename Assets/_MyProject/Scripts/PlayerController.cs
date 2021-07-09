using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;
        [SerializeField]
        private float _movementSpeed = 2.0f;

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
            _characterController.Move(move * _movementSpeed * Time.deltaTime);
        }
    }
}
