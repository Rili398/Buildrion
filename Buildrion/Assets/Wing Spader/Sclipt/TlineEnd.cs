using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TlineEnd : MonoBehaviour
{

    private PlayableDirector _playableDirector;

    // Start is called before the first frame update
    void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }
    

    // Update is called once per frame
    void Update()
    {
        bool end = IsDone();

        if (end == true)
        {
            Destroy(this.gameObject);
        }
    }

    public bool IsDone()
    {
        return _playableDirector.time >= _playableDirector.duration;
    }
}
