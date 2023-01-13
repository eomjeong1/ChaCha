using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISticker : MonoBehaviour
{
    // 스티커 오디오
    public AudioSource[] audioPlayer;
    AudioClip[] audioClips;

    // 대화 이벤트 오디오
    public AudioSource CallPlayer;
    public AudioClip granMaSound;
    public AudioClip uncleSound;

    // 스티커 버튼, 이미지 배열
    public Button[] btnSound;
    public Image[] imgSc;
    Sticker[] stickers;
    

    // 선택지 버튼
    public GameObject btnOption;

    // 할머니, 삼촌 구분 불리언
    bool GCheckAgain;
    bool UCheckAgain;

    // UI프로필 디렉션 텍스트 불리언
    public bool needDrirect;

    // 갱신된 할머니, 삼촌 버튼
    public Image GranMaBtn;
    public Image UncleBtn;

    // 필요한 조건  
    int idx;
    StickerManager stickerManager;
    ScenesManager scenesManager;
    UIProfile UIProfile;

    // 스티커 배치, 버튼, 오디오 배열
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
    
    // 오디오 플레이 함수
    public void PlaySound(int num)
    {
        audioPlayer[idx].Stop();
        audioPlayer[num].Play();
        idx = num;
    }

    // 스티커를 눌렀는지 확인해주는 bool
    public void IsCheckTrue(int num)
    {
        stickers[num].isCheck = true;
        Debug.Log($"{stickers[num].stickerName}를 확인했습니다.");
    }

    public string[] infotxts = {"바닥에 화살표가 생겼어요! 어디로 갈까요?", "바닥에 기다리기와 건너기버튼이 생겼어요! 어떻게 할까요?","할머니가 힘들어보이시는데 할머니 버튼을 다시 눌러볼까요?", "바닥에 화살표가 생겼어요! 지름길로 갈까요, 돌아서 갈까요?","옆집아저씨가 무슨 말씀을 하시는지 한번 더 눌러볼까요?"};
    // 스티커를 전부 눌러야 옵션 버튼이 뜨게 하는 기능.
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
            needDrirect = true;
        }

        OpenOption();
    }
    // 옵션 버튼을 불러오는 기능
    public void OpenOption()
    {
        
        // 3,5 스테이지에는 버튼의 기능을 갱신해주는 기능
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
            Debug.Log("스테이지 3,5 아님. 선택지 on");
        }
    }

    // 다시 할머니 눌렀을 때 코루틴을 실행할 수 있는 조건 완성;
    public void GranMaAgain()
    {
        GCheckAgain = true;
        GCheckBool();
       
    }
    // 할머니 코루틴 조건이 완성됐다면 코루틴 실행하는 함수 실행.
    public void GCheckBool()
    {
        if (GCheckAgain == true)
        {
            GrandMaCall();
        }
        else
            return;
    }

    // 다시 삼촌 눌렀을 때 코루틴을 실행할 수 있는 조건 완성;
    public void UncleAgain()
    {
        UCheckAgain = true;
        UCheckBool();
    }

    // 삼촌 코루틴 조건이 완성됐다면 코루틴 실행하는 함수 실행.
    public void UCheckBool()
    {
        if (UCheckAgain == true)
        {
            UncleCall();
        }
        else
            return;

    }

    // 할머니 대화 오디오 실행시키고 코루틴 실행시키는 함수
    void GrandMaCall()
    {
        
        CallPlayer.clip = granMaSound;
        CallPlayer.Play();
        StartCoroutine(TalkWait());
        
        lookGranMa = false;
            Debug.Log("lookGranMa = false");


    }
    // 삼촌 대화 오디오 실행시키고 코루틴 실행시키는 함수
    void UncleCall()
    {
        CallPlayer.clip = uncleSound;
        CallPlayer.Play();
        StartCoroutine(TalkWait());
        
        lookUncle = false;
        Debug.Log("lookUncle = false");

    }

    // 대화 오디오가 끝날때까지 옵션 버튼숨기기 코루틴
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
