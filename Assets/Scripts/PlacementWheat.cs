using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlacementWheat : MonoBehaviour, IPointerClickHandler
{
    [Header("Debug")]
    [SerializeField] private bool isDebug = false;
    [SerializeField] private Color debugColor;

    [Space]
    [Header("Placement objects")]
    public GameObject wheat;
    public static bool canPlace = false;
    public static int[,] placementTemp;

    public static GameObject touchHolder;

    private void Start()
    {
        touchHolder = this.gameObject;
        if (isDebug)
        {
            this.GetComponent<Image>().color = debugColor;
        }
        else
        {
            this.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
    }

    public static void SetSize()
    {
        touchHolder.transform.localScale = new Vector3(GridManagement.width - 1f, GridManagement.height - 1f, 0);
        touchHolder.transform.position = new Vector3(GridManagement.width / 2f, GridManagement.height / 2f, 0);
        
        placementTemp = new int[(int)GridManagement.width, (int)GridManagement.height];
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        PlaceWheat(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void PlaceWheat(Vector3 position)
    {
        if (canPlace && placementTemp[(int)Mathf.Round(position.x), (int)Mathf.Round(position.y)] != 1)
        {
            Instantiate(wheat, new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), 0), Quaternion.identity);
            placementTemp[(int)Mathf.Round(position.x), (int)Mathf.Round(position.y)] = 1;
        }
        else Debug.LogWarning("Can't place wheat");
    }

    public static void ChooseStateCanPlace()
    {
        canPlace = !canPlace;
    }
}
