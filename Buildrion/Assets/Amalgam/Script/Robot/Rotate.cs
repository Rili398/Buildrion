using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    void Update()
    {
        transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);
    }
}
