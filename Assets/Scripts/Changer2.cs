using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Changer2 : MonoBehaviour
{
    public VideoPlayer vid;
    bool isCorr;
    int currentGame;
    public string curScene;

    public Button btnSkip;

    void Start()
    {
        this.isCorr = ScenesManager.GetInstance().isCorr;
        this.currentGame = ScenesManager.GetInstance().currentGame;

        btnSkip.onClick.AddListener(OnSkip);
        vid = GetComponentInChildren<VideoPlayer>();

        if (isCorr)
            curScene = $"corr{currentGame}";

        else
            curScene = $"incor{currentGame}";


        vid.clip = Resources.Load<VideoClip>($"Video/corr/{curScene}");

        Debug.Log($"영상이 종료된 후 맵으로 이동합니다.");

        vid.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("맵");
        ScenesManager.GetInstance().ChangeScene(Scene.Changer1);

        ScenesManager.GetInstance().currentGame++;
    }

    void OnSkip()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Changer1);
        ScenesManager.GetInstance().currentGame++;
    }
}
