using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���{�b�g���A�b�v�O���[�h�{�^��

public class RoboCntUG : MonoBehaviour
{
    [SerializeField] private RobotBase roboBase;
    [SerializeField] private Text levelText;
    [SerializeField] private Text costText;
    [SerializeField] private Text upgradeText;

    [SerializeField] private int level;
    private int nextCost;
    private int nowRoboCnt;
    private int nextRoboCnt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*�{�^���Ń��x���A�b�v����UI�݌v
 * �E�\���̔z��Ŏ��̃R�X�g�A���̃��{�b�g�����Ǘ�
 * �EGameManager���炨����񎝂��Ă��āA���
 * �EInteractable�̃`�F�b�N�{�b�N�X��TF�؂�ւ��Ă��
 */
