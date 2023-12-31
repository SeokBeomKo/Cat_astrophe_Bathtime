using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CleanlinessPopUpObserver : MonoBehaviour, IObserver
{
    // �˾� â
    [Header("��ô�� �˾�â")]
    public GameObject popUp;

    public UIController uiController;

    // �˾� â �ؽ�Ʈ
    [Header("��ü")]
    public TextMeshProUGUI upperBody;
    [Header("��ü")]
    public TextMeshProUGUI lowerBody;
    [Header("�չ�")]
    public TextMeshProUGUI forePawRight;
    public TextMeshProUGUI forePawLeft;
    [Header("�޹�")]
    public TextMeshProUGUI rearPawRight;
    public TextMeshProUGUI rearPawLeft;
    [Header("��")]
    public TextMeshProUGUI back;

    public void Notify(ISubject subject)
    {
        CleanCat(subject as CatStatsSubject);
    }

    void Start()
    {
        popUp.SetActive(false);
    }

    public void ActivateCleanliness()
    {
        if (PlayerPrefs.GetInt("Pause") == 1) return;

        SoundManager.Instance.PlaySFX("Hover");
        popUp.SetActive(true);
        uiController.RemoveUI();
    }

    public void DeactivateCleanliness()
    {
        if (PlayerPrefs.GetInt("Pause") == 1) return;

        popUp.SetActive(false);  
        uiController.ShowUI();
    }

    public void CleanCat(CatStatsSubject subject)
    {
        upperBody.text = "��ü : " + (subject.GetPartsCleanliness(PartsEnums.UPPERBODY) / subject.GetPartsMaxCleanliness(PartsEnums.UPPERBODY) * 100).ToString("00") + "%";
        lowerBody.text = "��ü : " + (subject.GetPartsCleanliness(PartsEnums.LOWERBODY) / subject.GetPartsMaxCleanliness(PartsEnums.LOWERBODY) * 100).ToString("00") + "%";
        rearPawRight.text = "�޹� : " + (subject.GetPartsCleanliness(PartsEnums.REARPAWRIGHT) / subject.GetPartsMaxCleanliness(PartsEnums.REARPAWRIGHT) * 100).ToString("00") + "%";
        rearPawLeft.text = "�޹� : " + (subject.GetPartsCleanliness(PartsEnums.REARPAWLEFT) / subject.GetPartsMaxCleanliness(PartsEnums.REARPAWLEFT) * 100).ToString("00") + "%";
        forePawRight.text = "�չ� : " + (subject.GetPartsCleanliness(PartsEnums.FOREPAWRIGHT) / subject.GetPartsMaxCleanliness(PartsEnums.FOREPAWRIGHT) * 100).ToString("00") + "%";
        forePawLeft.text = "�չ� : " + (subject.GetPartsCleanliness(PartsEnums.FOREPAWRIGHT) / subject.GetPartsMaxCleanliness(PartsEnums.FOREPAWRIGHT) * 100).ToString("00") + "%";
        back.text = "�� : " + (subject.GetPartsCleanliness(PartsEnums.BACK) / subject.GetPartsMaxCleanliness(PartsEnums.BACK) * 100).ToString("00") + "%";
    }
}
