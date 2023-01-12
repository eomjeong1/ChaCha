using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class EventManager : MonoBehaviour
{


    public Camera MainCam;
    public Transform grandMa;
    public Transform uncle;
    public AudioSource GranMaT;
    public AudioSource UncleT;
    public AudioSource PlayerT1;
    /*public AudioSource PlayerT2;*/

    public bool canRotate;
    public UISticker uiSticker;
    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {       
        MainCam = GetComponent<Camera>();
        GranMaT = GetComponent<AudioSource>();
        UncleT = GetComponent<AudioSource>();
        PlayerT1 = GetComponent<AudioSource>();
        uiSticker = GetComponent<UISticker>();

        MainCam = FindObjectOfType<Camera>();

        if (ScenesManager.GetInstance().currentGame == 3)
        {
            MainCam = FindObjectOfType<Camera>();
            grandMa = GameObject.FindWithTag("BadGranMa").transform;
            Debug.Log("�ҸӴ� ��ġ�� ã�ҽ��ϴ�.");

            GranMaT.clip = Resources.Load<AudioClip>("Sound/����Ŭ����5");
            Debug.Log($"{GranMaT.clip}�� ã�ҽ��ϴ�.");

        }
        if (ScenesManager.GetInstance().currentGame == 5)
        {
            MainCam = FindObjectOfType<Camera>();
            uncle = GameObject.FindWithTag("BadUncle").transform;
            Debug.Log("������ ��ġ�� ã�ҽ��ϴ�.");
            UncleT.clip = Resources.Load<AudioClip>("Sound/����Ŭ����5");
            Debug.Log($"{UncleT.clip}�� ã�ҽ��ϴ�.");

        }

        /*PlayerT2 = GetComponent<AudioSource>();*/
        

    }
    public void Update()
    {
        if (uiSticker.lookGranMa == true)
        {
            TalkGranMa();
        }
        if (uiSticker.lookUncle == true)
        {
            TalkUncle();
        }


    }

    // Update is called once per frame
    public void TalkGranMa()
    {

        DonotMoveCoroutine();
        
    }
    IEnumerator DonotMoveCoroutine()
    {
        canRotate = false;
        /*MainCam.transform.LookAt(grandMa.transform);*/
        
        GranMaT.Play();

        
        Debug.Log("�ҸӴϸ� ���� �����.");// �ҸӴϸ� ���� �����.
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            if (!GranMaT.isPlaying)
            {
                canRotate = true;
                Invoke("PlayerThink", 7); // 7�ʿ� �ѹ��� "��� �ұ�?" ��� �÷��̾� ������ ��µ�.  
                uiSticker.lookGranMa = false;
            }
        }
    }
    IEnumerator UncleCoroutine()
    {
        canRotate = false;
        GameObject target2 = GameObject.FindWithTag("BadUncle");
        /*MainCam.transform.LookAt(target2.transform);*/ // �������� ���� �����.
        Debug.Log("������ ����.");

        UncleT.Play();
        Debug.Log("�������� ��ȭ"); // ������ ��� ���
        float waitTime = 4.0f;
        waitTime = waitTime - Time.deltaTime;
        if (canRotate == false)
        {
            /*MainCam.transform.LookAt(target2.transform);*/
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
    public void CameraTurn(Vector3 targetPos)
    {
        Vector3 dir = targetPos - grandMa.position;
        Vector3 dirX = new Vector3(dir.x, 0f, 0f);
        Quaternion targetRot = Quaternion.LookRotation(dirX);

        MainCam.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 550.0f * Time.deltaTime);
        this.transform.forward = -dirX;

    }
}
