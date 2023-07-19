using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpiner : MonoBehaviour
{
    public Transform Wheel;

    public float maxSpeed;
    public float slowDown;

    private string stopAt = "1";

    private bool isStop = false;
    private bool isSpining = false;
    
    private float speed;
    private void OnMouseDown()
    {
        StartSpin();
    }

    private void StartSpin()
    {
        speed = maxSpeed;
        isSpining = true;
    }

    private void FixedUpdate()
    {
        Spining();
    }

    private void Spining()
    {
        Wheel.Rotate(0, Time.deltaTime * speed, 0);
        Stoping();
    }

    private void Stoping()
    {
        if (!isStop) return;
        if (stopAt == Marker.Instance.number) isSpining = false;
        if (isSpining) return;

        speed -= slowDown;
        if (speed < 0) speed = 0;
    }
}
