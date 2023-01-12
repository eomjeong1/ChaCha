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
    public bool lookUncle;
    public bool lookGranMa;

    Sticker[] stickers;

    public StickerManager stickerManager;
    public EventManager eventManager;
    public ScenesManager scenesManager;
    
    private void Start()
    {
        stickerManager = StickerManager.GetInstance();
        eventManager = EventManager.GetInstance();
        scenesManager = ScenesManager.GetInstance();
        //ScenesManager.GetInstance().currentGame = 4; //테스트용//
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
            btnSound[i].onClick.AddListener(()=> { PlaySound(idx); });
            btnSound[i].onClick.AddListener(()=> { IsCheckTrue(idx); });
            btnSound[i].onClick.AddListener(IsCheckBool);
        }
    }

    public void PlaySound(int num)
    {
        audioPlayer[num].Play();
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
        
        btnOption.SetActive(true);
        if (ScenesManager.GetInstance().currentGame == 3) 
        {
            lookGranMa = true;
            eventManager.TalkGranMa();
            Debug.Log("할머니대화시작");
            
        }
        if (ScenesManager.GetInstance().currentGame == 5)
        {
            lookUncle = true;
            eventManager.TalkUncle();
            Debug.Log("아저씨대화시작");
        }


    }
}
