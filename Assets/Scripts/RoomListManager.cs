using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomListManager : MonoBehaviourPunCallbacks
{
    public GameObject roomNamePrefab;
    public Transform gridLayOut;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        for (int i = 0; i < gridLayOut.childCount; i++)
        {
            if (gridLayOut.GetChild(i).gameObject.GetComponentInChildren<Text>().text == roomList[i].Name)
            {
                Destroy(gridLayOut.GetChild(i).gameObject);

                if(roomList[i].PlayerCount == 0)
                {
                    roomList.Remove(roomList[i]);
                }
            }
        }

        foreach(var room in roomList)
        {
            GameObject newRoom = Instantiate(roomNamePrefab, gridLayOut.position, Quaternion.identity);

            newRoom.GetComponentInChildren<Text>().text = room.Name;

            newRoom.transform.SetParent(gridLayOut);
        }
    }
}
