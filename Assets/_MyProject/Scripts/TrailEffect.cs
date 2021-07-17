using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    public float move_speed;
    [HideInInspector] public Vector3 Dir;
    void Start()
    {
        
    }
   
    void Update()
    {
        Move(Dir);
    }

    public void Move(Vector3 dir)
    {
        transform.Translate(dir * move_speed);
    }
}
