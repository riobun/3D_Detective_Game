using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Li_telephone : MonoBehaviour, IPointerClickHandler
{
    private GameObject panel;
    private GameObject title;
    private GameObject detail;

    private List<string> clueInfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //16����������id����Assets/config/item�ļ��в鿴ÿ��������id
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
