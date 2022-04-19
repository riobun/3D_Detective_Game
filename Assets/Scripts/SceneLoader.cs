using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
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

    private void ToNext()
    {
        StartCoroutine(LoadScene("End"));
    }

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

        //�첽���س���
        AsyncOperation async = SceneManager.LoadSceneAsync(scene_name);
        async.completed += OnLoadedScene;

    }

    //����������ɺ�Ļص�����
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

    // Update is called once per frame
    void Update()
    {
 

    }

}
