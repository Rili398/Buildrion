using UnityEngine;

//�y�n�ɕt����@���̗p�R���|�[�l���g

public class Marge : MonoBehaviour
{
    [SerializeField] private Land myLand;
    public bool isMarge;
    //���̃{�^���ϐ�
    private fillbottom margeButton;

    public ParticleSystem particle;
    public bool isWarking;
    public bool timeStop;

    void Start()
    {
        myLand = GetComponent<Land>();
        isMarge = false;
        margeButton = GameObject.FindGameObjectWithTag("MargeButton").GetComponent<fillbottom>();

        isWarking = false;
        timeStop = false;
    }

    //=========================================================================

    public int GetRobotCnt()
    {
        return myLand.robotCnt;
    }

    public void ChangeBuildrion(bool command = true)
    {
        isMarge = command;
        myLand.margeRate = Singleton<GameManager>.Instance.GetMargeRate();    //���̔{��
        myLand.SetViewRobot(true);
        timeStop = true;

        particle.Play();
    }

    //=========================================================================

    //�N���b�N���ꂽ��֐�
    public void OnClick()
    {
        margeButton.SetMarge(this);
    }
}
