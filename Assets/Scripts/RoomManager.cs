using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    //public Text nameText;
    public Text roomName;
    public GameObject playBtn;
    public GameObject playerNamePrefab;
    public Transform gridLayOut;
    public GameObject stateUI;

    private int preRoomPlayerCount = 0;
    private bool isPlayActive = false;

    private void Awake()
    {
        roomName.text = "��ǰ���䣺" + PhotonNetwork.CurrentRoom.Name;

        PhotonNetwork.AutomaticallySyncScene = true;
        stateUI.GetComponentInChildren<Text>().text = "��״̬��Ϣ���ѳɹ����뷿��"+ PhotonNetwork.CurrentRoom.Name + "���ȴ�������ʼ��Ϸ";
    }

    private void Update()
    {
        if (preRoomPlayerCount != PhotonNetwork.CurrentRoom.PlayerCount)
        {
            preRoomPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            for (int i = 0; i < gridLayOut.childCount; i++)
            {
                Destroy(gridLayOut.GetChild(i).gameObject);
            }

            foreach (var player in PhotonNetwork.PlayerList)
            {

                GameObject newPlayerName = Instantiate(playerNamePrefab, gridLayOut.position, Quaternion.identity);

                newPlayerName.GetComponentInChildren<Text>().text = player.NickName;

                newPlayerName.transform.SetParent(gridLayOut);
            }
        }


        if (!isPlayActive && PhotonNetwork.CurrentRoom.PlayerCount > 0 && PhotonNetwork.IsMasterClient)
        {
            isPlayActive = true;
            playBtn.SetActive(true);
        }
    }


    public void playButton()
    {
        if (PhotonNetwork.IsMasterClient) {

            PhotonNetwork.LoadLevel("Start");
        }
    }
}
