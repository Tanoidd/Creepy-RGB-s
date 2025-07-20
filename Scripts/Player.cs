using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    //public static event OnPlayerDeath;
    public float playerSpeed;
    public float turnSpeed;
    //private Rigidbody2D rb;
    ///private Vector2 playerDirection;

    public int score;
    public TMP_Text yourScore;
    public int health;
    public TMP_Text scoreDisplay;
    public TMP_Text healthDisplay; 
     AudioManager audioManager;
    AudioSource musicSource;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
    }
    void Start()
    {

        Time.timeScale = 1;
        gameOver = false;
        PlayerPrefs.SetString("CurrentScore:", "1");

        // Hide Game Over panel at start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);

            CanvasGroup canvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
             transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        } 
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.up * playerSpeed * Time.deltaTime);
        }

       /* float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;*/
    }
    private void FixedUpdate()
    {
       // rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }
    public void AddScore()
    {
        score++;
        scoreDisplay.text = "Score: " + score;
        audioManager.PlaySFX(audioManager.scorePlusEnemyCollison);
    }
    public void DeleteScore()
    {
        score--;
        scoreDisplay.text = "Score: " + score;
    }
    public void TakeDamage()
    {
        health--;
        healthDisplay.text = "Health: " + health;
        audioManager.PlaySFX(audioManager.scoreMinusEnemyCollison);

        if (health <= 0)
        {
            PlayerPrefs.SetString("CurrentScore:", scoreDisplay.text);

            
            gameOverPanel.SetActive(true);

            // Show and enable interaction via CanvasGroup
            CanvasGroup canvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
            yourScore.text = "Your Score: " + score.ToString();

            Time.timeScale = 0;
            audioManager.PlaySFX(audioManager.losing);
            musicSource.Stop();
        }
    }
    public void TakeHeal()
    {
        if (health < 10)
        {
            audioManager.PlaySFX(audioManager.healerCollison);
            health++;
            healthDisplay.text = "Heath: " + health;
        }
      
    }
    

}
