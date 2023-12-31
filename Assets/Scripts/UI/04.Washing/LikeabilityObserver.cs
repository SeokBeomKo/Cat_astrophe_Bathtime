using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LikeabilityObserver : MonoBehaviour, IObserver
{
    public Slider likeabilityProgressBar;
    public TextMeshProUGUI likeabilityText;

    private float currentLikeability;

    public void Notify(ISubject subject)
    {
        UpdateLikeabilityProgress(subject as CatStatsSubject);
    }

    public void UpdateLikeabilityProgress(CatStatsSubject catStats)
    {
        currentLikeability = catStats.currentLikeability;
        likeabilityProgressBar.value = Mathf.Clamp01(currentLikeability / catStats.currentMaxLikeability);
        
        likeabilityText.text = Mathf.Floor((likeabilityProgressBar.value * 100)).ToString() + "%";
    }
}
