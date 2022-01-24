using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bagItem
{
    public enum locationType
    {
        Unknown = -1,
        Boss,
        Hall,
        Hospital,
        Brother,
        Li,
        Lab
    }
    public int ID;
    public string name;
    public string desc;
    public int isFind;
    public locationType locate = locationType.Unknown;


    public bagItem(int id,string name,string desc,int locate, int isFind)
    {
        this.ID = id;
        this.desc = desc;
        this.name = name;
        this.isFind = isFind;
        switch (locate)
        {
            case -1:
                this.locate = locationType.Unknown;
                break;
            case 0:
                this.locate = locationType.Boss;
                break;
            case 1:
                this.locate = locationType.Hall;
                break;
            case 2:
                this.locate = locationType.Hospital;
                break;
            case 3:
                this.locate = locationType.Brother;
                break;
            case 4:
                this.locate = locationType.Li;
                break;
            case 5:
                this.locate = locationType.Lab;
                break;
            default:
                break;
        }

    }
}
