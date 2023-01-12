using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
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
    public Image Score;
    public Image Stnum;

    public Text Answertxt1;
    public Text Answertxt2;
    public Text Answertxt3;

    // 정답 텍스트배열
    public string[,] AnswertxtList;


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
                int index = i;
                buttons[index].gameObject.AddComponent<AudioSource>();
                buttons[index].onClick.AddListener(() => this.ShowAnswer(index));

                Debug.Log("버튼 셋팅 완료");

                ChangeBtnUI(i);
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
        answerSheet.gameObject.SetActive(false);



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
        answerSheet.gameObject.SetActive(false);


    }
    public void ShowAnswer(int index)
    {
        string[,] AnswertxtList = new string[,]{
        { "보호자와 약속되지 않은 곳은 가면 안돼요." , "-어딘가 가고 싶을때는 부모님이나 보호자에게, 가는 위치와 이유를 설명해야해요." , ""}, /*1행*/
        { "신호등의 초록불이 깜빡일때 무리해서 건너면 안돼요.","-안전하게 다음 신호를 기다렸다, 꼭 도로의 좌우를 확인하고 손을 들고 횡단보도를 건너가야해요.",""}, /*2행*/
        { "모르는 사람을 함부로 도와주면 안돼요","-모르는 사람이 주는 음식을 먹거나 모르는 사람의 차를 타면 안돼요.","-어른들은 어린이들에게 도와달라고 하지 않아요.누군가 도움을 청할땐 그 주변의 어른에게 도와달라고 전달하세요."}, /*3행*/
        { "공사장 주변은 다가가면 안돼요.","-공사장 위에서 물건이 떨어지거나 공사장 시설이 무너질 수도 있어요.","-공사장이 지름길이더라도 안전하게 다른 길로 돌아가요."}, /*4행*/
        { "아무리 잘 아는 어른이어도 혼자서 따라가면 안돼요.","-잘 아는 어른이어도 혼자 따라가면 위험해요.","-혹시 가고 싶다면 부모님이나 보호자에게 어디 가는지 알린뒤 허락을 받고 가야해요."} /*5행*/
    };

        Score.gameObject.SetActive(false);
        answerSheet.gameObject.SetActive(true);
        Stnum.sprite = buttons[index].image.sprite;
        Debug.Log($"버튼{index}와 같은 이미지배치");

        string v = AnswertxtList[index, 0].ToString();
        Answertxt1.text = v;
        Debug.Log($"정답{index}");

        string y = AnswertxtList[index, 1].ToString();
        Answertxt2.text = y;
        Debug.Log($"해설1 - {index}");

        string z = AnswertxtList[index, 2].ToString();
        Answertxt3.text = z;
        Debug.Log($"해설2 - {index}");


    }

    public void ChangeBtnUI(int idx)
    {
        sM = ScenesManager.GetInstance();
        num = idx;
        if (!sM.isCor[num])
        {
            buttons[num].image.sprite = Resources.Load<Sprite>($"Image/Result/incorr{num + 1}");           
            Debug.Log($"{num}번째 버튼의 이미지를 오답으로 바꿉니다.");
        }

        if (sM.isCor[num])
        {           
            Debug.Log($"{num}번째 버튼의 isCorr == false 정답으로 바꿉니다.");           
            buttons[num].image.sprite = Resources.Load<Sprite>($"Image/Result/corr{num + 1}");            
        }
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
        if (gM.curScore == 4)
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
