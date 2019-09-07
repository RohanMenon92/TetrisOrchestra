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

    float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = transform.GetComponent<Rigidbody2D>();
        collider2D = transform.GetComponent<Collider2D>();

        rigidBody2D.bodyType = RigidbodyType2D.Kinematic;
        collider2D.enabled = false;
        
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawned && !isPlaced) {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(isPlaced) {
            return;
        }

        // Check if the collision object is a piece script
        if(other.transform.GetComponent<PieceScript>() != null || other.transform.GetComponent<GroundScript>() != null) {
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
        rigidBody2D.bodyType = RigidbodyType2D.Dynamic;

        gameManager.PiecePlaced(this);
    }

    public void OnSpawn() {
        isSpawned = true;
        collider2D.enabled = true;

        rigidBody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    public void OnDespawn() {
        // Add it back to gameManager Pool
    }
}