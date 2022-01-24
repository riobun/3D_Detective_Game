using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BagItemDetail : MonoBehaviour
{
    public Text title;
    public Text desc;

    private bagItem item;

    public void setData(bagItem item)
    {
        this.title.text = item.name;
        this.desc.text = item.desc;
    }
}
