using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gattai : MonoBehaviour
{
    [SerializeField] private float gtime;

    GameObject parent;

    public void Fusion()
    {
        GameObject buildrion = (GameObject)Resources.Load("cutin 1");
        Instantiate(buildrion, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }



}
