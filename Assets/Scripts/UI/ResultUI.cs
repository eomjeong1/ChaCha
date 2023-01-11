using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityEngine.Video;

public class ResultUI : MonoBehaviour
{
    //Button
    public Button toMainBtn;
    public Button SkipBtn;
    public Button ScoreBoardBtn;
    public Button[] buttons;

    //VideoPlayer
    public VideoPlayer gVid;
    public VideoPlayer bVid;
    public RawImage gV;
    public RawImage bV;

    //Image
    public Image answer;
    public Image ScoreBoard;
    public Image Score;

    //필요한 조건
     ScenesManager sM;
     GameManager gM;
     int num;
     int number;
    public GameObject answerSheet;
    

    
    // Start is called before the first frame update
    void Start()
    {
        gV = GetComponentsInChildren<RawImage>()[0];
        bV = GetComponentsInChildren<RawImage>()[1];

        gVid = GetComponentsInChildren<VideoPlayer>()[0];
        bVid = GetComponentsInChildren<VideoPlayer>()[1];

        gV.gameObject.SetActive(false);
        bV.gameObject.SetActive(false);

        if (ScoreBoardBtn != null)
            ScoreBoardBtn.onClick.AddListener(ScoreBoardClose);
        if (SkipBtn != null)
            SkipBtn.onClick.AddListener(SkipVideo);
        if (toMainBtn != null)
            toMainBtn.onClick.AddListener(ToMain);
        SkipBtn.gameObject.SetActive(true);

        if (buttons != null)
        {
            sM = ScenesManager.GetInstance();
            
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.AddComponent<AudioSource>();
                buttons[i].onClick.AddListener(ShowAnswer);
                
                Debug.Log("버튼 셋팅 완료");

                ChangeBtnUI(i);



                /*img = Resources.Load<Image>($"Image/Result/{i}");
                img.gameObject.SetActive(false);*/
            }


        }
        VideoPlay();
        ScoreCulculate();

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

    public void SkipVideo()
    {
        gV.gameObject.SetActive(false);
        gVid.Stop();
        bV.gameObject.SetActive(false);
        bVid.Stop();
        SkipBtn.gameObject.SetActive(false);
        
    }
    public void ShowAnswer()
    {
        
        answer.gameObject.SetActive(true);
        
        
        

    }

    public void ChangeBtnUI(int idx)
    {
        sM = ScenesManager.GetInstance();
        num = idx;
        if (!sM.isCor[num])
        {
            buttons[num].image.sprite = Resources.Load<Sprite>($"Image/Result/incorr{num+1}");
            Debug.Log($"{num}번째 버튼의 이미지를 오답으로 바꿉니다.");         
        }

        if (sM.isCor[num])
        {
            buttons[num].image.sprite = Resources.Load<Sprite>($"Image/Result/corr{num+1}");
            Debug.Log($"{num}번째 버튼의 isCorr == false 정답으로 바꿉니다.");
            answer.sprite = Resources.Load<Sprite>($"Image/Result/incorr{num + 1}");
        }
    }

    public void ScoreBoardClose()
    {
        ScoreBoard.gameObject.SetActive(false);
        answerSheet.SetActive(true);


    }
    public void VideoPlay()
    {
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

    }
    public void ScoreCulculate()
    {
        gM = GameManager.GetInstance();

        if (gM.curScore == 5)
        { 
            Score.sprite = Resources.Load<Sprite>($"Image/Result/Score5");
        }
        if (gM.curScore == 4 )
        {
            Score.sprite = Resources.Load<Sprite>($"Image/Result/Score4");
        }
        if (gM.curScore == 3)
        {
            Score.sprite = Resources.Load<Sprite>($"Image/Result/Score3");
        }
        if (gM.curScore == 2)
        {
            Score.sprite = Resources.Load<Sprite>($"Image/Result/Score2");
        }
        if (gM.curScore == 1)
        {
            Score.sprite = Resources.Load<Sprite>($"Image/Result/Score1");
        }
        if (gM.curScore == 0)
        {
            Score.sprite = Resources.Load<Sprite>($"Image/Result/Score0");
        }
    }

}
