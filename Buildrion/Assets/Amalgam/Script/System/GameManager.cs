using UnityEngine;

//�I�v�V�����Ƃ��̊Ǘ�������\��

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        //�t���[�����[�g�ݒ�
        Application.targetFrameRate = 60;
    }
}
