using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{

    [SerializeField] private CameraShake shake;
    [SerializeField] private float duration, magnitude;
    

    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.Find("Sub Camera");
        shake.Shake(duration, magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
