using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class dialogController : MonoBehaviourPunCallbacks
{
    public Flowchart flowchart;
    public GameObject start;
    public GameObject startUI;
    public GameObject readyUI;
    public GameObject player;

    public GameObject stateUI;

    private int playerNum = -1;
    private int alreadyReadyPlayerNum = 0;

    private bool readyToNext = true;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    private void Start()
    {
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】欢迎进入游戏剧本环节！你可以通过鼠标点击来阅读人物剧本。";

    }

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("start"))
        {
            start.SetActive(false);
            startUI.SetActive(false);
            flowchart.SetBooleanVariable("start", false);

        }
        if (flowchart.GetBooleanVariable("occur"))
        {
            player.SetActive(true);
            flowchart.SetBooleanVariable("occur", false);

        }
        if (flowchart.GetBooleanVariable("next"))
        {            
            flowchart.SetBooleanVariable("next", false);
            player.SetActive(false);
            readyUI.SetActive(true);
            playerNum = PhotonNetwork.CurrentRoom.PlayerCount;
            Debug.Log("playerNum:" + playerNum);
            this.photonView.RPC("sendReadyMessage", RpcTarget.All);
            Debug.Log("send后 alreadyReadyPlayerNum:" + alreadyReadyPlayerNum);

            //SceneManager.LoadScene("DinnerHall");
        }

        if (readyToNext && playerNum == alreadyReadyPlayerNum && PhotonNetwork.IsMasterClient)
        {
            this.photonView.RPC("disactiveReadyUI", RpcTarget.All);

            PhotonNetwork.LoadLevel("DinnerHall");

        }
    }

    [PunRPC]
    public void sendReadyMessage()
    {
        Debug.Log("send前 alreadyReadyPlayerNum:" + alreadyReadyPlayerNum);

        this.alreadyReadyPlayerNum += 1;
        Debug.Log("+1后 alreadyReadyPlayerNum:" + alreadyReadyPlayerNum);

        stateUI.GetComponentInChildren<Text>().text = "【状态信息】当前已有"+ this.alreadyReadyPlayerNum +"位玩家准备进入下一阶段！";

    }

    [PunRPC]
    public void disactiveReadyUI()
    {
        readyToNext = false;
        readyUI.SetActive(false);
    }
}
