using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    //çáëÃå≥äiî[ópÇÃïœêî
    string sozai1; 
    string sozai2;
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

        GameObject efect = (GameObject)Resources.Load("tuchi2");
        Instantiate(efect, pos, Quaternion.identity);
    }

    public void SetSozai(string name1, string name2)
    {
        //ëfçﬁì¸ÇÍ
        sozai1 = name1;
        sozai2 = name2;
    }

    public string GetSozai1()
    {
        return sozai1;
    }

    public string GetSozai2()
    {
        return sozai2;
    }
}
