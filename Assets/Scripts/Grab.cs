using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    public Text Score;
    private int scoreValue = 0;
    // Start is called before the first frame update
    [Tooltip("Points to win")]
    [SerializeField] public int MaxScore = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score != null) { 
            Score.text = "Score: " + scoreValue.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Hits a pipe
    {
        Destroy(collision.gameObject);
        scoreValue++;
        
    }
}
