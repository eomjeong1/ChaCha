using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EventManager : MonoBehaviour
{
    #region Singletone
    private static EventManager instance;

    public static EventManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@EventManager");
            instance = go.AddComponent<EventManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public Camera MainCam; 
    public AudioSource GranMaT;
    public AudioSource UncleT;
    public AudioSource PlayerT1;
    /*public AudioSource PlayerT2;*/

    public bool canRotate;

    public UISticker uiSticker;
    // Start is called before the first frame update
    void Start()
    {
       MainCam = GetComponent<Camera>();
       GranMaT = GetComponent<AudioSource>();
        UncleT = GetComponent<AudioSource>();
        PlayerT1 = GetComponent<AudioSource>();

        MainCam = FindObjectOfType<Camera>();

        /*PlayerT2 = GetComponent<AudioSource>();*/
        if (uiSticker.lookGranMa == true)
        {
            TalkGranMa();
        }
        if (uiSticker.lookGranMa == true)
        {
            TalkUncle();
        }

    }

    // Update is called once per frame
    public void TalkGranMa()
    {

        GranMaCoroutine();
        
    }
    IEnumerator GranMaCoroutine()
    {
        canRotate = false;
        GameObject target1 = GameObject.FindWithTag("BadGranMa");
        MainCam.transform.LookAt(target1.transform); // 할머니를 보게 만든다.
        Debug.Log("할머니 본다.");
        GranMaT.Play(); 
        Debug.Log("할머니와 대화"); // 할머니 대사 출력
        float waitTime = 4.0f;
        waitTime = waitTime - Time.deltaTime;
        if (canRotate == false)
        {
            MainCam.transform.LookAt(target1.transform);
        }

        if (waitTime == 0.0f)
        {
            Invoke("PlayerThink", 7); // 7초에 한번씩 "어떻게 할까?" 라는 플레이어 음성이 출력됨.  
            canRotate = true;
            uiSticker.lookGranMa = false;
        }        
        yield return null;
    }
    IEnumerator UncleCoroutine()
    {
        canRotate = false;
        GameObject target2 = GameObject.FindWithTag("BadUncle");
        MainCam.transform.LookAt(target2.transform); // 아저씨를 보게 만든다.
        Debug.Log("아저씨 본다.");

        UncleT.Play();
        Debug.Log("아저씨와 대화"); // 아저씨 대사 출력
        float waitTime = 4.0f;
        waitTime = waitTime - Time.deltaTime;
        if (canRotate == false)
        {
            MainCam.transform.LookAt(target2.transform);
        }

        if (waitTime == 0.0f)
        {
            Invoke("PlayerThink", 7); // 7초에 한번씩 "어떻게 할까?" 라는 플레이어 음성이 출력됨.  
            canRotate = true;
            uiSticker.lookUncle = false; 
        }
        yield return null;
    }

    public void TalkUncle()
    {
        UncleCoroutine();
    }

    public void PlayerThink()
    { 
        PlayerT1.Play();
    }


}
