using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject SBlockPrefab;

    public List<PieceScript> SBlockArray = new List<PiececScript>;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate S Block 
        for(i = 0; i<100; i++) {
            GameObject newObject = Instantiate(SBlockPrefab);
            SBlockArray.Add(newObject);
        }
        
        // Do for all pieces

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetkeyDown("space")) {
            SpawnPiece();
        }   
    }
    

    void SpawnPiece() {
        // Select Random Piece to spawn
        int pieceNumber = Math.Floor(Random.Range(0, 6));

        switch(pieceNumber) {
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
