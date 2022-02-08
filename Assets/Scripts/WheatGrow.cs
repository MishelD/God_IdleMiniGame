using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheatGrow : MonoBehaviour
{
    [SerializeField] private int growing = 0;
    private int watering = 100;

    [Space]
    [Header("UI")]
    [SerializeField] private Slider waterBar;
    [SerializeField] private GameObject growDoneIcon;

    [Space]
    [Header("Sprite")]
    [SerializeField] private Sprite[] growState;

    private void Start()
    {
        StartCoroutine(Growing());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Watering());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(Watering());
    }

    IEnumerator Watering()
    {
        watering = watering + 10;
        yield return new WaitForSeconds(0.3f);
    }

    IEnumerator Growing()
    {
        for (;;)
        {
            yield return new WaitForSeconds(1);
            if (growing > 99)
            {
                growDoneIcon.SetActive(true);
                yield break;
            }
            else if (watering >= 2 && growing <= 100)
            {
                watering = watering - 2;
                waterBar.value = watering;
                growing++;

                this.gameObject.GetComponent<SpriteRenderer>().sprite = growState[growing / 30];
            }
        }
    }
}
