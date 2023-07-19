using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArrow : MonoBehaviour
{
    public Transform Wheel;

    public float maxSpeed;
    public float slowDown;
    
    private float speed;
    private void OnMouseDown()
    {
        StartSpin();
    }

    private void StartSpin()
    {
        speed = maxSpeed;
    }

    private void FixedUpdate()
    {
        Spining();
    }

    private void Spining()
    {
        Wheel.Rotate(0, Time.deltaTime * speed, 0);
        speed -= slowDown;
        if (speed < 0)speed = 0;
    }
}
