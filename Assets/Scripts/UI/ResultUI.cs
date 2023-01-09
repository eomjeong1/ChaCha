using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngineInternal;

public class ResultUI : MonoBehaviour
{
   public Button R1;
   public Button Back;
    public Button resultBtn;
   public RawImage RImg;
   public VideoPlayer vid;
    public VideoPlayer gVid;
    public VideoPlayer bVid;
    public RawImage gV;
    public RawImage bV;
    bool isOver;

    // Start is called before the first frame update
    void Start()
    {
        gV = GetComponentsInChildren<RawImage>()[0];
        bV = GetComponentsInChildren<RawImage>()[1];
        RImg = GetComponentsInChildren<RawImage>()[2];

        gVid = GetComponentsInChildren<VideoPlayer>()[0];
        bVid = GetComponentsInChildren<VideoPlayer>()[1];
        vid = GetComponentsInChildren<VideoPlayer>()[2];

        gV.gameObject.SetActive(false);
        bV.gameObject.SetActive(false);
        RImg.gameObject.SetActive(false);

        if (GameManager.GetInstance().curScore >= 3)
        {
            gV.gameObject.SetActive(true);
            gVid.Play();
        }

        if (GameManager.GetInstance().curScore <= 2)
        {
            bV.gameObject.SetActive(true);
            bVid.Play();
        }
            

        gVid.loopPointReached += CheckOver;
        bVid.loopPointReached += CheckOver;
        if (isOver == true)
        {
            Debug.Log("isOver");
           gV.gameObject.SetActive(false);
           bV.gameObject.SetActive(false);
        }

        

        if (R1 != null)
        R1.onClick.AddListener(R1Btn);
        if (resultBtn != null)
            resultBtn.onClick.AddListener(result);
        if (Back != null)
            Back.onClick.AddListener(BackBtn);
            Back.gameObject.SetActive(false);

            RImg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void R1Btn()
    {   
        Debug.Log("Onclick");
        RImg.gameObject.SetActive(true);
        Back.gameObject.SetActive(true);
        vid.gameObject.SetActive(true);

        vid.clip = Resources.Load<VideoClip>($"Video/result/È¾´Üº¸µµ±³À°");
        Debug.Log("VideoFound");
        vid.Play();
        Debug.Log("VideoPlay");
        vid.loopPointReached += CheckOver;
    }
    public void BackBtn()
    { 
        RImg.gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
        vid.Stop();
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("CheckOver");
        isOver = true;
    }
    public void result()
    {
        gV.gameObject.SetActive(false);
        gVid.Stop();
        bV.gameObject.SetActive(false);
        bVid.Stop();
        resultBtn.gameObject.SetActive(false);
    }
}
