using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class overController : MonoBehaviour
{
    public GameObject canvas;
    public Flowchart flowchart;
    public GameObject stateUI;
    public GameObject bookDisplay;
    public GameObject clueDislay;
    public GameObject truthDisplay;

    private void Start()
    {
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】欢迎进入游戏结算环节！通过回答问题可得到本次游戏的得分哦！";

    }

    public void activeBook()
    {
        bookDisplay.SetActive(true);
    }

    public void disactiveBook()
    {
        bookDisplay.SetActive(false);
    }

    public void activeTruth()
    {
        truthDisplay.SetActive(true);
    }

    public void disactiveTruth()
    {
        truthDisplay.SetActive(false);
    }

    public void activeClue()
    {
        clueDislay.SetActive(true);
    }

    public void disactiveclue()
    {
        clueDislay.SetActive(false);
    }

    public void gameOver()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("查看真相"))
        {
            canvas.SetActive(true);
            flowchart.SetBooleanVariable("查看真相", false);
            stateUI.GetComponentInChildren<Text>().text = "【状态信息】一起看看事情的真相究竟是什么样吧！";

        }
        if (flowchart.GetBooleanVariable("退出游戏"))
        {

            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
            flowchart.SetBooleanVariable("退出游戏", false);
        }

        if (LabManager.Instance.findlab)
        {
            GameObject lab2 = clueDislay.transform.Find("right/toggleGroup/lab").gameObject;
            if (!lab2.activeSelf)
            {
                lab2.SetActive(true);
            }
        }
    }
}
