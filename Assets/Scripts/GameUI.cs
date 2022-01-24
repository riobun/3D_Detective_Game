using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject bookDisplay;
    public GameObject sceneDislay;
    public GameObject clueDislay;
    public GameObject truthDisplay;

    private List<bagItem> bagItemList;

    // Start is called before the first frame update
    void Start()
    {
        NewItemManager.Instance.loadItemConfig();
        this.bagItemList = NewItemManager.Instance.bagItemList;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (LabManager.Instance.findlab)
        {
            GameObject lab1 = sceneDislay.transform.Find("labButton").gameObject;
            GameObject lab2 = clueDislay.transform.Find("right/toggleGroup/lab").gameObject;
            if (!lab1.activeSelf)
            {
                lab1.SetActive(true);
            }
            if (!lab2.activeSelf)
            {
                lab2.SetActive(true);
            }
        }
        
    }

    public void activeBook()
    {
        bookDisplay.SetActive(true);
    }

    public void disactiveBook()
    {
        bookDisplay.SetActive(false);
    }

    public void activeTruth()
    {
        truthDisplay.SetActive(true);
    }

    public void disactiveTruth()
    {
        truthDisplay.SetActive(false);
    }

    public void activeScene()
    {
        sceneDislay.SetActive(true);
    }

    public void disactiveScene()
    {
        sceneDislay.SetActive(false);
    }

    public void activeClue()
    {
        clueDislay.SetActive(true);
    }

    public void disactiveclue()
    {
        clueDislay.SetActive(false);
    }

    public void toHospital()
    {
        SceneManager.LoadScene(6);      
    }

    public void toDIDI()
    {
        SceneManager.LoadScene(5);
    }

    public void toLi()
    {
        SceneManager.LoadScene(3);
    }

    public void toDinnerHall()
    {
        SceneManager.LoadScene(1);
    }
    public void toBoss()
    {
        SceneManager.LoadScene(7);
    }
    public void toLab()
    {
        SceneManager.LoadScene(4);
    }

    public void toOver()
    {
        SceneManager.LoadScene(2);
    }

    public void gameOver()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

    public List<string> findClue(int id)
    {
        this.bagItemList[id - 1].isFind = 1;
        List<string> itemInfo = new List<string>();
        itemInfo.Add(this.bagItemList[id - 1].name);
        itemInfo.Add(this.bagItemList[id - 1].desc);
        return itemInfo;
    }
}
