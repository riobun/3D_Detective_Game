using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class dialogController : MonoBehaviour
{
    public Flowchart flowchart;
    public GameObject start;
    public GameObject canvas;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (flowchart.GetBooleanVariable("start"))
        {
            start.SetActive(false);
            canvas.SetActive(false);
            flowchart.SetBooleanVariable("start", false);

        }
        if (flowchart.GetBooleanVariable("occur"))
        {
            player.SetActive(true);
            flowchart.SetBooleanVariable("occur", false);

        }
        if (flowchart.GetBooleanVariable("next"))
        {            
            flowchart.SetBooleanVariable("next", false);
            SceneManager.LoadScene(1);
        }
    }
}
