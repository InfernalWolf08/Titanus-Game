using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    public GameObject on;
    public GameObject[] off;

    public void m_switch()
    {
        on.SetActive(true);

        foreach (GameObject item in off)
        {
            item.SetActive(false);
        }
    }
}