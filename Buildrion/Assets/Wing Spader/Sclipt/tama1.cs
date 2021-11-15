using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class tama1 : MonoBehaviour
{
    public float Multiplier = 3.0f;
    public float speed = 3.0f;
    private Rigidbody myrigidbody;
    private Transform mytransform;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        mytransform = this.gameObject.GetComponent<Transform>();
        Vector3 pos = transform.position;

        GameObject efect = (GameObject)Resources.Load("tuchi");
        Instantiate(efect, pos, Quaternion.identity);
    }

    void FixedUpdate()
    {
        // 加速度与える
        myrigidbody.AddForce((Multiplier - 1f) * Physics.gravity, ForceMode.Acceleration);
    }
}
