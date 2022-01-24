using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bagPanel : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public BagItemDetail bagItemDetail;


    public GameObject allItems;

    private List<bagItem> bagItemList;
    public List<GameObject> buttonList;
    // Start is called before the first frame update
    void Awake()
    {
        NewItemManager.Instance.loadItemConfig();
        this.bagItemList = NewItemManager.Instance.bagItemList;      

    }

    private void OnEnable()
    {

        this.buttonList.Add(this.Button1);
        this.buttonList.Add(this.Button2);
        this.buttonList.Add(this.Button3);
        this.buttonList.Add(this.Button4);
        this.buttonList.Add(this.Button5);
        this.displayClue(bagItem.locationType.Boss);
    }

    public void displayClue(bagItem.locationType locate)
    {
        int btnIndex = 0;
        for (int i = 0; i < this.bagItemList.Count; i++)
        {
            if (this.bagItemList[i].locate != locate || this.bagItemList[i].isFind == 0) 
                continue;


            //¸³Öµ
            bagItemInfo info =  this.buttonList[btnIndex].GetComponent<bagItemInfo>();
            buttonList[btnIndex].SetActive(true);
            info.setData(this.bagItemList[i]);

            bagItem item = this.bagItemList[i];
            Button btn = this.buttonList[btnIndex].GetComponent<Button>();
            btn.onClick.AddListener(() => {
                this.bagItemDetail.setData(item);
                this.bagItemDetail.gameObject.SetActive(true);
            });

            btnIndex += 1;

        }
        while (btnIndex<5)
        {
            buttonList[btnIndex].SetActive(false);
            btnIndex += 1;
        }
    }

    public void hospitalClicked(Toggle t)
    {
        if (!t.isOn) return;
        this.displayClue(bagItem.locationType.Hospital);
    }
    public void bossClicked(Toggle t)
    {
        if (!t.isOn) return;
        this.displayClue(bagItem.locationType.Boss);

    }
    public void hallClicked(Toggle t)
    {
        if (!t.isOn) return;
        this.displayClue(bagItem.locationType.Hall);

    }
    public void DiClicked(Toggle t)
    {
        if (!t.isOn) return;
        this.displayClue(bagItem.locationType.Brother);

    }
    public void LiClicked(Toggle t)
    {
        if (!t.isOn) return;
        this.displayClue(bagItem.locationType.Li);

    }
    public void labClicked(Toggle t)
    {
        if (!t.isOn) return;
        this.displayClue(bagItem.locationType.Lab);

    }
}
