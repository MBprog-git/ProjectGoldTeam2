using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public float smooth = 0.4f;
    public float sensitivity = 6;
    public float limite = 5.0f;

    private Vector3 balance;
    private Vector3 currentAcceleration, initialAcceleration;
    void Start()
    {
        balance = transform.localPosition;
        initialAcceleration = Input.acceleration;
        currentAcceleration = Vector3.zero;
    }   

    void Update()
    {
        currentAcceleration = Vector3.Lerp(currentAcceleration, Input.acceleration - initialAcceleration, Time.deltaTime / smooth);
        balance.x = Mathf.Clamp(currentAcceleration.x * sensitivity, -limite, limite);
        transform.localPosition = balance;
    }
}
