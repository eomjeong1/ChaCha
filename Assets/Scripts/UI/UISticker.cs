using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISticker : MonoBehaviour
{
    // ��ƼĿ �����
    public AudioSource[] audioPlayer;
    AudioClip[] audioClips;

    // ��ȭ �̺�Ʈ �����
    public AudioSource CallPlayer;
    public AudioClip granMaSound;
    public AudioClip uncleSound;

    // ��ƼĿ ��ư, �̹��� �迭
    public Button[] btnSound;
    public Image[] imgSc;
    Sticker[] stickers;
    

    // ������ ��ư
    public GameObject btnOption;

    // �ҸӴ�, ���� ���� �Ҹ���
    bool GCheckAgain;
    bool UCheckAgain;

    // UI������ �𷺼� �ؽ�Ʈ �Ҹ���
    public bool needDrirect;

    // ���ŵ� �ҸӴ�, ���� ��ư
    public Image GranMaBtn;
    public Image UncleBtn;

    // �ʿ��� ����  
    int idx;
    StickerManager stickerManager;
    ScenesManager scenesManager;
    UIProfile UIProfile;

    // ��ƼĿ ��ġ, ��ư, ����� �迭
    private void Start()
    {
        stickerManager = StickerManager.GetInstance();

        //ScenesManager.GetInstance().currentGame = 5; //�׽�Ʈ��//
        stickers = stickerManager.stickerList[ScenesManager.GetInstance().currentGame];
        Debug.Log($"�������� {ScenesManager.GetInstance().currentGame}");
        /////////�̰� �����ߴµ� �Լ� �� ��/////////

        audioPlayer = new AudioSource[stickers.Length];
        audioClips = new AudioClip[stickers.Length];
        btnSound = new Button[stickers.Length];
        imgSc = new Image[stickers.Length];

        Debug.Log($"{stickers.Length}");

        for (int i = 0; i < stickers.Length; i++)
        {
            Debug.Log($"{i}");
            imgSc[i] = GetComponentsInChildren<Image>()[i];
            imgSc[i].sprite = Resources.Load<Sprite>($"Image/Stage{ScenesManager.GetInstance().currentGame}/{stickers[i].stickerName}");
            Debug.Log($"{stickers[i].stickerName} ����");

            imgSc[i].gameObject.AddComponent<AudioSource>();
            audioPlayer[i] = imgSc[i].gameObject.GetComponent<AudioSource>();
            audioClips[i] = Resources.Load<AudioClip>($"Sound/{stickers[i].stickerSound}");
            audioPlayer[i].clip = audioClips[i];
            audioPlayer[i].Stop();

            int idx = i;
            btnSound[i] = imgSc[i].gameObject.GetComponent<Button>();
            btnSound[i].onClick.AddListener(() => { PlaySound(idx); });
            btnSound[i].onClick.AddListener(() => { IsCheckTrue(idx); });
            btnSound[i].onClick.AddListener(IsCheckBool);
        }
    }
    
    // ����� �÷��� �Լ�
    public void PlaySound(int num)
    {
        audioPlayer[idx].Stop();
        audioPlayer[num].Play();
        idx = num;
    }

    // ��ƼĿ�� �������� Ȯ�����ִ� bool
    public void IsCheckTrue(int num)
    {
        stickers[num].isCheck = true;
        Debug.Log($"{stickers[num].stickerName}�� Ȯ���߽��ϴ�.");
    }

    public string[] infotxts = {"�ٴڿ� ȭ��ǥ�� ������! ���� �����?", "�ٴڿ� ��ٸ���� �ǳʱ��ư�� ������! ��� �ұ��?","�ҸӴϰ� �����̽ôµ� �ҸӴ� ��ư�� �ٽ� ���������?", "�ٴڿ� ȭ��ǥ�� ������! ������� �����, ���Ƽ� �����?","������������ ���� ������ �Ͻô��� �ѹ� �� ���������?"};
    // ��ƼĿ�� ���� ������ �ɼ� ��ư�� �߰� �ϴ� ���.
    public void IsCheckBool()
    {
        //for (int i = 0; i < stickers.Length; i++)
        //{
        //    Debug.Log($"{stickers[i].stickerName}�� Ȯ���߳�? : {stickers[i].isCheck}");
        //}

        for (int i = 0; i < stickers.Length; i++)
        {
            if (stickers[i].isCheck == false)
                return;
            needDrirect = true;
        }

        OpenOption();
    }
    // �ɼ� ��ư�� �ҷ����� ���
    public void OpenOption()
    {
        
        // 3,5 ������������ ��ư�� ����� �������ִ� ���
        if (ScenesManager.GetInstance().currentGame == 3)
        {
            btnOption.SetActive(false);
            lookGranMa = true;
            Debug.Log("lookGranMa = true");
            GranMaBtn.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            GranMaBtn.gameObject.GetComponent<Button>().onClick.AddListener(GranMaAgain);
            
            GCheckBool();
        }
        else if (ScenesManager.GetInstance().currentGame == 5)
        {
            btnOption.SetActive(false);
            lookUncle = true;
            Debug.Log("lookUncle = true");
            UncleBtn.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            UncleBtn.gameObject.GetComponent<Button>().onClick.AddListener(UncleAgain);
            
            UCheckBool();
            
            
        }
        else 
        {
            btnOption.SetActive(true);
            Debug.Log("�������� 3,5 �ƴ�. ������ on");
        }
    }

    // �ٽ� �ҸӴ� ������ �� �ڷ�ƾ�� ������ �� �ִ� ���� �ϼ�;
    public void GranMaAgain()
    {
        GCheckAgain = true;
        GCheckBool();
       
    }
    // �ҸӴ� �ڷ�ƾ ������ �ϼ��ƴٸ� �ڷ�ƾ �����ϴ� �Լ� ����.
    public void GCheckBool()
    {
        if (GCheckAgain == true)
        {
            GrandMaCall();
        }
        else
            return;
    }

    // �ٽ� ���� ������ �� �ڷ�ƾ�� ������ �� �ִ� ���� �ϼ�;
    public void UncleAgain()
    {
        UCheckAgain = true;
        UCheckBool();
    }

    // ���� �ڷ�ƾ ������ �ϼ��ƴٸ� �ڷ�ƾ �����ϴ� �Լ� ����.
    public void UCheckBool()
    {
        if (UCheckAgain == true)
        {
            UncleCall();
        }
        else
            return;

    }

    // �ҸӴ� ��ȭ ����� �����Ű�� �ڷ�ƾ �����Ű�� �Լ�
    void GrandMaCall()
    {
        
        CallPlayer.clip = granMaSound;
        CallPlayer.Play();
        StartCoroutine(TalkWait());
        
        lookGranMa = false;
            Debug.Log("lookGranMa = false");


    }
    // ���� ��ȭ ����� �����Ű�� �ڷ�ƾ �����Ű�� �Լ�
    void UncleCall()
    {
        CallPlayer.clip = uncleSound;
        CallPlayer.Play();
        StartCoroutine(TalkWait());
        
        lookUncle = false;
        Debug.Log("lookUncle = false");

    }

    // ��ȭ ������� ���������� �ɼ� ��ư����� �ڷ�ƾ
    IEnumerator TalkWait()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.0f);
            if (CallPlayer.isPlaying)
            {
                btnOption.SetActive(false);
                
            }
            else
            {
                StopAllCoroutines();
                btnOption.SetActive(true);
                Debug.Log("�������ѱ�");
            }              
        }       
    }
}
