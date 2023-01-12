using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISticker : MonoBehaviour
{
    public AudioSource[] audioPlayer;
    AudioClip[] audioClips;
    public Button[] btnSound;
    public Image[] imgSc;

    public GameObject btnOption;

    bool lookGranMa;
    bool lookUncle;
    public AudioSource CallPlayer;
    public AudioClip granMaSound;
    public AudioClip uncleSound;
    public Image GranMaBtn;
    public Image UncleBtn;
    int idx;
    bool GCheckAgain;
    bool UCheckAgain;

    Sticker[] stickers;

    public StickerManager stickerManager;

    public ScenesManager scenesManager;

    private void Start()
    {
        stickerManager = StickerManager.GetInstance();


        //ScenesManager.GetInstance().currentGame = 5; //테스트용//
        stickers = stickerManager.stickerList[ScenesManager.GetInstance().currentGame];
        Debug.Log($"스테이지 {ScenesManager.GetInstance().currentGame}");
        /////////이거 수정했는데 함수 안 씀/////////

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
            Debug.Log($"{stickers[i].stickerName} 장착");

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

    public void PlaySound(int num)
    {
        audioPlayer[idx].Stop();
        audioPlayer[num].Play();
        idx = num;
    }

    public void IsCheckTrue(int num)
    {
        stickers[num].isCheck = true;
        Debug.Log($"{stickers[num].stickerName}를 확인했습니다.");
    }

    public void IsCheckBool()
    {
        //for (int i = 0; i < stickers.Length; i++)
        //{
        //    Debug.Log($"{stickers[i].stickerName}을 확인했나? : {stickers[i].isCheck}");
        //}

        for (int i = 0; i < stickers.Length; i++)
        {
            if (stickers[i].isCheck == false)
                return;
        }

        OpenOption();
    }

    public void OpenOption()
    {


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
            Debug.Log("스테이지 3,5 아님 선택지 on");
        }
    }
    public void GranMaAgain()
    {
        GCheckAgain = true;
        GCheckBool();
       
    }
    public void UCheckBool()
    {
        if (UCheckAgain == true)
        {
            UncleCall();
        }
        else
            return;

    }
    public void GCheckBool()
    {
        if (GCheckAgain == true)
        {
            GrandMaCall();
        }
        else
            return;
    }
    public void UncleAgain()
    {
        UCheckAgain = true;
        UCheckBool();
    }

    void GrandMaCall()
    {
        
        CallPlayer.clip = granMaSound;
        CallPlayer.Play();
        StartCoroutine(TalkWait());
        
        lookGranMa = false;
            Debug.Log("lookGranMa = false");


    }

    void UncleCall()
    {
        CallPlayer.clip = uncleSound;
        CallPlayer.Play();
        StartCoroutine(TalkWait());
        
        lookUncle = false;
        Debug.Log("lookUncle = false");

    }
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
                Debug.Log("선택지켜기");
            }
                


        }
       

        
    }
}
