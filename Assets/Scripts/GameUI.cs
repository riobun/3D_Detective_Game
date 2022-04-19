using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject bookDisplay;
    public GameObject sceneDislay;
    public GameObject clueDislay;
    public GameObject truthDisplay;
    public GameObject helpDisplay;

    public GameObject cluePanel;
    public GameObject clueTitle;
    public GameObject clueDetail;

    private List<bagItem> bagItemList;

    // Start is called before the first frame update
    void Start()
    {
        NewItemManager.Instance.loadItemConfig();
        this.bagItemList = NewItemManager.Instance.bagItemList;

        //cluePanel.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (LabManager.Instance.findlab)
        {
            GameObject lab1 = sceneDislay.transform.Find("labButton").gameObject;
            GameObject lab2 = clueDislay.transform.Find("right/toggleGroup/lab").gameObject;
            if (!lab1.activeSelf)
            {
                lab1.SetActive(true);
            }
            if (!lab2.activeSelf)
            {
                lab2.SetActive(true);
            }
        }

        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Hospital" && this.bagItemList[18].isFind == 0)
        {
            Invoke("findAutopsy", 1);
        }
        
    }

    private void findAutopsy()
    {
        this.bagItemList[18].isFind = 1;
        this.clueTitle.GetComponent<Text>().text = this.bagItemList[18].name;
        this.clueDetail.GetComponent<Text>().text = this.bagItemList[18].desc;
        this.cluePanel.gameObject.SetActive(true);
    }

    public void activeBook()
    {
        bookDisplay.SetActive(true);
    }

    public void disactiveBook()
    {
        bookDisplay.SetActive(false);
    }

    public void activeHelp()
    {
        helpDisplay.SetActive(true);
    }

    public void disactiveHelp()
    {
        helpDisplay.SetActive(false);
    }

    public void activeTruth()
    {
        truthDisplay.SetActive(true);
    }

    public void disactiveTruth()
    {
        truthDisplay.SetActive(false);
    }

    public void activeScene()
    {
        sceneDislay.SetActive(true);
    }

    public void disactiveScene()
    {
        sceneDislay.SetActive(false);
    }

    public void activeClue()
    {
        clueDislay.SetActive(true);
    }

    public void disactiveclue()
    {
        clueDislay.SetActive(false);
    }

    public void disactivefindclue()
    {
        cluePanel.SetActive(false);
    }


    public void gameOver()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public List<string> findClue(int id)
    {
        this.bagItemList[id - 1].isFind = 1;
        List<string> itemInfo = new List<string>();
        itemInfo.Add(this.bagItemList[id - 1].name);
        itemInfo.Add(this.bagItemList[id - 1].desc);
        //Debug.Log(itemInfo[0]);
        //Debug.Log(itemInfo[1]);
        return itemInfo;
    }
}
