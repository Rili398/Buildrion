using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gattai : MonoBehaviour
{
    [SerializeField] private float gtime;

    //êe
    GameObject parent;

    public void Fusion()
    {
        GameObject buildrion = (GameObject)Resources.Load("cutin 1");
        Instantiate(buildrion, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    private void Birth()
    {
        GameObject buildrion = (GameObject)Resources.Load("Capsule");
        Instantiate(buildrion, new Vector3(0.0f, 3.0f, 0.0f), Quaternion.identity);
    }

    private void DestroyParts()
    {
        GameObject[] parts = GameObject.FindGameObjectsWithTag("tama1");

        foreach (GameObject partslist in parts)
        {
            Destroy(partslist);
        }
        
    }

    private void Flash()
    {
        GameObject hikari = (GameObject)Resources.Load("hikari");
        Instantiate(hikari, new Vector3(0.0f, 1.0f, -3.0f), Quaternion.identity);
    }

}
