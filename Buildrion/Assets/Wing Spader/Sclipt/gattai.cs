using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gattai : MonoBehaviour
{
    //�f�ފi�[
    //private List<string> mList = new List<string>();
    //int count = 0;

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

        //�����͍��̂��Ă���������_��
        if (mode == false)
        {
            {
                //�e�q�؂�ւ�
                /*{
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        //�e�I�u�W�F�擾
                        GameObject parent = GameObject.Find("parent");

                        //�q�I�u�W�F�ɂ����[��
                        GameObject tama = GameObject.Find("tama1");

                        if (sle1 == false)
                        {
                            //�q�ɂ��鏈��
                            tama.transform.parent = parent.transform;

                            //�؂�ւ�
                            sle1 = true;
                        }
                        else
                        {
                            //�q�I�u�W�F�N�g����
                            tama.transform.parent = null;

                            //�؂�ւ�
                            sle1 = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        //�e�I�u�W�F�擾
                        GameObject parent = GameObject.Find("parent");

                        //�q�I�u�W�F�ɂ����[��
                        GameObject tama = GameObject.Find("tama1 (1)");

                        if (sle2 == false)
                        {
                            //�q�ɂ��鏈��
                            tama.transform.parent = parent.transform;

                            //�؂�ւ�
                            sle2 = true;
                        }
                        else
                        {
                            //�q�I�u�W�F�N�g����
                            tama.transform.parent = null;

                            //�؂�ւ�
                            sle2 = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        //�e�I�u�W�F�擾
                        GameObject parent = GameObject.Find("parent");

                        //�q�I�u�W�F�ɂ����[��
                        GameObject tama = GameObject.Find("tama1 (2)");

                        if (sle3 == false)
                        {
                            //�q�ɂ��鏈��
                            tama.transform.parent = parent.transform;

                            //�؂�ւ�
                            sle3 = true;
                        }
                        else
                        {
                            //�q�I�u�W�F�N�g����
                            tama.transform.parent = null;

                            //�؂�ւ�
                            sle3 = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        //�e�I�u�W�F�擾
                        GameObject parent = GameObject.Find("parent");

                        //�q�I�u�W�F�ɂ����[��
                        GameObject tama = GameObject.Find("tama1 (3)");

                        if (sle4 == false)
                        {
                            //�q�ɂ��鏈��
                            tama.transform.parent = parent.transform;

                            //�؂�ւ�
                            sle4 = true;
                        }
                        else
                        {
                            //�q�I�u�W�F�N�g����
                            tama.transform.parent = null;

                            //�؂�ւ�
                            sle4 = false;
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Alpha5))
                    {
                        //�e�I�u�W�F�擾
                        GameObject parent = GameObject.Find("parent");

                        //�q�I�u�W�F�ɂ����[��
                        GameObject tama = GameObject.Find("tama1 (4)");

                        if (sle5 == false)
                        {
                            //�q�ɂ��鏈��
                            tama.transform.parent = parent.transform;

                            //�؂�ւ�
                            sle5 = true;
                        }
                        else
                        {
                            //�q�I�u�W�F�N�g����
                            tama.transform.parent = null;

                            //�؂�ւ�
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
        //�t���[�W������'F'���������獇��
        if (Input.GetKeyDown(KeyCode.F))
        {
            //�������̖h�~
            if (mode == false)
            {
                {
                    //���̂Ɛ���
                    //   ���̌��擾

                    //GameObject obj = GameObject.FindGameObjectWithTag("Capsule");

                    //GameObject tama1 = GameObject.FindGameObjectWithTag("tama1");
                    //GameObject tama2 = GameObject.FindGameObjectWithTag("tama2");


                    //�J�v�Z���v���n�u��GameObject�^�Ŏ擾
                    //GameObject obj = (GameObject)Resources.Load("Capsule");
                    //�J�v�Z���v���n�u�����ɁA�C���X�^���X�𐶐��A
                    //GameObject robo = Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);

                    //Capsule c = robo.GetComponent<Capsule>();


                    //�����ɍ��̌��̃Q�[���I�u�W�F�N�g���w�肵�Ƃ�
                    //c.SetSozai(tama1.name, tama2.name);

                    //�j��
                    //Destroy(tama1);
                    //Destroy(tama2);

                    //obj.gameObject.SetActive(true);

                    //tama1.gameObject.SetActive(false);
                    //tama2.gameObject.SetActive(false);

                    //mode = true;
                }

                //�ЂƂ܂��e�q�֌W���������\��
                {  
                    ////��\������
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
        //�p�[�W��'P'���������番��
        if (Input.GetKeyDown(KeyCode.P))
        {
            //���������h�~
            if (mode == true)
            {
                {
                    //�����Ɛ���
                    //���̌��擾
                    //GameObject obj = GameObject.FindGameObjectWithTag("Capsule");
                    //Capsule c = obj.GetComponent<Capsule>();

                    //GameObject tama1 = GameObject.FindGameObjectWithTag("tama1");
                    //GameObject tama2 = GameObject.FindGameObjectWithTag("tama2");

                    //�g���Ă��f�ނ̎擾
                    //string sozai1 = c.GetSozai1();
                    //string sozai2 = c.GetSozai2();

                    //���[�h
                    //GameObject sobj1 = (GameObject)Resources.Load(sozai1);
                    //GameObject sobj2 = (GameObject)Resources.Load(sozai2);


                    //����
                    //Instantiate(sobj1, new Vector3(-1.0f, 2.0f, 0.0f), Quaternion.identity);
                    //Instantiate(sobj2, new Vector3(1.0f, 2.0f, 0.0f), Quaternion.identity);

                    //�j��
                    //Destroy(obj);

                    //obj.gameObject.SetActive(false);

                    //tama1.gameObject.SetActive(true);
                    //tama2.gameObject.SetActive(true);

                    //mode = false;
                }

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
