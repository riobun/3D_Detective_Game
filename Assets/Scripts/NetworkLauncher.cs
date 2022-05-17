using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;
    public GameObject nameUI;
    public InputField roomName;
    public InputField playerName;
    public GameObject title;
    public GameObject roomlistUI;
    public GameObject hint;
    public GameObject stateUI;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】正在连接服务器...(若等待时间过长，可关闭游戏后重新打开)";
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】服务器已连接";

        hint.SetActive(false);

        nameUI.SetActive(true);

        PhotonNetwork.JoinLobby();
    }

    public void OKButton()
    {
        if (playerName.text.Length < 1)
        {
            stateUI.GetComponentInChildren<Text>().text = "【状态信息】昵称不能为空哦！";
            return;
        }
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】已成功创建玩家昵称";

        nameUI.SetActive(false);
        PhotonNetwork.NickName = playerName.text;
        title.SetActive(false);

        loginUI.SetActive(true);

        if (PhotonNetwork.InLobby)
        {
            roomlistUI.SetActive(true);
        }
        
    }

    public void JoinOrCreateButton()
    {
        if (roomName.text.Length < 2)
        {
            stateUI.GetComponentInChildren<Text>().text = "【状态信息】进入房间失败！房间名太短咯，最少为2个字符哦！";
            return;
        }

        loginUI.SetActive(false);
        roomlistUI.SetActive(false);
        hint.GetComponent<Text>().text = "正在进入房间，请稍等";
        hint.SetActive(true);
        stateUI.GetComponentInChildren<Text>().text = "【状态信息】正在进入房间";

        RoomOptions options = new RoomOptions { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        SceneManager.LoadScene("Room");
        //PhotonNetwork.LoadLevel("Room");
    }


}
