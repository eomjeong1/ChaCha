using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ResultUI : MonoBehaviour
{ 
   public Button Back;
    public Button resultBtn;
    public VideoPlayer gVid;
    public VideoPlayer bVid;
    public RawImage gV;
    public RawImage bV;
    bool isOver;
    public Image[] imginfo;

    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        gV = GetComponentsInChildren<RawImage>()[0];
        bV = GetComponentsInChildren<RawImage>()[1];

        gVid = GetComponentsInChildren<VideoPlayer>()[0];
        bVid = GetComponentsInChildren<VideoPlayer>()[1];

        gV.gameObject.SetActive(false);
        bV.gameObject.SetActive(false);

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
        
        if (resultBtn != null)
            resultBtn.onClick.AddListener(result);

        if (buttons != null)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = GetComponentInChildren<Button>();
                buttons[i].gameObject.SetActive(false);
                buttons[i].gameObject.AddComponent<AudioSource>();
                
            }
            
        }


    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        
        gV.gameObject.SetActive(false);
        bV.gameObject.SetActive(false);
        resultBtn.gameObject.SetActive(false);
        Debug.Log("CheckOver");
    }
    public void result()
    {
        gV.gameObject.SetActive(false);
        gVid.Stop();
        bV.gameObject.SetActive(false);
        bVid.Stop();
        resultBtn.gameObject.SetActive(false);
    }
    public void CheckCor()
    { 
        
    }

}
