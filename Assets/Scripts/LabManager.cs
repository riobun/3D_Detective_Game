using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabManager
{
    private static LabManager instance;
    public bool findlab = false;
    public static LabManager Instance
    {
        get
        {
            if (instance == null) instance = new LabManager();
            return instance;
        }
    }
}
