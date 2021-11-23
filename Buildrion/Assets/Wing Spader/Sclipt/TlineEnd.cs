using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TlineEnd : MonoBehaviour
{

    private PlayableDirector _playableDirector;
    public GameObject Camera_Active;

    // Start is called before the first frame update
    void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
        Camera_Active = GameObject.Find("Button");
    }
    

    // Update is called once per frame
    void Update()
    {
        bool end = IsDone();

        if (end == true)
        {
            Camera_Active.GetComponent<fillbottom>().Camera_Actve(true, false);
            Destroy(this.gameObject);
        }
    }

    public bool IsDone()
    {
        return _playableDirector.time >= _playableDirector.duration;
    }
}
