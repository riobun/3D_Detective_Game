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
        stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ���������ӷ�����...(���ȴ�ʱ��������ɹر���Ϸ�����´�)";
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ��������������";

        hint.SetActive(false);

        nameUI.SetActive(true);

        PhotonNetwork.JoinLobby();
    }

    public void OKButton()
    {
        if (playerName.text.Length < 1)
        {
            stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ���ǳƲ���Ϊ��Ŷ��";
            return;
        }
        stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ���ѳɹ���������ǳ�";

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
            stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ�����뷿��ʧ�ܣ�������̫�̿�������Ϊ2���ַ�Ŷ��";
            return;
        }

        loginUI.SetActive(false);
        roomlistUI.SetActive(false);
        hint.GetComponent<Text>().text = "���ڽ��뷿�䣬���Ե�";
        hint.SetActive(true);
        stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ�����ڽ��뷿��";

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
