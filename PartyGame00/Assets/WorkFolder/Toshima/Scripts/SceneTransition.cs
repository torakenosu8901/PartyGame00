using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private List<string> nextSceneName;

    public static SceneTransition instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void NextSceneTransitionStart(int num)
    {
        SceneManager.LoadScene(nextSceneName[num]);
    }
}
