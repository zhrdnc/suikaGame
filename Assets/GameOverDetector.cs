using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameOverDetector : MonoBehaviour
{
    public float delayBeforeCountdown = 2.0f; 
    public float timeLimit = 3.0f; 
    private float timer = 0f;
    private List<GameObject> fruitsInTrigger = new List<GameObject>(); 
    
    public TextMeshProUGUI countdownText; 
    public GameObject gameOverPanel; 
    public TextMeshProUGUI finalScoreText; 
    public GameObject box; 

    void Start()
    {
        Time.timeScale = 1f; 
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (countdownText != null) countdownText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (fruitsInTrigger.Count > 0)
        {
            timer += Time.deltaTime;
            if (timer > delayBeforeCountdown)
            {
                if (countdownText != null)
                {
                    countdownText.gameObject.SetActive(true);
                    float remainingTime = timeLimit - (timer - delayBeforeCountdown);
                    countdownText.text = Mathf.Ceil(remainingTime).ToString();
                }
            }
            if (timer >= (delayBeforeCountdown + timeLimit))
            {
                GameOver();
            }
        }
        else
        {
            timer = 0f;
            if (countdownText != null) countdownText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            fruitcon fruit = collision.GetComponent<fruitcon>();
            if (fruit != null && fruit.isDropped && !fruitsInTrigger.Contains(collision.gameObject))
            {
                fruitsInTrigger.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (fruitsInTrigger.Contains(collision.gameObject))
        {
            fruitsInTrigger.Remove(collision.gameObject);
        }
    }

    void GameOver()
    {
        if (MusicManager.instance != null)
        {
            AudioSource music = MusicManager.instance.GetComponent<AudioSource>();
            if (music != null) music.Stop();
        }

        // Geri sayım yazısını panel açılmadan hemen önce kapatıyoruz
        if (countdownText != null) countdownText.gameObject.SetActive(false);

        Time.timeScale = 0f; 
        if (box != null) box.SetActive(false);

        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");
        foreach (GameObject fruit in fruits)
        {
            fruit.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (finalScoreText != null && ScoreManager.instance != null)
            {
                finalScoreText.text = ScoreManager.instance.GetCurrentScore().ToString();
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    } 
}