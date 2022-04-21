using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameUI : MonoBehaviourPunCallbacks
{
    public GameObject bookDisplay;
    public GameObject sceneDislay;
    public GameObject clueDislay;
    public GameObject truthDisplay;
    public GameObject helpDisplay;

    public GameObject cluePanel;
    public GameObject clueTitle;
    public GameObject clueDetail;

    public GameObject nextBtn;
    public GameObject remindUI;

    public GameObject stateUI;

    private List<bagItem> bagItemList;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        NewItemManager.Instance.loadItemConfig();
        this.bagItemList = NewItemManager.Instance.bagItemList;

        //cluePanel.SetActive(true);
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】欢迎进入游戏搜证环节！你可以点击帮助按钮查看该环节的帮助信息。";

    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (LabManager.Instance.findlab)
        {
            GameObject lab1 = sceneDislay.transform.Find("labButton").gameObject;
            GameObject lab2 = clueDislay.transform.Find("right/toggleGroup/lab").gameObject;
            if (!lab1.activeSelf)
            {
                lab1.SetActive(true);
                this.photonView.RPC("otherFindLab", RpcTarget.All);
            }
            if (!lab2.activeSelf)
            {
                lab2.SetActive(true);
            }
        }


        if (scene.name == "Hospital" && this.bagItemList[18].isFind == 0)
        {
            Invoke("findAutopsy", 1);
        }
        
    }

    [PunRPC]
    public void otherFindLab()
    {
        LabManager.Instance.findlab = true;
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】已有玩家发现隐藏地图：医学实验室。";

    }

    public void updateStateUI(int num)
    {
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】当前已有" + num + "位玩家准备进入下一阶段！";

    }

    private void findAutopsy()
    {
        this.bagItemList[18].isFind = 1;
        this.clueTitle.GetComponent<Text>().text = this.bagItemList[18].name;
        this.clueDetail.GetComponent<Text>().text = this.bagItemList[18].desc;
        this.cluePanel.gameObject.SetActive(true);

        this.photonView.RPC("otherFindClue", RpcTarget.All, 19);
    }

    public void activeRemindUI()
    {
        remindUI.SetActive(true);
    }

    public void disactiveRemindUI()
    {
        remindUI.SetActive(false);
    }

    public void disactiveNext()
    {
        nextBtn.SetActive(false);
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

        this.photonView.RPC("otherFindClue", RpcTarget.All, id);
        return itemInfo;
    }

    [PunRPC]
    public void otherFindClue(int id)
    {
        this.bagItemList[id - 1].isFind = 1;
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】已有玩家找到线索" + "：" + this.bagItemList[id - 1].name + "。";

    }

}
