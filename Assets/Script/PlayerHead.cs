using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public float mousespeed;
    public Transform playerBody;
    public GameObject gun;
    private float _xRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        float x = Input.GetAxis("Mouse X") * mousespeed * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mousespeed * Time.deltaTime;

        _xRotation -= y;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
         gun.transform.localRotation =  transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        
        playerBody.Rotate(Vector3.up * x);
    }
}
