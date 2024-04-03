using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI messageText;

    [SerializeField] Transform endPoint;
    [SerializeField] string winMessage = "¡Felicidades, has ganado!";
    [SerializeField] string loseMessage = "¡Has perdido!";

    private float remaining;
    private bool timing;

    private void Awake()
    {
        remaining = (min * 60) + seg;
        timing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timing)
        {
            remaining -= Time.deltaTime;

            if (remaining <= 0)
            {
                timing = false;
                ShowMessage(loseMessage);
            }
            else
            {
                int tempMin = Mathf.FloorToInt(remaining / 60);
                int tempSeg = Mathf.FloorToInt(remaining % 60);
                timeText.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
            }
        }
    }

    void ShowMessage(string message)
    {
        messageText.text = message;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == endPoint)
        {
            timing = false;
            ShowMessage(winMessage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == endPoint)
        {
            timing = true;
        }
    }
}
