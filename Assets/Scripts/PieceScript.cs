using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Collider2D collider2D;
    private GameManager gameManager;

    public bool isSpawned = false;

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

    private void OnCollisionEnter2D(Collision2D other) {
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        
    } 

    public void OnSpawn() {
        isSpawned = true;
    }

    public void OnDespawn() {
        // Add it back to gameManager Pool
    }
}