using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Fungus;


public class control : MonoBehaviour
{
    public PlayableDirector AnimationController;
    public TimelineAsset[] timelines;
    public string[] timelinename;
    public Flowchart flowchart;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < timelines.Length; i++)
        {
            if (flowchart.GetBooleanVariable(timelinename[i]))
            {
                AnimationController.Play(timelines[i]);
                flowchart.SetBooleanVariable(timelinename[i], false);
            }
        }
    }
}
