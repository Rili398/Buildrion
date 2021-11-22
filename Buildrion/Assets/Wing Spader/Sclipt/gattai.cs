using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gattai : MonoBehaviour
{

    //�������́A�����h�~�p
    bool mode = false;

    [SerializeField] private float gtime;

    //�I�΂�X�C�b�`
    bool sle1 = false;
    bool sle2 = false;
    bool sle3 = false;
    bool sle4 = false;
    bool sle5 = false;

    //�e
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //������

        Fusion();
        Purge();
    }

    void Fusion()
    {
        //�t���[�W������'F'���������獇��
        if (Input.GetKeyDown(KeyCode.F))
        {
            //�������̖h�~
            if (mode == false)
            {


                GameObject buildrion = (GameObject)Resources.Load("cutin 1");
                Instantiate(buildrion, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);


                //���[�h�؂�ւ�
                mode = true;

            }

        }
    }

    void Purge()
    {
        //�p�[�W��'P'���������番��
        if (Input.GetKeyDown(KeyCode.P))
        {
            //���������h�~
            if (mode == true)
            {

                // �e�I�u�W�F�N�g��T��
                parent = GameObject.Find("parent");

                //�ЂƂ܂��e�q�֌W��������\��
                {
                    //��\������
                    if (sle1 == true)
                    {
                        Transform tama1 = parent.transform.Find("tama1");
                        //�h��
                        tama1.gameObject.SetActive(true);

                        //�e�q�֌W����
                        tama1.transform.parent = null;

                        //�؂�ւ�
                        sle1 = false;
                    }

                    if (sle2 == true)
                    {
                        Transform tama2 = parent.transform.Find("tama1 (1)");
                        //�h��
                        tama2.gameObject.SetActive(true);

                        //�e�q�֌W����
                        tama2.transform.parent = null;

                        //�؂�ւ�
                        sle2 = false;
                    }

                    if (sle3 == true)
                    {
                        Transform tama3 = parent.transform.Find("tama1 (2)");
                        //�h��
                        tama3.gameObject.SetActive(true);

                        //�e�q�֌W����
                        tama3.transform.parent = null;

                        //�؂�ւ�
                        sle3 = false;
                    }

                    if (sle4 == true)
                    {
                        Transform tama4 = parent.transform.Find("tama1 (3)");
                        //�h��
                        tama4.gameObject.SetActive(true);

                        //�e�q�֌W����
                        tama4.transform.parent = null;

                        //�؂�ւ�
                        sle4 = false;
                    }

                    if (sle5 == true)
                    {
                        Transform tama5 = parent.transform.Find("tama1 (4)");
                        //�h��
                        tama5.gameObject.SetActive(true);

                        //�e�q�֌W����
                        tama5.transform.parent = null;

                        //�؂�ւ�
                        sle5 = false;
                    }
                }

                //�f���[�g
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
