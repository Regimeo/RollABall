using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woosh : MonoBehaviour
{
    public float speed = 1.0F;
    public Transform startMarker;
    public Transform endMarker;
    public float currentPosition = 0.0f;
    void Start()
    {

    }
    void Update()
    {
        currentPosition += speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.PingPong (currentPosition * speed, 5f), transform.position.y, Mathf.PingPong(currentPosition * speed, 5f));
    }
}