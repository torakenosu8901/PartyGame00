using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FirstGameManager : MonoBehaviour
{
    [SerializeField]
    private bool p1Ready = false;

    [SerializeField]
    private bool p2Ready = false;

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

    [SerializeField]
    private Text treeCountText;

    [SerializeField]
    private float gameTimer = 15;

    [SerializeField]
    private bool gameNow = false;

    // Start is called before the first frame update
    void Start()
    {
        treeCountText.enabled = false;

        StartCoroutine(FirstGameReady());
    }

    private IEnumerator FirstGameReady()
    {
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            // LShiftが押されたらP1準備完了
            if (Input.GetKeyDown(KeyCode.LeftShift) && !p1Ready)
            {
                p1ReadyText.text = "P1 READY";
                p1ReadyIcon.color = new Color(0f, 0f, 255f, 1f);
                p1Ready = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && p1Ready)
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
            else if (Input.GetKeyDown(KeyCode.RightShift) && p2Ready)
            {
                p2ReadyText.text = "P2 WAITING";
                p2ReadyIcon.color = new Color(255f, 0f, 0f, 1f);
                p2Ready = false;
            }

            // 両プレイヤーが準備完了になったら進行する
            if (p1Ready && p2Ready)
            {
                treeCountText.enabled = true;
                yield return new WaitForSeconds(1);
                treeCountText.text = "2";
                yield return new WaitForSeconds(1);
                treeCountText.text = "1";
                yield return new WaitForSeconds(1);
                treeCountText.text = "GO!!";
                yield return new WaitForSeconds(1);
                StartCoroutine(FirstGameManagement());
                //Debug.Log("試合…始めぇい！！");
                break;
            }

            yield return null;
        }

        yield break;
    }

    private IEnumerator FirstGameManagement()
    {
        float gameTimer = 15.0f;

        while(gameTimer >= 0)
        {
            treeCountText.text = gameTimer.ToString("f1");



            gameTimer-= Time.deltaTime;
            yield return null;
        }
        gameTimer = 0.0f;
        yield break;
    }
}
