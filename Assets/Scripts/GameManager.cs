using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject SBlockPrefab;
    public GameObject ReverseSBlockPrefab;
    public GameObject ReverseJBlockPrefab;
    public GameObject LBlockPrefab;
    public GameObject SquareBlockPrefab;
    public GameObject TBlockPrefab;

    public GameObject EndCredits;

    public Transform SpawnLocation;

    public GameObject buttonHolder;
    public GameObject realGround;
    
    List<PieceScript> SBlockArray = new List<PieceScript>();
    List<PieceScript> ReverseSBlockArray = new List<PieceScript>();
    List<PieceScript> ReverseJBlockArray = new List<PieceScript>();
    List<PieceScript> LBlockArray = new List<PieceScript>();
    List<PieceScript> SquareBlockArray = new List<PieceScript>();
    List<PieceScript> TBlockArray = new List<PieceScript>();

    public InputController inputController;

    public PieceScript currentPiece;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LivesText;
    public int Score = 0;
    public int Lives = 3;
    // Start is called before the first frame update
    void Start()
    {

        GameObject newObject = null;
        // Instantiate S Block 
        for(int i = 0; i<200; i++) {
            newObject = Instantiate(SBlockPrefab);
            newObject.transform.position = new Vector3(1000F, 1000f, 0f);
            SBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(ReverseSBlockPrefab);
            newObject.transform.position = new Vector3(1000F, 1000f, 0f);
            ReverseSBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(ReverseJBlockPrefab);
            newObject.transform.position = new Vector3(1000F, 1000f, 0f);
            ReverseJBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(LBlockPrefab);
            newObject.transform.position = new Vector3(1000F, 1000f, 0f);
            LBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(SquareBlockPrefab);
            newObject.transform.position = new Vector3(1000F, 1000f, 0f);
            SquareBlockArray.Add(newObject.GetComponent<PieceScript>());

            newObject = Instantiate(TBlockPrefab);
            newObject.transform.position = new Vector3(1000F, 1000f, 0f);
            TBlockArray.Add(newObject.GetComponent<PieceScript>());
        }

        inputController = FindObjectOfType<InputController>();
        // Do for all pieces


        BeginTheGame();
    }

    void BeginTheGame()
    {
        realGround.transform.DOMove(new Vector3(0f, -4f, 0f), 0.25f);
        buttonHolder.transform.DOMove(new Vector3(0f, 0.5f, 3f), 0.5f).OnComplete(() =>
        {
            SpawnPiece();
        });
    }

    // Update is called once per frame
    void Update() {
    }
    
    public void PiecePlaced(PieceScript piece) {
        inputController.KillRotationTween();
        int scoreIncrement = 0;
        if(currentPiece != null)
        {
            if (currentPiece.transform.position.y < 0)
            {
                scoreIncrement = 1;
            }
            else
            {
                scoreIncrement = (int)Mathf.Floor(currentPiece.transform.position.y);
            }

        }

        Score += scoreIncrement;
        ScoreText.text = "Score : " + Score;
        currentPiece = null;
        SpawnPiece();
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
                foreach(PieceScript reversesBlock in ReverseSBlockArray)
                {
                    if(!reversesBlock.isSpawned)
                    {
                        pieceTospawn = reversesBlock;
                        break;
                    }
                }
            // Spawn Block 2
            break;
            case 2:
                foreach(PieceScript lblock in LBlockArray)
                {
                    if(!lblock.isSpawned)
                    {
                        pieceTospawn = lblock;
                        break;
                    }
                }
            // Spawn Block 3
            break;
            case 3:
                foreach(PieceScript squareBlock in SquareBlockArray)
                {
                    if(!squareBlock.isSpawned)
                    {
                        pieceTospawn = squareBlock;
                        break;
                    }

                }
            // ...
            break;
            case 4:
                foreach(PieceScript tBlock in TBlockArray)
                {
                    if(!tBlock.isSpawned)
                    {
                        pieceTospawn = tBlock;
                        break;
                    }
                }
            // ...
            break;
            case 5:
                foreach(PieceScript reverseJblock in ReverseJBlockArray)
                {
                    if(!reverseJblock.isSpawned)
                    {
                        pieceTospawn = reverseJblock;
                        break;
                    }
                }
            // ...
            break;
        }

        pieceTospawn.OnSpawn();

        pieceTospawn.transform.position = SpawnLocation.position;

        currentPiece = pieceTospawn;
    }

    public void DeletePiece(PieceScript piece)
    {
        piece.transform.position = new Vector3(1000F, -1000f, 0f);

        Lives--;
        LivesText.text = "Lives : " + Lives;

        if(Lives == 0)
        {
            if(PlayerPrefs.GetInt("HighScore") < Score)
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
            EndCredits.SetActive(true);
        } else {
            currentPiece = null;

            if(!piece.isPlaced)
            {
                SpawnPiece();
            }
        }
    }
}
