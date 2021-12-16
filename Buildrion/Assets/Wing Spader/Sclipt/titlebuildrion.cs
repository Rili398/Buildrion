using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlebuildrion : MonoBehaviour
{
    private Transform mytransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        mytransform = this.gameObject.GetComponent<Transform>();
        Vector3 pos = transform.position;
        pos.y -= 1.0f;

        GameObject efect = (GameObject)Resources.Load("tuchi2");
        Instantiate(efect, pos, Quaternion.identity);

        GameObject shake = (GameObject)Resources.Load("titleshake");
        Instantiate(shake, pos, Quaternion.identity);
    }
}
