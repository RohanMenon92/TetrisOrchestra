using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject SBlockPrefab;

    public List<GameObject> SBlockArray = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate S Block 
        for(int i = 0; i<100; i++) {
            GameObject newObject = Instantiate(SBlockPrefab);
            SBlockArray.Add(newObject);
        }
        
        // Do for all pieces

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")) {
            SpawnPiece();
        }   
    }
    

    void SpawnPiece() {
        // Select Random Piece to spawn
        float pieceNumber = Mathf.Floor(Random.Range(0, 6));

        switch((int)pieceNumber) {
            case 0:
            // Spawn Block 1
            break;
            case 1:
            // Spawn Block 2
            break;
            case 2:
            // Spawn Block 3
            break;
            case 3:
            // ...
            break;
            case 4:
            // ...
            break;
            case 5:
            // ...
            break;
        }

        // TODO LATER: Set Material Properties

    }
}