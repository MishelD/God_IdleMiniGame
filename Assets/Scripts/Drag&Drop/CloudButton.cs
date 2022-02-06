using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloudButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject cloud;
    private GameObject cloudTemp;

    // Detect current clicks on the button
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Instantiate(cloud);
        cloudTemp = GameObject.FindGameObjectWithTag("Cloud");

        CameraControl.canIsDrag = false;
    }

    // Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Destroy(cloudTemp);

        CameraControl.canIsDrag = true;
    }
}
