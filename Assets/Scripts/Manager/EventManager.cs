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
        MainCam.transform.LookAt(target1.transform); // �ҸӴϸ� ���� �����.
        Debug.Log("�ҸӴ� ����.");
        GranMaT.Play(); 
        Debug.Log("�ҸӴϿ� ��ȭ"); // �ҸӴ� ��� ���
        float waitTime = 4.0f;
        waitTime = waitTime - Time.deltaTime;
        if (canRotate == false)
        {
            MainCam.transform.LookAt(target1.transform);
        }

        if (waitTime == 0.0f)
        {
            Invoke("PlayerThink", 7); // 7�ʿ� �ѹ��� "��� �ұ�?" ��� �÷��̾� ������ ��µ�.  
            canRotate = true;
            uiSticker.lookGranMa = false;
        }        
        yield return null;
    }
    IEnumerator UncleCoroutine()
    {
        canRotate = false;
        GameObject target2 = GameObject.FindWithTag("BadUncle");
        MainCam.transform.LookAt(target2.transform); // �������� ���� �����.
        Debug.Log("������ ����.");

        UncleT.Play();
        Debug.Log("�������� ��ȭ"); // ������ ��� ���
        float waitTime = 4.0f;
        waitTime = waitTime - Time.deltaTime;
        if (canRotate == false)
        {
            MainCam.transform.LookAt(target2.transform);
        }

        if (waitTime == 0.0f)
        {
            Invoke("PlayerThink", 7); // 7�ʿ� �ѹ��� "��� �ұ�?" ��� �÷��̾� ������ ��µ�.  
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
