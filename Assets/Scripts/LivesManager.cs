using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource hit;

    private void OnCollisionEnter2D(Collision2D collision) //Hits the ground
    {
        hit.Play();
        gameManager.addLostApple();      
    }
}
