using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour
{
    static music _instance;
    AudioSource Orange;//获取AudioOrange组件

    public AudioClip audio1;

    private Scene scene;
    private bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        Orange = transform.GetComponent<AudioSource>();
        this.scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        this.scene = SceneManager.GetActiveScene();
        if (this.scene.buildIndex == 2)

        {
            if (play == true)
                return;

            Orange.Stop();
            Orange.clip = audio1;
            Orange.Play();
            play = true;
        }
    }

    public static music instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<music>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {

        //此脚本永不消毁，并且每次进入初始场景时进行判断，若存在重复的则销毁
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != _instance)
        {
            Destroy(gameObject);
        }

    }
}
