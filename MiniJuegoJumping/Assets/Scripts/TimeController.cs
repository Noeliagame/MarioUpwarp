using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] TextMeshProUGUI time;

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
        if(timing)
        {
            remaining -= Time.deltaTime;
            if(remaining < 1)
            {
                timing = true;
                //Dead of the character
                
            }
            int tempMin = Mathf.FloorToInt(remaining / 60);
            int tempSeg = Mathf.FloorToInt(remaining % 60);
            time.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
