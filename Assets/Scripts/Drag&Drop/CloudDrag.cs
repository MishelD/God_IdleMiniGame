using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrag : MonoBehaviour
{
    private Vector3 mousePos;

    private void Awake()
    {
        mousePos.z = 0;
    }

    private void Update()
    {
        mousePos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mousePos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        transform.position = mousePos;
    }
}
