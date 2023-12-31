using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public string[] ItemNames =
    {
        "운동에너지",
        "보호막",
        "츄르",
        "털뭉치",
        "탄약",
        "생명에너지"
    };

    public delegate void RandomItemHandle(string itemName);
    public event RandomItemHandle OnRandomItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ItemNames != null && ItemNames.Length > 0)
            {
                SoundManager.Instance.PlaySFX("GetItem");

                string itemName = GetRandomName();

                if (itemName == "WaterBottle")
                {
                    OnRandomItem?.Invoke("WaterBottle");
                }
                else if (itemName == "생명에너지")
                {
                    OnRandomItem?.Invoke("생명에너지");
                }
                else
                {
                    InventoryManager.Instance.AddItemToInventory(itemName);
                    OnRandomItem?.Invoke(itemName);
                }
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("No names provided. Please assign an array of names to the script.");
            }
        }
    }

    string GetRandomName()
    {
        int randomIndex = UnityEngine.Random.Range(0, ItemNames.Length);
        return ItemNames[randomIndex];
    }
}
