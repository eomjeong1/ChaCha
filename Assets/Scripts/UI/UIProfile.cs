using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UIProfile : MonoBehaviour
{
    GameManager gameManager;

    public Image[] img;
    // Start is called before the first frame update
    void Start()
    {
        ReverseTrAng();          
                  
    }
    void ReverseTrAng()
    {
        for (int i = 0; i < img.Length; i++)
        {
            img[i] = GetComponentsInChildren<Image>()[i];
            img[i].sprite = Resources.Load<Sprite>($"Image/Apple");
            Debug.Log($"{i + 1}번째사과 생성");

            if (img.Length < gameManager.curScore +1)
            {
                for (int x = 0; x <= 5 - i; x++)
                {
                    img[x].gameObject.SetActive(false);
                    Debug.Log("사과잃음");
                }
            }
            
        }
    }

}
