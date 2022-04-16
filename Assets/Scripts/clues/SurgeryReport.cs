using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurgeryReport : MonoBehaviour
{
    public Image panel;
    public Text title;
    public Text detail;

    private List<string> clueInfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMouseDown()
    {
        //16代表本线索的id，在Assets/config/item文件中查看每个线索的id
        this.clueInfo = GameObject.Find("Canvas").GetComponent<GameUI>().findClue(13);
        this.title.text = this.clueInfo[0];
        this.detail.text = this.clueInfo[1];

        panel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
