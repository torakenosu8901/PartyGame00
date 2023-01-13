using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // �v���C���[1���������t���O
    [SerializeField]
    private bool p1Ready = false;

    // �v���C���[2���������t���O
    [SerializeField]
    private bool p2Ready = false;

    // ���ŗp�^�C�g���e�L�X�g
    [SerializeField]
    private Text titleText;

    // ���ŗp�^�C���J�E���^�[
    [SerializeField]
    private float timerFloat;

    // ���ŗp�t���O
    [SerializeField]
    private bool flashingTitleText = true;

    // P1���������e�L�X�g
    [SerializeField]
    private Text p1ReadyText;

    // P1���������A�C�R��
    [SerializeField]
    private RawImage p1ReadyIcon;

    // P2���������e�L�X�g
    [SerializeField]
    private Text p2ReadyText;

    // P2���������A�C�R��
    [SerializeField]
    private RawImage p2ReadyIcon;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TitleManagement());
    }

    private void Update()
    {
        // �utimerFloat�v���u0.5�b�v��������Ă�����ȉ��̏��������s����
        if(timerFloat < 0.5f)
        {
            titleText.color -= new Color(titleText.color.r, titleText.color.g, titleText.color.b, 3f * Time.deltaTime);
        }
        // �utimerFloat�v���u1�b�v��������Ă�����ȉ��̏��������s����
        else if (timerFloat < 1.0f)
        {
            titleText.color += new Color(titleText.color.r, titleText.color.g, titleText.color.b, 3f * Time.deltaTime);
        }
        //�utimerFloat�v���u10�b�v�𒴂�����ȉ��̏��������s����
        else if(timerFloat > 1.0f)
        {
            timerFloat = 0.0f;
        }

        if (flashingTitleText)
        {
            // �utimerFloat�v�Ɍo�ߕb�������Z���Ă���
            timerFloat += 1 * Time.deltaTime;
        }
    }

    private IEnumerator TitleManagement()
    {
        yield return new WaitForSeconds(3.0f);

        while(true)
        {
            // LShift�������ꂽ��P1��������
            if (Input.GetKeyDown(KeyCode.LeftShift) && !p1Ready)
            {
                p1ReadyText.text = "P1 READY";
                p1ReadyIcon.color = new Color(0f, 0f, 255f, 1f);
                p1Ready = true;
            }
            else if(Input.GetKeyDown(KeyCode.LeftShift) && p1Ready)
            {
                p1ReadyText.text = "P1 WAITING";
                p1ReadyIcon.color = new Color(255f, 0f, 0f, 1f);
                p1Ready = false;
            }

            // RShift�������ꂽ��P2��������
            if (Input.GetKeyDown(KeyCode.RightShift) && !p2Ready)
            {
                p2ReadyText.text = "P2 READY";
                p2ReadyIcon.color = new Color(0f, 0f, 255f, 1f);
                p2Ready = true;
            }
            else if(Input.GetKeyDown(KeyCode.RightShift) && p2Ready)
            {
                p2ReadyText.text = "P2 WAITING";
                p2ReadyIcon.color = new Color(255f, 0f, 0f, 1f);
                p2Ready = false;
            }

            // ���v���C���[�����������ɂȂ�����i�s����
            if (p1Ready && p2Ready)
            {
                // ���ł���e�L�X�g�̖��ł��~�����ă��l���u1�v�ɂ��Ĕ񓧖��ɂ���
                flashingTitleText = false;
                titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, 1.0f);

                StartCoroutine(PartyGameAllManager.instance.SceneChange(1));
                //Debug.Log("�����c�n�߂����I�I");
                break;
            }

            yield return null;
        }

        yield break;
    }

}
