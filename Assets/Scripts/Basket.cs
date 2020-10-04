using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    //Moves the player alongside the y axis

    //movement velocity
    [Tooltip("Velocity in Unity units")]
    [SerializeField] private float velocity = 0.01f; //visible to editor

    [Header("Controles para el game pad")]
    [SerializeField] private KeyCode leftControl;
    [SerializeField] private KeyCode rightControl;

    private Rigidbody2D _rigidbody2D;
    private float xOff;
    private float padLimit = 5.0f;
    private bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        xOff = gameObject.GetComponent<SpriteRenderer>().size.x / 2;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //read control and apply movement
        if(running)
        {
            if(Input.GetKey(leftControl))
            {
                transform.Translate(-velocity,0f, 0f);
            }
            else if(Input.GetKey(rightControl))
            {
                transform.Translate(velocity,0f,0f);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -padLimit, padLimit), transform.position.y, transform.position.z);
        }
        
    }

    public void setRunning(bool state)
    {
        running = state;
    }
}