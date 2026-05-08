using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreDisplay;
    private int totalScore = 0;

    public AudioSource audioSource; 
    public AudioClip mergeClip;    

    void Awake() 
    { 
        if (instance == null) instance = this; 
    }

    public void IncreaseScore(int amount)
    {
        totalScore += amount;
        if (scoreDisplay != null) 
        {
            scoreDisplay.text = totalScore.ToString();
        }
        if (audioSource != null && mergeClip != null)
        {
            audioSource.PlayOneShot(mergeClip);
        }
    }

    public int GetCurrentScore()
    {
        return totalScore; 
    }
}