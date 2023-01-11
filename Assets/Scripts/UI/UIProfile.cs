using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UIProfile : MonoBehaviour
{
    GameManager gameManager;

    public Image [] apple = new Image[5];
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();

        CreateApple();
        LoseApple();


    }
    void CreateApple()
    {
        for (int i = 0; i < apple.Length; i++)
        {
            apple[i] = GetComponentsInChildren<Image>()[i];
            apple[i].sprite = Resources.Load<Sprite>($"Image/Apple");
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
                apple[i].sprite = Resources.Load<Sprite>($"Image/LApple");
            }
        }
    }
}
