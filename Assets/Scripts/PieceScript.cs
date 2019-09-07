using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Collider2D collider2D;
    private GameManager gameManager;

    public bool isSpawned = false;
    public bool isPlaced = false;
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
        if(isPlaced) {
            return;
        }
        // Check if the collision object is a piece script
        if(other.transform.GetComponent<PieceScript>() != null) {
            OnPlacement();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(isPlaced) {
            return;
        }
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(isPlaced) {
            return;
        }
        
    }

    public void OnPlacement() {
        isPlaced = true;
        rigidBody2D.isKinematic = false;

        gameManager.PiecePlaced(this);
    }

    public void OnSpawn() {
        isSpawned = true;

        rigidBody2D.isKinematic = true;
    }

    public void OnDespawn() {
        // Add it back to gameManager Pool
    }
}