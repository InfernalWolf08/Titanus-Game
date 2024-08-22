using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronNodeController : MonoBehaviour
{
    public MenuController inventory;
    public int maxIron = 25;

    public void gainIron()
    {
        if (maxIron>0)
        {
            maxIron -= 1;
            inventory.addItem("iron ore");
        } else {
            gameObject.SetActive(false);
        }
    }
}