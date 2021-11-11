using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class tama1 : MonoBehaviour
{
    public float Multiplier = 3.0f;
    public float speed = 3.0f;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // ‰Á‘¬“x—^‚¦‚é
        rigidbody.AddForce((Multiplier - 1f) * Physics.gravity, ForceMode.Acceleration);
    }
}
