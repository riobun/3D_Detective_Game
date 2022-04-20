using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;
    public GameObject nameUI;
    public InputField roomName;
    public InputField playerName;
    public GameObject title;
    public GameObject roomlistUI;
    public GameObject hint;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        hint.SetActive(false);

        nameUI.SetActive(true);

        PhotonNetwork.JoinLobby();
    }

    public void OKButton()
    {
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
        if (roomName.text.Length < 2) return;

        loginUI.SetActive(false);
        roomlistUI.SetActive(false);
        hint.GetComponent<Text>().text = "正在进入房间，请稍等";
        hint.SetActive(true);

        RoomOptions options = new RoomOptions { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        
        PhotonNetwork.LoadLevel("Room");
    }


}
