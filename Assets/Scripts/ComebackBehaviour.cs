using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComebackBehaviour : MonoBehaviour
{
    [SerializeField]
    private float startTime;
    [SerializeField]
    private float comebackTime = 0;
    [SerializeField]
    private string buttonName = "";

    private float endTime;
    private string buttonNameP1 = "";
    private string buttonNameP2 = "";
    private int amountP1 = 0;
    private int amountP2 = 0;
    private bool started = false;

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (Input.GetButtonDown(buttonNameP1))
                amountP1++;
            if (Input.GetButtonDown(buttonNameP2))
                amountP2++;
        }
    }

    public void StartComeback()
    {
        startTime = Time.time;
        endTime = startTime + comebackTime;
        started = true;
    }
}
