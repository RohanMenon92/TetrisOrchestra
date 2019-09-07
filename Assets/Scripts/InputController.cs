using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputController : MonoBehaviour
{
    public SpriteRenderer bgRenderer;

    private GameManager gameManager;

    int currentButtonPress;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame

    public void OnDown(int buttonNumber) {
        currentButtonPress = buttonNumber;

        switch (buttonNumber) {
            case 0:
                Debug.Log("OnDown 0" + gameManager.currentPiece);
            break;
            case 1:
                Debug.Log("OnDown 1");
            break;
            case 2:
                Debug.Log("OnDown 2");            
            break;
            case 3:
                Debug.Log("OnDown 3");
            break;
        }
    }
    public void OnUp(int buttonNumber) {
        switch (currentButtonPress) {
            case 0:
                Debug.Log("OnUp 0");            
            break;
            case 1:
                Debug.Log("OnUp 1");
            break;
            case 2:
                Debug.Log("OnUp 2");            
            break;
            case 3:
                Debug.Log("OnUp 3");            
            break;
        }
    }
    public void OnDrag(int buttonNumber) {
        // switch (currentButtonPress) {
        //     case 0:
        //         Debug.Log("OnDrag 0");
        //     break;
        //     case 1:
        //         Debug.Log("OnDrag 1");
        //     break;
        //     case 2:
        //         Debug.Log("OnDrag 2");
        //     break;
        //     case 3:
        //         Debug.Log("OnDrag 3");
        //     break;
        // }
    }
}
