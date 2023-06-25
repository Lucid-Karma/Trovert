using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanels : MonoBehaviour
{
    public GameObject EntryInfo;
    public GameObject MainPwrInfo;
    public GameObject SecondPwrInfo;

    public GameObject LeftClickInfo;
    public GameObject LeftShiftInfo;

    void Awake()
    {
        EntryInfo.SetActive(false);
        MainPwrInfo.SetActive(false);
        SecondPwrInfo.SetActive(false);
        LeftClickInfo.SetActive(false);
        LeftShiftInfo.SetActive(false);
    }

    void OnEnable()
    {
        EventManager.OnNpcGetSmart.AddListener(InitializeEntryInfo);
        EventManager.OnIntrovertFirstBoxCall.AddListener(InitializeMainPwrInfo);
        EventManager.OnIntrovertSecondBoxCall.AddListener(InitializeSecondPwrInfo);
        EventManager.OnNpcGreet.AddListener(InitializeLeftClickInfo);
        EventManager.OnNpcGreetingEnd.AddListener(HideLeftClickInfo);
        EventManager.OnLevelAfterStart.AddListener(() => StartCoroutine(DisplayLeftShiftInfo()));
    }
    void OnDisable()
    {
        EventManager.OnNpcGetSmart.RemoveListener(InitializeEntryInfo); 
        EventManager.OnIntrovertFirstBoxCall.RemoveListener(InitializeMainPwrInfo);
        EventManager.OnIntrovertSecondBoxCall.RemoveListener(InitializeSecondPwrInfo);  
        EventManager.OnNpcGreet.RemoveListener(InitializeLeftClickInfo);
        EventManager.OnNpcGreetingEnd.RemoveListener(HideLeftClickInfo);
        EventManager.OnLevelAfterStart.RemoveListener(() => StartCoroutine(DisplayLeftShiftInfo()));
    }

    private void InitializeEntryInfo() 
    {
        StartCoroutine(DisplayInfo(EntryInfo));
    }
    private void InitializeMainPwrInfo() 
    {
        StartCoroutine(DisplayInfo(MainPwrInfo));
    }
    private void InitializeSecondPwrInfo() 
    {
        StartCoroutine(DisplayInfo(SecondPwrInfo));
    }

    private void InitializeLeftClickInfo() 
    {
        LeftShiftInfo.SetActive(false);
        LeftClickInfo.SetActive(true);
    }
    private void HideLeftClickInfo() 
    {
        LeftClickInfo.SetActive(false);
    }

    IEnumerator DisplayInfo(GameObject infoObject)
    {
        EventManager.OnUIHide.Invoke();
        infoObject.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        infoObject.SetActive(false);
        EventManager.OnUIShow.Invoke();
    }
    IEnumerator DisplayLeftShiftInfo()
    {
        yield return new WaitForSeconds(5.0f);

        LeftShiftInfo.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        LeftShiftInfo.SetActive(false);
    }
}
