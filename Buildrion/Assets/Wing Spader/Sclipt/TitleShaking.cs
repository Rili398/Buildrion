using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShaking : MonoBehaviour
{
    [SerializeField] private CameraShake shake;
    [SerializeField] private float duration, magnitude;

    private GameObject subCamera;


    // Start is called before the first frame update
    void Start()
    {
        subCamera = GameObject.Find("Main Camera");

        shake = subCamera.GetComponent<CameraShake>();
        shake.Shake(duration, magnitude);

        Singleton<SoundManager>.Instance.PlayBgmByName("bgm_game");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
