using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Photon.Pun;
using Photon.Realtime;

public class SceneLoader : MonoBehaviourPunCallbacks
{
    public GameObject eventObj;
    private Scene scene;

    public Button hospital;
    public Button boss;
    public Button didi;
    public Button li;
    public Button lab;
    public Button dinnerHall;
    public Button next;

    public Animator animator;

    public GameObject sceneDisplay;

    private int playerNum = -1;
    private int alreadyReadyPlayerNum = 0;

    private bool readyToNext = true;


    // Start is called before the first frame update
    void Start()
    {

        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(this.eventObj);

        hospital.onClick.AddListener(ToHospital);
        boss.onClick.AddListener(ToBoss);
        didi.onClick.AddListener(ToDidi);
        li.onClick.AddListener(ToLi);
        lab.onClick.AddListener(ToLab);
        dinnerHall.onClick.AddListener(ToDinnerHall);
        next.onClick.AddListener(ToNext);

    }

    private void Update()
    {
        if (readyToNext && playerNum == alreadyReadyPlayerNum)
        {
            readyToNext = false;
            GameObject.Find("Canvas").GetComponent<GameUI>().disactiveRemindUI();
            StartCoroutine(LoadScene("End"));
        }
    }

    private void ToNext()
    {
        GameObject.Find("Canvas").GetComponent<GameUI>().disactiveNext();
        GameObject.Find("Canvas").GetComponent<GameUI>().activeRemindUI();
        playerNum = PhotonNetwork.CurrentRoom.PlayerCount;


        //Debug.Log("playerNum:" + playerNum);
        this.photonView.RPC("sendReadyMessage", RpcTarget.All);
        //Debug.Log("send后 alreadyReadyPlayerNum:" + alreadyReadyPlayerNum);
        //StartCoroutine(LoadScene("End"));

    }

    [PunRPC]
    public void sendReadyMessage()
    {
        //Debug.Log("send前 alreadyReadyPlayerNum:" + alreadyReadyPlayerNum);

        this.alreadyReadyPlayerNum += 1;
        //Debug.Log("+1后 alreadyReadyPlayerNum:" + alreadyReadyPlayerNum);
        GameObject.Find("Canvas").GetComponent<GameUI>().updateStateUI(this.alreadyReadyPlayerNum);
    }

    /*[PunRPC]
    public void disactiveReadyUI()
    {
        readyToNext = false;
        GameObject.Find("Canvas").GetComponent<GameUI>().disactiveRemindUI();
    }*/

    private void ToDinnerHall()
    {
        StartCoroutine(LoadScene("DinnerHall"));

    }

    private void ToLab()
    {
        StartCoroutine(LoadScene("Lab"));

    }

    private void ToLi()
    {
        StartCoroutine(LoadScene("Mr.Li"));

    }

    private void ToDidi()
    {
        StartCoroutine(LoadScene("ZhenBro"));

    }

    private void ToBoss()
    {
        StartCoroutine(LoadScene("ZhenBoss"));

    }

    private void ToHospital()
    {
        StartCoroutine(LoadScene("Hospital"));

    }

    IEnumerator LoadScene(string scene_name)
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);

        yield return new WaitForSeconds(1);

        //异步加载场景
        AsyncOperation async = SceneManager.LoadSceneAsync(scene_name);
        async.completed += OnLoadedScene;

    }

    //场景加载完成后的回调函数
    private void OnLoadedScene(AsyncOperation obj)
    {
        sceneDisplay.SetActive(false);
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);


        this.scene = SceneManager.GetActiveScene();
        if (this.scene.name == "End")
        {
            Destroy(this.gameObject);
            Destroy(this.eventObj);
        }

    }

}
