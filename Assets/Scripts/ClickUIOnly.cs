using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickUIOnly : MonoBehaviour
{
    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse was clicked over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("射线不会透过UI执行其他的操作");
            }
        }
    }

}
