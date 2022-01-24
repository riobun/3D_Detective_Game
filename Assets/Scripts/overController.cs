using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overController : MonoBehaviour
{
    public GameObject canvas;
    public Flowchart flowchart;

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("查看真相"))
        {
            canvas.SetActive(true);
            flowchart.SetBooleanVariable("查看真相", false);
        }
        if (flowchart.GetBooleanVariable("退出游戏"))
        {

            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
            flowchart.SetBooleanVariable("退出游戏", false);
        }
    }
}
