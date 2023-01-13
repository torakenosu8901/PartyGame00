using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PartyGameAllManager : MonoBehaviour
{
    // プレイヤー1の総合得点
    [SerializeField]
    private int p1VictoryPoints = 0;

    // プレイヤー2の総合得点
    [SerializeField]
    private int p2VictoryPoints = 0;

    //フェードインアウト用のキャンバス
    private static Canvas canvas;

    //フェードインアウト用のイメージ
    private static Image image;

    //フェードインアウト用のテキスト
    [SerializeField]
    private List<string> strings;

    // シングルトン化
    public static PartyGameAllManager instance;

    private void Awake()
    {
        //// シーン間をまたいで保持しておけるようにする(デフォルトで用意されている関数)
        //DontDestroyOnLoad(this.gameObject);

        // シングルトン化
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
    /// 初期化関数(ゲーム起動時に行う処理)
    /// </summary>
    private void Init()
    {
        // 万が一に備えた初期化処理
        p1VictoryPoints = 0;
        p2VictoryPoints = 0;

        if (canvas == null)
        {
            //キャンバスを生成するコード(*貰い物*)
            //実体を持った「canvasObject」を定義する
            GameObject canvasObject = new GameObject("CanvasFade");
            //「canvas」に実体を持った「canvasObject」を登録する
            canvas = canvasObject.AddComponent<Canvas>();
            //「canvas」の表示形式を「ScreenSpaceOverlay」にする(最優先でカメラに表示される形式)
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            //知らん(無慈悲)
            canvas.sortingOrder = 100;
            //「canvasObject」に「GraphicRaycaster」コンポーネントを追加。効果は知らん(無慈悲)
            canvasObject.AddComponent<GraphicRaycaster>();

            //イメージを生成するコード(*貰い物*)
            //「image」に実体を持たせてエディター上に表示する
            image = new GameObject("ImageFade").AddComponent<Image>();
            //「image」を上記で定義した「canvas」の子オブジェクトに設定する
            image.transform.SetParent(canvas.transform, false);
            //「image」を親オブジェクトである「canvas」の中心座標に表示する
            image.rectTransform.anchoredPosition = Vector3.zero;
            //メインカメラの情報を取得する
            Camera camera = Camera.main;
            //「image」のサイズをカメラが移している最大のサイズにリサイズする。(これにより「image」は画面全体を覆う)
            image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            //「image」のカラーをクリア(完全非透明)にする
            image.color = Color.clear;
            //「raycastTarget」とやらをオフにする。効果は知らん(無慈悲)
            image.raycastTarget = false;

            //フェードインアウト用のキャンバスをシーン間を持ち越せるようにする
            DontDestroyOnLoad(canvasObject);

            // シーン間をまたいで保持しておけるようにする(デフォルトで用意されている関数)
            DontDestroyOnLoad(this.gameObject);
        }

        StartCoroutine(FadeIn());
    }

    /// <summary>
    /// 加点処理
    /// </summary>
    /// <param name="Pnum">加点対象を指定</param>
    public void AddVictoryPoints(int Pnum)
    {
        switch (Pnum)
        {
            case 0:

                // プレイヤー1に足して加点を行う
                p1VictoryPoints++;

                break;
            case 1:

                // プレイヤー2に足して加点を行う
                p2VictoryPoints++;

                break;
        }
    }

    public void VictoryJudgment()
    {
        if (p1VictoryPoints < p2VictoryPoints)
        {
            // p2が勝利したときの処理を書く

        }
        else
        {
            // p1が勝利したときの処理を書く

        }
    }

    /// <summary>
    /// シーンを切り替えるコルーチン
    /// </summary>
    /// <param name="SceneNum">切り替えるシーンのナンバリング</param>
    /// <returns></returns>
    public IEnumerator SceneChange(int SceneNum)
    {
        yield return new WaitForSeconds(1.0f);


        //フェードアウト
        image.color = new Color(0, 0, 0, 0f);

        while (image.color.a < 1.0f)
        {
            image.color += new Color(0, 0, 0, 1 * Time.deltaTime);
            yield return null;
        }
        image.color = new Color(0, 0, 0, 1f);

        //シーン遷移
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(strings[SceneNum]);

        //Debug.Log(image.color.a);

        //yield return new WaitForSeconds(0.5f);

        //Debug.Log(image.color.a);


        ////フェードイン
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
        //フェードイン
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
