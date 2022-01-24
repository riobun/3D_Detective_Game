using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

public class NewItemManager
{
    private static NewItemManager instance;
    public static NewItemManager Instance
    {
        get
        {
            if (instance == null) instance = new NewItemManager();
            return instance;
        }
    }

    private JsonData itemConfig;
    public List<bagItem> bagItemList;
    public void loadItemConfig()
    {
        if (this.bagItemList == null)
        {
            this.bagItemList = new List<bagItem>();
        }
        this.itemConfig = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/config/item.json",Encoding.GetEncoding("GB2312")));

        this.decodeJson();
    }

    private void decodeJson()
    {
        for( int i = 0; i < this.itemConfig.Count; i++)
        {
            int ID = (int)this.itemConfig[i]["ID"];
            string name = this.itemConfig[i]["name"].ToString();
            string desc = this.itemConfig[i]["desc"].ToString();
            int locate = (int)this.itemConfig[i]["locate"];
            int isFind = (int)this.itemConfig[i]["isFind"];
            

            bagItem item = new bagItem(ID,name,desc,locate,isFind);
            this.bagItemList.Add(item);
        }
    }

}
