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

    // ���� �ؽ�Ʈ�迭
    public string[,] AnswertxtList;


    //�ʿ��� ����
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

                Debug.Log("��ư ���� �Ϸ�");

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
        { "��ȣ�ڿ� ��ӵ��� ���� ���� ���� �ȵſ�." , "-��� ���� �������� �θ���̳� ��ȣ�ڿ���, ���� ��ġ�� ������ �����ؾ��ؿ�." , ""}, /*1��*/
        { "��ȣ���� �ʷϺ��� �����϶� �����ؼ� �ǳʸ� �ȵſ�.","-�����ϰ� ���� ��ȣ�� ��ٷȴ�, �� ������ �¿츦 Ȯ���ϰ� ���� ��� Ⱦ�ܺ����� �ǳʰ����ؿ�.",""}, /*2��*/
        { "�𸣴� ����� �Ժη� �����ָ� �ȵſ�","-�𸣴� ����� �ִ� ������ �԰ų� �𸣴� ����� ���� Ÿ�� �ȵſ�.","-����� ��̵鿡�� ���ʹ޶�� ���� �ʾƿ�.������ ������ û�Ҷ� �� �ֺ��� ����� ���ʹ޶�� �����ϼ���."}, /*3��*/
        { "������ �ֺ��� �ٰ����� �ȵſ�.","-������ ������ ������ �������ų� ������ �ü��� ������ ���� �־��.","-�������� �������̴��� �����ϰ� �ٸ� ��� ���ư���."}, /*4��*/
        { "�ƹ��� �� �ƴ� ��̾ ȥ�ڼ� ���󰡸� �ȵſ�.","-�� �ƴ� ��̾ ȥ�� ���󰡸� �����ؿ�.","-Ȥ�� ���� �ʹٸ� �θ���̳� ��ȣ�ڿ��� ��� ������ �˸��� ����� �ް� �����ؿ�."} /*5��*/
    };

        Score.gameObject.SetActive(false);
        answerSheet.gameObject.SetActive(true);
        Stnum.sprite = buttons[index].image.sprite;
        Debug.Log($"��ư{index}�� ���� �̹�����ġ");

        string v = AnswertxtList[index, 0].ToString();
        Answertxt1.text = v;
        Debug.Log($"����{index}");

        string y = AnswertxtList[index, 1].ToString();
        Answertxt2.text = y;
        Debug.Log($"�ؼ�1 - {index}");

        string z = AnswertxtList[index, 2].ToString();
        Answertxt3.text = z;
        Debug.Log($"�ؼ�2 - {index}");


    }

    public void ChangeBtnUI(int idx)
    {
        sM = ScenesManager.GetInstance();
        num = idx;
        if (!sM.isCor[num])
        {
            buttons[num].image.sprite = Resources.Load<Sprite>($"Image/Result/incorr{num + 1}");           
            Debug.Log($"{num}��° ��ư�� �̹����� �������� �ٲߴϴ�.");
        }

        if (sM.isCor[num])
        {           
            Debug.Log($"{num}��° ��ư�� isCorr == false �������� �ٲߴϴ�.");           
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
