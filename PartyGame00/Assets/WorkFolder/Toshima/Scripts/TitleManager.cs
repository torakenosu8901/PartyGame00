using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // プレイヤー1準備完了フラグ
    [SerializeField]
    private bool p1Ready = false;

    // プレイヤー2準備完了フラグ
    [SerializeField]
    private bool p2Ready = false;

    // 明滅用タイトルテキスト
    [SerializeField]
    private Text titleText;

    // 明滅用タイムカウンター
    [SerializeField]
    private float timerFloat;

    // 明滅用フラグ
    [SerializeField]
    private bool flashingTitleText = true;

    // P1準備完了テキスト
    [SerializeField]
    private Text p1ReadyText;

    // P1準備完了アイコン
    [SerializeField]
    private RawImage p1ReadyIcon;

    // P2準備完了テキスト
    [SerializeField]
    private Text p2ReadyText;

    // P2準備完了アイコン
    [SerializeField]
    private RawImage p2ReadyIcon;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TitleManagement());
    }

    private void Update()
    {
        // 「timerFloat」が「0.5秒」を下回っていたら以下の処理を実行する
        if(timerFloat < 0.5f)
        {
            titleText.color -= new Color(titleText.color.r, titleText.color.g, titleText.color.b, 3f * Time.deltaTime);
        }
        // 「timerFloat」が「1秒」を下回っていたら以下の処理を実行する
        else if (timerFloat < 1.0f)
        {
            titleText.color += new Color(titleText.color.r, titleText.color.g, titleText.color.b, 3f * Time.deltaTime);
        }
        //「timerFloat」が「10秒」を超えたら以下の処理を実行する
        else if(timerFloat > 1.0f)
        {
            timerFloat = 0.0f;
        }

        if (flashingTitleText)
        {
            // 「timerFloat」に経過秒数を加算していく
            timerFloat += 1 * Time.deltaTime;
        }
    }

    private IEnumerator TitleManagement()
    {
        yield return new WaitForSeconds(3.0f);

        while(true)
        {
            // LShiftが押されたらP1準備完了
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

            // RShiftが押されたらP2準備完了
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

            // 両プレイヤーが準備完了になったら進行する
            if (p1Ready && p2Ready)
            {
                // 明滅するテキストの明滅を停止させてα値を「1」にして非透明にする
                flashingTitleText = false;
                titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, 1.0f);

                StartCoroutine(PartyGameAllManager.instance.SceneChange(1));
                //Debug.Log("試合…始めぇい！！");
                break;
            }

            yield return null;
        }

        yield break;
    }

}
