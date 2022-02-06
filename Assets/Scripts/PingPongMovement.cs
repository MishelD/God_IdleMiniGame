using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    [SerializeField]
    private float hight = 1;//max height of Box's movement
    [SerializeField]
    private Transform yCenter;
    [SerializeField]
    private float speed = 2f;

    void Start()
    {
    }

    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, yCenter.position.y + 0.8f + Mathf.PingPong(Time.time * speed, hight) - hight / 2f, transform.position.z);//move on y axis only
    }
}
