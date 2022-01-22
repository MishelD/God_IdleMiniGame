using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 mouseDownPos, mousePos, startPos;

    [Range(0.1f, 10f)]
    [SerializeField] private float mouseSencity = 2f;

    private void Update()
    {
        // Camera movement

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;

            startPos = Camera.main.transform.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDownPos = Vector3.zero;

            startPos = Camera.main.transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            Camera.main.transform.position = startPos - (mouseDownPos - mousePos) * (-1 * mouseSencity);
        }

        // Camera zoom

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") > 1.1f)
        {
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize + Input.GetAxis("Mouse ScrollWheel") < 20f)
        {
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
        }
    }
}
