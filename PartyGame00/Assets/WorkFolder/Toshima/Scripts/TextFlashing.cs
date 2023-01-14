using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashing : MonoBehaviour
{
    [SerializeField]
    private Text textColor;

    [SerializeField]
    private float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        textColor = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCount < 0.25f)
        {
            textColor.color = new Color(textColor.color.r, textColor.color.g, textColor.color.b, 0.0f);
        }
        else if(timeCount < 0.5f)
        {
            textColor.color = new Color(textColor.color.r, textColor.color.g, textColor.color.b, 1.0f);
        }
        else
        {
            timeCount = 0.0f;
        }
        timeCount += 1.0f * Time.deltaTime;
    }
}
