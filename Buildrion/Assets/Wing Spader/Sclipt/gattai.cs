using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gattai : MonoBehaviour
{

    //無限合体、分離防止用
    bool mode = false;

    [SerializeField] private float gtime;

    //選ばれスイッチ
    bool sle1 = false;
    bool sle2 = false;
    bool sle3 = false;
    bool sle4 = false;
    bool sle5 = false;

    //親
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //合★体

        Fusion();
        Purge();
    }

    void Fusion()
    {
        //フュージョンの'F'を押したら合体
        if (Input.GetKeyDown(KeyCode.F))
        {
            //無限合体防止
            if (mode == false)
            {


                GameObject buildrion = (GameObject)Resources.Load("cutin 1");
                Instantiate(buildrion, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);


                //モード切り替え
                mode = true;

            }

        }
    }

    void Purge()
    {
        //パージの'P'を押したら分離
        if (Input.GetKeyDown(KeyCode.P))
        {
            //無限分離防止
            if (mode == true)
            {

                // 親オブジェクトを探す
                parent = GameObject.Find("parent");

                //ひとまず親子関係だったら表示
                {
                    //非表示処理
                    if (sle1 == true)
                    {
                        Transform tama1 = parent.transform.Find("tama1");
                        //蘇生
                        tama1.gameObject.SetActive(true);

                        //親子関係解除
                        tama1.transform.parent = null;

                        //切り替え
                        sle1 = false;
                    }

                    if (sle2 == true)
                    {
                        Transform tama2 = parent.transform.Find("tama1 (1)");
                        //蘇生
                        tama2.gameObject.SetActive(true);

                        //親子関係解除
                        tama2.transform.parent = null;

                        //切り替え
                        sle2 = false;
                    }

                    if (sle3 == true)
                    {
                        Transform tama3 = parent.transform.Find("tama1 (2)");
                        //蘇生
                        tama3.gameObject.SetActive(true);

                        //親子関係解除
                        tama3.transform.parent = null;

                        //切り替え
                        sle3 = false;
                    }

                    if (sle4 == true)
                    {
                        Transform tama4 = parent.transform.Find("tama1 (3)");
                        //蘇生
                        tama4.gameObject.SetActive(true);

                        //親子関係解除
                        tama4.transform.parent = null;

                        //切り替え
                        sle4 = false;
                    }

                    if (sle5 == true)
                    {
                        Transform tama5 = parent.transform.Find("tama1 (4)");
                        //蘇生
                        tama5.gameObject.SetActive(true);

                        //親子関係解除
                        tama5.transform.parent = null;

                        //切り替え
                        sle5 = false;
                    }
                }

                //デリート
                GameObject buildrion = GameObject.Find("Capsule(Clone)");
                Destroy(buildrion);



                mode = false;
            }

        }
    }

    private void Birth()
    {
        GameObject buildrion = (GameObject)Resources.Load("Capsule");
        Instantiate(buildrion, new Vector3(0.0f, 3.0f, 0.0f), Quaternion.identity);
    }



    private void DestroyParts()
    {
        GameObject[] parts = GameObject.FindGameObjectsWithTag("tama1");

        foreach (GameObject partslist in parts)
        {
            Destroy(partslist);
        }
        
    }

    private void Flash()
    {

        GameObject hikari = (GameObject)Resources.Load("hikari");
        Instantiate(hikari, new Vector3(0.0f, 1.0f, -3.0f), Quaternion.identity);
    }

}
