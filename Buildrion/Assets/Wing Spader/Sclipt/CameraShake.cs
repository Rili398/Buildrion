using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラにあたっちしといてね

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //これをよぶ
    public void Shake(float duration, float magnitude)  //引数　　1,どれくらいやるか：2,どれくらい揺らすか
    {
        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;
            

            yield return null;
        }

        transform.localPosition = pos;
    }
}
