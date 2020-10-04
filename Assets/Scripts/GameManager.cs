using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int lostApples;
    public GameObject[] lives;
    int prevLostApples = -1;
    public float timeRemaining = 60;
    public Text Seconds;
    public Basket Player;

    //Canvas
    public GameObject ingameCanvas;
    public GameObject startCanvas;
    public GameObject gameoverCanvas;
    public TextMeshProUGUI finalMessage;

    //AudioSources
    public AudioSource backgroundSound;
    public AudioSource gameOverSound;
    public AudioSource winSound;

    // Start is called before the first frame update
    void Start()
    {
        lostApples = 0;
        Time.timeScale = 0;
        ingameCanvas.SetActive(false);
        startCanvas.SetActive(true);
        gameoverCanvas.SetActive(false);
        //finalMessage = FindObjectOfType<TextMeshProUGUI>();
        backgroundSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 1)
        {
            timeRemaining -= Time.deltaTime;
            Seconds.text = timeRemaining > 10? "00:" + Mathf.FloorToInt(timeRemaining).ToString() : "00:0" + Mathf.FloorToInt(timeRemaining).ToString();
        }
        else
        {
            Seconds.text = "00:00";
            finishGame(); //player won
        }

        if (prevLostApples != lostApples) {
            if (lostApples >= 3) 
            {
                //gameOver
                lives[2].GetComponent<Animator>().SetTrigger("Lost");
                gameOver();
            } 
            else if (lostApples == 2) 
            {
                lives[1].GetComponent<Animator>().SetTrigger("Lost");
            } 
            else if (lostApples == 1) 
            {
                lives[0].GetComponent<Animator>().SetTrigger("Lost");
            }
        }
    }

    public void startGame()
    {
        Time.timeScale = 1;
        Player.setRunning(true);
        ingameCanvas.SetActive(true);
        startCanvas.SetActive(false);
        gameoverCanvas.SetActive(false);
    }

    public void gameOver()
    {
        backgroundSound.Stop();
        gameOverSound.PlayOneShot(gameOverSound.clip);
        Player.setRunning(false);
        StartCoroutine(wait());
        ingameCanvas.SetActive(false);
        gameoverCanvas.SetActive(true);
    }

    public void finishGame()
    {
        backgroundSound.Stop();
        winSound.PlayOneShot(winSound.clip);
        Player.setRunning(false);
        Time.timeScale = 0;
        finalMessage.SetText("You won");
        gameoverCanvas.SetActive(true);
    }

    IEnumerator wait(){ //waits for the animation to finish
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }

    public void addLostApple()
    {
        this.lostApples++;
    }
}
