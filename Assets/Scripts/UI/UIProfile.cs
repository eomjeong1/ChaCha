using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UIProfile : MonoBehaviour
{
    GameManager gameManager;
    public Button hint;
    public Button guide;
    public Image hintBg;
    public Button closehint;

    public Image [] apple = new Image[5];
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();

        CreateApple();
        LoseApple();

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
    }

    public void HintBtn()
    { 
        hint.gameObject.SetActive(false);
        closehint.gameObject.SetActive(true);
        hintBg.gameObject.SetActive(true);
        hintBg.sprite = Resources.Load<Sprite>("Image/Apple");
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
            apple[i].sprite = Resources.Load<Sprite>($"Image/Apple");
            Debug.Log($"{i + 1}锅掳荤苞 积己");


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
                apple[i].sprite = Resources.Load<Sprite>($"Image/LApple");
                Debug.Log($"格见 -1");
            }
        }
    }
}
