using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CleanlinessPopUp : MonoBehaviour
{

    public GameObject popUp;

    // �˾� â �ؽ�Ʈ
    public TextMeshProUGUI upperBody;
    public TextMeshProUGUI lowerBody;
    public TextMeshProUGUI rearPawRight;
    public TextMeshProUGUI rearPawLeft;
    public TextMeshProUGUI forePawRight;
    public TextMeshProUGUI forePawLeft;
    public TextMeshProUGUI back;

    void Start()
    {
        popUp.SetActive(false);
    }

    void Update()
    {
        popUp.SetActive(false);

        if (Input.GetKey(KeyCode.Tab))
        {
            popUp.SetActive(true);
        }

    }

    public float a = 1f;

    public void CleanCat(CleanEnums parts,  float cleanliness)
    {
        switch(parts)
        {
            case CleanEnums.UPPERBODY:
                upperBody.text = "��ü : " + cleanliness.ToString("00") + "%";
                break;
            case CleanEnums.LOWERBODY:
                lowerBody.text = "��ü : " + cleanliness.ToString("00") + "%";
                break;
            case CleanEnums.REARPAWRIGHT:
                rearPawRight.text = "�չ� : " + cleanliness.ToString("00") + "%";
                break;
            case CleanEnums.REARPAWLEFT:
                rearPawLeft.text = "�չ� : " + cleanliness.ToString("00") + "%";
                break;
            case CleanEnums.FOREPAWRIGHT:
                forePawRight.text = "�޹� : " + cleanliness.ToString("00") + "%";
                break;
            case CleanEnums.FOREPAWLEFT:
                forePawLeft.text = "�޹� : " + cleanliness.ToString("00") + "%";
                break;
            case CleanEnums.BACK:
                back.text = "�� : " + cleanliness.ToString("00") + "%";
                break;
                
        }
    }
}