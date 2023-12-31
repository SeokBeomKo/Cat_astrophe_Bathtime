using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public GameObject fog;

    private float closeAngle = -100;
    private float openAngle = 0;
    
    private bool isDoorClose = false;
    private bool isDoorOpen = false;

    public delegate void DoorHandle();
    public event DoorHandle OnCloseDoor;
    public event DoorHandle OnOpenDoor;

    public IEnumerator CloseDoor()
    {
        SoundManager.Instance.PlaySFX("Door");
        while (!isDoorClose)
        {
            closeAngle++;

            if (closeAngle > 0)
            {
                isDoorClose = true;
                Invoke("SuccessCloseDoor", 4f);
            }
            else
            {
                door.transform.rotation = Quaternion.Euler(0, closeAngle, 0);
            }

            yield return new WaitForSeconds(0.02f);
        }
    }

    public IEnumerator OpenDoor()
    {
        SoundManager.Instance.PlaySFX("Door");
        while (!isDoorOpen)
        {
            openAngle--;

            if (openAngle < -100)
            {
                isDoorOpen = true;
                Invoke("SuccessOpendDoor", 3.5f);
            }
            else
            {
                door.transform.rotation = Quaternion.Euler(0, openAngle, 0);
                fog.SetActive(false);
            }

            yield return new WaitForSeconds(0.02f);
        }
    }


    public void SuccessCloseDoor()
    {
        OnCloseDoor?.Invoke();
    }

    public void SuccessOpendDoor()
    {
        OnOpenDoor?.Invoke();
    }
}

