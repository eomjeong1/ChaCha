using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ResultUI : MonoBehaviour
{
    public Button toMainBtn;
    public Button SkipBtn;
    public VideoPlayer gVid;
    public VideoPlayer bVid;
    public RawImage gV;
    public RawImage bV;
    bool isOver;
    public Image img;
    public ScenesManager sM;
    public int num;

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

        if (SkipBtn != null)
            SkipBtn.onClick.AddListener(Skip);
        if (toMainBtn != null)
            toMainBtn.onClick.AddListener(ToMain);
        

        if (buttons != null)
        {
            sM = ScenesManager.GetInstance();
            
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.AddComponent<AudioSource>();
                buttons[i].onClick.AddListener(ShowAnswer);
                Debug.Log("버튼 셋팅 완료");

                GreenRed(i);

                /*img = Resources.Load<Image>($"Image/Result/{i}");
                img.gameObject.SetActive(false);*/
            }

        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {

        gV.gameObject.SetActive(false);
        bV.gameObject.SetActive(false);
        SkipBtn.gameObject.SetActive(false);
        Debug.Log("CheckOver");
    }
    public void ToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    public void Skip()
    {
        gV.gameObject.SetActive(false);
        gVid.Stop();
        bV.gameObject.SetActive(false);
        bVid.Stop();
        SkipBtn.gameObject.SetActive(false);
    }
    public void ShowAnswer()
    {
        img.gameObject.SetActive(true);
    }
    public void GreenRed(int idx)
    {
        sM = ScenesManager.GetInstance();
        num = idx;
        if (!sM.isCor[num])
        {
            buttons[num].image.color = Color.red;
            Debug.Log($"{num}번째 버튼의 isCorr == true 빨강으로 바꿉니다.");
        }

        if (sM.isCor[num])
        {
            buttons[num].image.color = Color.green;
            Debug.Log($"{num}번째 버튼의 isCorr == false 초록으로 바꿉니다.");
        }
    }
}
