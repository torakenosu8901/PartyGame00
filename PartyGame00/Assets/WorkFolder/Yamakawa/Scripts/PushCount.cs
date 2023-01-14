using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCount : MonoBehaviour
{

    public int leftCount;

    public int rightCount;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            leftCount++;

            Debug.Log(leftCount);
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            rightCount++;

            Debug.Log(rightCount);
        }
    }
}
