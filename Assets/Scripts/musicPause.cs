using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPause : MonoBehaviour
{
    AudioSource Orange;//��ȡAudioOrange���

    // Start is called before the first frame update
    void Start()
    {
        Orange = transform.GetComponent<AudioSource>();//��Orange������и�ֵ
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))

        {
            Orange.Stop();//������R��������ֹͣ�����Uʱ��ͷ��ʼ��������

        }

        if (Input.GetKeyDown(KeyCode.P))

        {
            Orange.Pause();//������T����������ͣ

        }

        if (Input.GetKeyDown(KeyCode.R))

        {
            Orange.Play();//������U�������ּ�������

        }


    }
}
