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
        stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ����ӭ������Ϸ���㻷�ڣ�ͨ���ش�����ɵõ�������Ϸ�ĵ÷�Ŷ��";

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
        if (flowchart.GetBooleanVariable("�鿴����"))
        {
            canvas.SetActive(true);
            flowchart.SetBooleanVariable("�鿴����", false);
            stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ��һ�𿴿���������྿����ʲô���ɣ�";

        }
        if (flowchart.GetBooleanVariable("�˳���Ϸ"))
        {

            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
            flowchart.SetBooleanVariable("�˳���Ϸ", false);
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
