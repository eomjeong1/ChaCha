using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UIProfile : MonoBehaviour
{
    GameManager gameManager;
    ScenesManager sM;
    public Button hint;
    public Button guide;
    public Image hintBg;
    public Button closehint;
    public Text hinttxt;
    string[] hinttxtList = { "주변에 하고 싶은 것, 먹고 싶은 것들이 있지만 얼른 집으로 가야해요.", "초록불 신호가 얼마 남지 않았다면 다음 신호를 기다렸다가 지나가는 건 어떨까요?", 
        "할머니 뒤에 있는 검은 차는 뭘까요? 수상하네요!" , "지름길이라도 위험한 길은 피해서 가는 게 좋겠는데요?" , "아무리 옆집아저씨라도 혼자서 따라가면 안돼요!"};


    public Image[] apple = new Image[5];
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();

        

        if (hint != null)
        {
            hint.onClick.AddListener(HintBtn);
        }
        if (closehint != null)
        {
            closehint.gameObject.SetActive(false);
            closehint.onClick.AddListener(CloseBtn);
        }
        if (hintBg != null)
        {
            hintBg.gameObject.SetActive(false);
        }
        CreateApple();
        LoseApple();
        GetHinttxt();
    }
    


    public void HintBtn()
    { 
        hint.gameObject.SetActive(false);
        closehint.gameObject.SetActive(true);
        hintBg.gameObject.SetActive(true);
        hintBg.sprite = Resources.Load<Sprite>("Image/UIProfile/Hint");
    }

    public void CloseBtn()
    {
        hint.gameObject.SetActive(true);
        closehint.gameObject.SetActive(false);
        hintBg.gameObject.SetActive(false);
    }

    void CreateApple()
    {
        for (int i = 0; i < apple.Length; i++)
        {
            apple[i] = GetComponentsInChildren<Image>()[i];
            apple[i].sprite = Resources.Load<Sprite>($"Image/UIProfile/Apple");
            Debug.Log($"{i + 1}번째사과 생성");


        }
    }
    void LoseApple()
    {
        for (int i = 0; i < apple.Length; i++)
        {
            if (i < gameManager.curScore)
            {
                apple[i].gameObject.SetActive(true);
            }
            else
            {
                apple[i].sprite = Resources.Load<Sprite>($"Image/UIProfile/LApple");
                Debug.Log($"목숨 -1");
            }
        }
    }
    public void GetHinttxt()
    {
        sM = ScenesManager.GetInstance();

        int i = sM.currentGame;
            hinttxt.text = hinttxtList[i-1];
        
    }
}
