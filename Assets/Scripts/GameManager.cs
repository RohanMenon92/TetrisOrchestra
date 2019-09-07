using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject SBlockPrefab;
    public GameObject ReverseSBlockPrefab;
    public GameObject ReverseJBlockPrefab;
    public GameObject LBlockPrefab;
    public GameObject SquareBlockPrefab;
    public GameObject TBlockPrefab;

    public Transform SpawnLocation;
    
    public List<PieceScript> SBlockArray = new List<PieceScript>();
    public List<PieceScript> ReverseSBlockArray = new List<PieceScript>();
    public List<PieceScript> ReverseJBlockArray = new List<PieceScript>();
    public List<PieceScript> LBlockArray = new List<PieceScript>();
    public List<PieceScript> SquareBlockArray = new List<PieceScript>();
    public List<PieceScript> TBlockArray = new List<PieceScript>();

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate S Block 
        for(int i = 0; i<50; i++) {

            GameObject newObject = Instantiate(SBlockPrefab);

            SBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(ReverseSBlockPrefab);
            ReverseSBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(ReverseJBlockPrefab);
            ReverseJBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(LBlockPrefab);
            LBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(SquareBlockPrefab);
            SquareBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(TBlockPrefab);
            TBlockArray.Add(newObject.GetComponent<PieceScript>());
            

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

        PieceScript pieceTospawn = null;

        switch ((int)pieceNumber) {
            case 0:
               foreach(PieceScript sBlock in SBlockArray)
                {
                    if (!sBlock.isSpawned)
                    {
                        pieceTospawn = sBlock;
                        break;
                    }
                }
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
