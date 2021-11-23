using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TlineEnd : MonoBehaviour
{

    private PlayableDirector _playableDirector;
    public GameObject Camera_Active;
    public GameObject union_button;
    // Start is called before the first frame update
    void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
        union_button = GameObject.Find("button");
    }
    

    // Update is called once per frame
    void Update()
    {
        bool end = IsDone();

        if (end == true)
        {
            //メインカメラに戻す
            // Camera_Active.GetComponent<fillbottom>().Camera_Actve(true, false);
            //合体ボタン有効
            union_button.GetComponent<fillbottom>().Resetfillamount();

            Destroy(this.gameObject);
        }
    }

    public bool IsDone()
    {
        return _playableDirector.time >= _playableDirector.duration;
    }
}
