using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bagItemInfo : MonoBehaviour
{
    public Text name;
    private bagItem item;

    public void setData(bagItem item)
    {
        if (item == null)
        {
            Debug.LogError("item is empty!");
            return;
        }
        this.item = item;
        this.name.text = this.item.name;
    }
}
