using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPause : MonoBehaviour
{
    AudioSource Orange;//获取AudioOrange组件

    // Start is called before the first frame update
    void Start()
    {
        Orange = transform.GetComponent<AudioSource>();//对Orange组件进行赋值
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))

        {
            Orange.Stop();//当按下R键，音乐停止，点击U时重头开始播放音乐

        }

        if (Input.GetKeyDown(KeyCode.P))

        {
            Orange.Pause();//当按下T键，音乐暂停

        }

        if (Input.GetKeyDown(KeyCode.R))

        {
            Orange.Play();//当按下U键，音乐继续播放

        }


    }
}
