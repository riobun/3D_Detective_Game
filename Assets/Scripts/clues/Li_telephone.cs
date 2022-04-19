using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Li_telephone : MonoBehaviour
{
    private GameObject panel;
    private GameObject title;
    private GameObject detail;

    private List<string> clueInfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMouseDown()
    {

        //16代表本线索的id，在Assets/config/item文件中查看每个线索的id
        this.clueInfo = GameObject.Find("Canvas").GetComponent<GameUI>().findClue(4);

        this.title = GameObject.Find("Canvas").GetComponent<GameUI>().clueTitle;
        this.detail = GameObject.Find("Canvas").GetComponent<GameUI>().clueDetail;
        this.title.GetComponent<Text>().text = this.clueInfo[0];
        this.detail.GetComponent<Text>().text = this.clueInfo[1];

        this.panel = GameObject.Find("Canvas").GetComponent<GameUI>().cluePanel;
        this.panel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
