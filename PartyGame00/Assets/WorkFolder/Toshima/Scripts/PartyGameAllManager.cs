using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PartyGameAllManager : MonoBehaviour
{
    // �v���C���[1�̑������_
    [SerializeField]
    private int p1VictoryPoints = 0;

    // �v���C���[2�̑������_
    [SerializeField]
    private int p2VictoryPoints = 0;

    //�t�F�[�h�C���A�E�g�p�̃L�����o�X
    private static Canvas canvas;

    //�t�F�[�h�C���A�E�g�p�̃C���[�W
    private static Image image;

    //�t�F�[�h�C���A�E�g�p�̃e�L�X�g
    [SerializeField]
    private List<string> strings;

    // �V���O���g����
    public static PartyGameAllManager instance;

    private void Awake()
    {
        //// �V�[���Ԃ��܂����ŕێ����Ă�����悤�ɂ���(�f�t�H���g�ŗp�ӂ���Ă���֐�)
        //DontDestroyOnLoad(this.gameObject);

        // �V���O���g����
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// �������֐�(�Q�[���N�����ɍs������)
    /// </summary>
    private void Init()
    {
        // ������ɔ���������������
        p1VictoryPoints = 0;
        p2VictoryPoints = 0;

        if (canvas == null)
        {
            //�L�����o�X�𐶐�����R�[�h(*�Ⴂ��*)
            //���̂��������ucanvasObject�v���`����
            GameObject canvasObject = new GameObject("CanvasFade");
            //�ucanvas�v�Ɏ��̂��������ucanvasObject�v��o�^����
            canvas = canvasObject.AddComponent<Canvas>();
            //�ucanvas�v�̕\���`�����uScreenSpaceOverlay�v�ɂ���(�ŗD��ŃJ�����ɕ\�������`��)
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            //�m���(������)
            canvas.sortingOrder = 100;
            //�ucanvasObject�v�ɁuGraphicRaycaster�v�R���|�[�l���g��ǉ��B���ʂ͒m���(������)
            canvasObject.AddComponent<GraphicRaycaster>();

            //�C���[�W�𐶐�����R�[�h(*�Ⴂ��*)
            //�uimage�v�Ɏ��̂��������ăG�f�B�^�[��ɕ\������
            image = new GameObject("ImageFade").AddComponent<Image>();
            //�uimage�v����L�Œ�`�����ucanvas�v�̎q�I�u�W�F�N�g�ɐݒ肷��
            image.transform.SetParent(canvas.transform, false);
            //�uimage�v��e�I�u�W�F�N�g�ł���ucanvas�v�̒��S���W�ɕ\������
            image.rectTransform.anchoredPosition = Vector3.zero;
            //���C���J�����̏����擾����
            Camera camera = Camera.main;
            //�uimage�v�̃T�C�Y���J�������ڂ��Ă���ő�̃T�C�Y�Ƀ��T�C�Y����B(����ɂ��uimage�v�͉�ʑS�̂𕢂�)
            image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            //�uimage�v�̃J���[���N���A(���S�񓧖�)�ɂ���
            image.color = Color.clear;
            //�uraycastTarget�v�Ƃ����I�t�ɂ���B���ʂ͒m���(������)
            image.raycastTarget = false;

            //�t�F�[�h�C���A�E�g�p�̃L�����o�X���V�[���Ԃ������z����悤�ɂ���
            DontDestroyOnLoad(canvasObject);

            // �V�[���Ԃ��܂����ŕێ����Ă�����悤�ɂ���(�f�t�H���g�ŗp�ӂ���Ă���֐�)
            DontDestroyOnLoad(this.gameObject);
        }

        StartCoroutine(FadeIn());
    }

    /// <summary>
    /// ���_����
    /// </summary>
    /// <param name="Pnum">���_�Ώۂ��w��</param>
    public void AddVictoryPoints(int Pnum)
    {
        switch (Pnum)
        {
            case 0:

                // �v���C���[1�ɑ����ĉ��_���s��
                p1VictoryPoints++;

                break;
            case 1:

                // �v���C���[2�ɑ����ĉ��_���s��
                p2VictoryPoints++;

                break;
        }
    }

    public void VictoryJudgment()
    {
        if (p1VictoryPoints < p2VictoryPoints)
        {
            // p2�����������Ƃ��̏���������

        }
        else
        {
            // p1�����������Ƃ��̏���������

        }
    }

    /// <summary>
    /// �V�[����؂�ւ���R���[�`��
    /// </summary>
    /// <param name="SceneNum">�؂�ւ���V�[���̃i���o�����O</param>
    /// <returns></returns>
    public IEnumerator SceneChange(int SceneNum)
    {
        yield return new WaitForSeconds(1.0f);


        //�t�F�[�h�A�E�g
        image.color = new Color(0, 0, 0, 0f);

        while (image.color.a < 1.0f)
        {
            image.color += new Color(0, 0, 0, 1 * Time.deltaTime);
            yield return null;
        }
        image.color = new Color(0, 0, 0, 1f);

        //�V�[���J��
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(strings[SceneNum]);

        //Debug.Log(image.color.a);

        //yield return new WaitForSeconds(0.5f);

        //Debug.Log(image.color.a);


        ////�t�F�[�h�C��
        //image.color = new Color(0, 0, 0, 1f);

        //Debug.Log(image.color.a);


        //while (image.color.a > 0.0f)
        //{
        //    Debug.Log(image.color.a);

        //    image.color -= new Color(0, 0, 0, 1 * Time.deltaTime);
        //    yield return null;
        //}

        //Debug.Log(image.color.a);

        //image.color = new Color(0, 0, 0, 0f);

        yield break;
    }

    private IEnumerator FadeIn()
    {
        //�t�F�[�h�C��
        image.color = new Color(0, 0, 0, 1f);

        Debug.Log(image.color.a);


        while (image.color.a > 0.0f)
        {
            Debug.Log(image.color.a);

            image.color -= new Color(0, 0, 0, 1 * Time.deltaTime);
            yield return null;
        }

        Debug.Log(image.color.a);

        image.color = new Color(0, 0, 0, 0f);

        yield break;
    }

}
