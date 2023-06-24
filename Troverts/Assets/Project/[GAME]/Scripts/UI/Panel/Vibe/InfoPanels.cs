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
    }
    void OnDisable()
    {
        EventManager.OnNpcGetSmart.RemoveListener(InitializeEntryInfo); 
        EventManager.OnIntrovertFirstBoxCall.RemoveListener(InitializeMainPwrInfo);
        EventManager.OnIntrovertSecondBoxCall.RemoveListener(InitializeSecondPwrInfo);  
    }

    private void InitializeEntryInfo() 
    {
        StartCoroutine(DisplayEntryInfo(EntryInfo));
    }
    private void InitializeMainPwrInfo() 
    {
        StartCoroutine(DisplayEntryInfo(MainPwrInfo));
    }
    private void InitializeSecondPwrInfo() 
    {
        StartCoroutine(DisplayEntryInfo(SecondPwrInfo));
    }

    IEnumerator DisplayEntryInfo(GameObject infoObject)
    {
        EventManager.OnUIHide.Invoke();
        infoObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        infoObject.SetActive(false);
        EventManager.OnUIShow.Invoke();
    }
}
