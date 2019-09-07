using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Collider2D collider2D;
    private GameManager gameManager;

    public int BlockIdentifier;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = transform.GetComponent<Rigidbody2D>();
        collider2D = transform.GetComponent<Collider2D>();
        
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSpawn() {

    }

    void OnDespawn() {
        // Add it back to gameManager Pool
    }
}