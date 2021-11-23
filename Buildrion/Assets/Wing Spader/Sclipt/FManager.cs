using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FManager : MonoBehaviour
{
    [SerializeField] private float gtime;
    [SerializeField] private float pos_x = 0;
    [SerializeField] private float pos_y = 0;
    [SerializeField] private float pos_z = 0;

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
        Instantiate(tama, new Vector3(1.0f + pos_x, 10.0f + pos_y, -1.0f + pos_z), Quaternion.identity);

        Instantiate(tama, new Vector3(-1.0f + pos_x, 15.0f + pos_y, -1.0f + pos_z), Quaternion.identity);

        Instantiate(tama, new Vector3(-2.0f + pos_x, 20.0f + pos_y, 0.0f + pos_z), Quaternion.identity);

        Instantiate(tama, new Vector3(-1.0f + pos_x, 25.0f + pos_y, 1.0f + pos_z), Quaternion.identity);

        Instantiate(tama, new Vector3(1.0f + pos_x, 30.0f + pos_y, 1.0f + pos_z), Quaternion.identity);

        Instantiate(tama, new Vector3(2.0f + pos_x, 35.0f + pos_y, 0.0f + pos_z), Quaternion.identity);

        Invoke(nameof(Flash), gtime - 1.5f);

        Invoke(nameof(DestroyParts), gtime);

        Invoke(nameof(Birth), gtime);

    }

    private void Birth()
    {
        GameObject buildrion = (GameObject)Resources.Load("Capsule");
        Instantiate(buildrion, new Vector3(0.0f + pos_x, 3.0f + pos_y, 0.0f + pos_z), Quaternion.identity);
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
        Instantiate(hikari, new Vector3(0.0f + pos_x, 1.0f + pos_y, -3.0f + pos_z), Quaternion.identity);
    }

}
