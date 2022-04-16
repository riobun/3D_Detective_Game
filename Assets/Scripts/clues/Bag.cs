 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public Image panel;
    public Text title;
    public Text detail;

    private List<string> clueInfo;


    public void OnMouseDown()
    {
        //16代表本线索的id，在Assets/config/item文件中查看每个线索的id
        this.clueInfo = GameObject.Find("Canvas").GetComponent<GameUI>().findClue(16);
        this.title.text = this.clueInfo[0];
        this.detail.text = this.clueInfo[1];

        panel.gameObject.SetActive(true);
    }
}
