using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public TerrainData terrain = null;
    public GameObject treeInteractable;
    public int woodLeft = 50;
    public MenuController inv;

    void Start()
    {
        // Place interaction colliders at the start of the game
        if (terrain!=null)
        {
            foreach (TreeInstance tree in terrain.treeInstances)
            {
                Vector3 treePos = Vector3.Scale(tree.position, terrain.size) + Terrain.activeTerrain.transform.position;
                Instantiate(treeInteractable, treePos, Quaternion.identity, transform);
            }
        }
    }

    public void gainWood()
    {
        if (woodLeft>0)
        {
            woodLeft -= 1;
            inv.addItem("wood");
        } else {
            print("No more wood");
        }
    }
}