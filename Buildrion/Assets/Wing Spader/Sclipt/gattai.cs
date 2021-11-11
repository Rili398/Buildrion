using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gattai : MonoBehaviour
{
    //素材格納
    //private List<string> mList = new List<string>();
    //int count = 0;

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

        //ここは合体してたらやっちゃダメ
        if (mode == false)
        {
            {
                //親子切り替え
                /*{
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        //親オブジェ取得
                        GameObject parent = GameObject.Find("parent");

                        //子オブジェにするやーつ
                        GameObject tama = GameObject.Find("tama1");

                        if (sle1 == false)
                        {
                            //子にする処理
                            tama.transform.parent = parent.transform;

                            //切り替え
                            sle1 = true;
                        }
                        else
                        {
                            //子オブジェクト解除
                            tama.transform.parent = null;

                            //切り替え
                            sle1 = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        //親オブジェ取得
                        GameObject parent = GameObject.Find("parent");

                        //子オブジェにするやーつ
                        GameObject tama = GameObject.Find("tama1 (1)");

                        if (sle2 == false)
                        {
                            //子にする処理
                            tama.transform.parent = parent.transform;

                            //切り替え
                            sle2 = true;
                        }
                        else
                        {
                            //子オブジェクト解除
                            tama.transform.parent = null;

                            //切り替え
                            sle2 = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        //親オブジェ取得
                        GameObject parent = GameObject.Find("parent");

                        //子オブジェにするやーつ
                        GameObject tama = GameObject.Find("tama1 (2)");

                        if (sle3 == false)
                        {
                            //子にする処理
                            tama.transform.parent = parent.transform;

                            //切り替え
                            sle3 = true;
                        }
                        else
                        {
                            //子オブジェクト解除
                            tama.transform.parent = null;

                            //切り替え
                            sle3 = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        //親オブジェ取得
                        GameObject parent = GameObject.Find("parent");

                        //子オブジェにするやーつ
                        GameObject tama = GameObject.Find("tama1 (3)");

                        if (sle4 == false)
                        {
                            //子にする処理
                            tama.transform.parent = parent.transform;

                            //切り替え
                            sle4 = true;
                        }
                        else
                        {
                            //子オブジェクト解除
                            tama.transform.parent = null;

                            //切り替え
                            sle4 = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha5))
                    {
                        //親オブジェ取得
                        GameObject parent = GameObject.Find("parent");

                        //子オブジェにするやーつ
                        GameObject tama = GameObject.Find("tama1 (4)");

                        if (sle5 == false)
                        {
                            //子にする処理
                            tama.transform.parent = parent.transform;

                            //切り替え
                            sle5 = true;
                        }
                        else
                        {
                            //子オブジェクト解除
                            tama.transform.parent = null;

                            //切り替え
                            sle5 = false;
                        }
                    }*/
            }
        }

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
                {
                    //合体と生成
                    //   合体元取得

                    //GameObject obj = GameObject.FindGameObjectWithTag("Capsule");

                    //GameObject tama1 = GameObject.FindGameObjectWithTag("tama1");
                    //GameObject tama2 = GameObject.FindGameObjectWithTag("tama2");


                    //カプセルプレハブをGameObject型で取得
                    //GameObject obj = (GameObject)Resources.Load("Capsule");
                    //カプセルプレハブを元に、インスタンスを生成、
                    //GameObject robo = Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);

                    //Capsule c = robo.GetComponent<Capsule>();


                    //引数に合体元のゲームオブジェクトを指定しとく
                    //c.SetSozai(tama1.name, tama2.name);

                    //破壊
                    //Destroy(tama1);
                    //Destroy(tama2);

                    //obj.gameObject.SetActive(true);

                    //tama1.gameObject.SetActive(false);
                    //tama2.gameObject.SetActive(false);

                    //mode = true;
                }

                //ひとまず親子関係だったら非表示
                {  
                    ////非表示処理
                    //if (sle1 == true)
                    //{
                    //    Transform tama1 = parent.transform.Find("tama1");
                    //    tama1.gameObject.SetActive(false);
                    //}

                    //if (sle2 == true)
                    //{
                    //    Transform tama2 = parent.transform.Find("tama1 (1)");
                    //    tama2.gameObject.SetActive(false);
                    //}

                    //if (sle3 == true)
                    //{
                    //    Transform tama3 = parent.transform.Find("tama1 (2)");
                    //    tama3.gameObject.SetActive(false);
                    //}

                    //if (sle4 == true)
                    //{
                    //    Transform tama4 = parent.transform.Find("tama1 (3)");
                    //    tama4.gameObject.SetActive(false);
                    //}

                    //if (sle5 == true)
                    //{
                    //    Transform tama5 = parent.transform.Find("tama1 (4)");
                    //    tama5.gameObject.SetActive(false);
                    //}
                }


                Invoke(nameof(CreateParts), 1.0f);

                GameObject buildrion = (GameObject)Resources.Load("cutin 1");
                Instantiate(buildrion, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);




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
                {
                    //分離と生成
                    //合体元取得
                    //GameObject obj = GameObject.FindGameObjectWithTag("Capsule");
                    //Capsule c = obj.GetComponent<Capsule>();

                    //GameObject tama1 = GameObject.FindGameObjectWithTag("tama1");
                    //GameObject tama2 = GameObject.FindGameObjectWithTag("tama2");

                    //使ってた素材の取得
                    //string sozai1 = c.GetSozai1();
                    //string sozai2 = c.GetSozai2();

                    //ロード
                    //GameObject sobj1 = (GameObject)Resources.Load(sozai1);
                    //GameObject sobj2 = (GameObject)Resources.Load(sozai2);


                    //生成
                    //Instantiate(sobj1, new Vector3(-1.0f, 2.0f, 0.0f), Quaternion.identity);
                    //Instantiate(sobj2, new Vector3(1.0f, 2.0f, 0.0f), Quaternion.identity);

                    //破壊
                    //Destroy(obj);

                    //obj.gameObject.SetActive(false);

                    //tama1.gameObject.SetActive(true);
                    //tama2.gameObject.SetActive(true);

                    //mode = false;
                }

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
        Instantiate(buildrion, new Vector3(0.0f, 4.0f, 0.0f), Quaternion.identity);
    }

    private void CreateParts()
    {
        GameObject tama = (GameObject)Resources.Load("tama1");
        Instantiate(tama, new Vector3(1.0f, 10.0f, -1.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(-1.0f, 15.0f, -1.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(-2.0f, 20.0f, 0.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(-1.0f, 25.0f, 1.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(1.0f, 30.0f, 1.0f), Quaternion.identity);

        Instantiate(tama, new Vector3(2.0f, 35.0f, 0.0f), Quaternion.identity);

        Invoke(nameof(DestroyParts), gtime);

        Invoke(nameof(Birth), gtime);

    }

    private void DestroyParts()
    {
        GameObject[] parts = GameObject.FindGameObjectsWithTag("tama1");

        foreach (GameObject partslist in parts)
        {
            Destroy(partslist);
        }


    }

}
