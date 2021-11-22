using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FManager : MonoBehaviour
{
    [SerializeField] private float gtime;

    // Start is called before the first frame update
    void Start()
    {
        CreateParts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateParts()
    {
        GameObject tama = (GameObject)Resources.Load("tama1");
        Instantiate(tama, new Vector3(1.0f, 10.0f, -1.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(-1.0f, 15.0f, -1.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(-2.0f, 20.0f, 0.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(-1.0f, 25.0f, 1.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(1.0f, 30.0f, 1.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(2.0f, 35.0f, 0.0f), Quaternion.identity);

        Invoke(nameof(Flash), gtime - 1.5f);

        Invoke(nameof(DestroyParts), gtime);

        Invoke(nameof(Birth), gtime);

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
