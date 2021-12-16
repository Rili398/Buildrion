using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private Transform mytransform;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false);
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

        GameObject shake = (GameObject)Resources.Load("shake");
        Instantiate(shake, pos, Quaternion.identity);
        Singleton<SoundManager>.Instance.PlaySeByName("big_robo_tyakuti");
        Destroy(this.gameObject, 5.0f);
    }

}
