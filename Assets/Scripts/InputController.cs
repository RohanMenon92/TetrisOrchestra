using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputController : MonoBehaviour
{
    public SpriteRenderer bgRenderer;

    private GameManager gameManager;

    int currentButtonPress;
    Vector3 currentButtonPosition;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame

    public void OnDown(int buttonNumber, Vector3 touchPosition) {
        currentButtonPress = buttonNumber;
        currentButtonPosition = touchPosition;

        if (currentButtonPress != -1)
        {
            return;
        }


        switch (buttonNumber) {
            case 0:
                // Controls Speed Downwards
                Debug.Log("OnDown 0" + gameManager.currentPiece);
            break;
            case 1:
                // Controls Left and Right
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
        currentButtonPress = -1;
        currentButtonPosition = new Vector3(0f, 0f, 0f);

        gameManager.currentPiece.changeValueX = 0f;
        gameManager.currentPiece.changeValueY = 0f;
    }
    public void OnDrag(int buttonNumber) {
        if (currentButtonPress == -1) {
            return;
        }

        float changeValue = 0f;

        switch (currentButtonPress)
        {
            case 0:
                float touchDifferenceY = currentButtonPosition.y - Input.mousePosition.y;
                Debug.Log("Touch Difference Y " + touchDifferenceY);
                if (touchDifferenceY > 0)
                {
                    if(Mathf.Abs(touchDifferenceY) < 100f)
                    {
                        changeValue = - 0.025f;
                    } else {
                        changeValue = - 0.045f;
                    }
                } else {
                    if (Mathf.Abs(touchDifferenceY) < 100f)
                    {
                        changeValue = 0.015f;
                    }
                    else
                    {
                        changeValue = 0.035f;
                    }
                }

                gameManager.currentPiece.changeValueY = changeValue;
                Debug.Log("OnDrag 0");
                break;
            case 1:
                float touchDifferenceX = currentButtonPosition.x - Input.mousePosition.x;
                changeValue = touchDifferenceX * -0.0005f;

                gameManager.currentPiece.changeValueX = changeValue;
                Debug.Log("OnDrag 1");
                break;
            case 2:
                Debug.Log("OnDrag 2");
                break;
            case 3:
                Debug.Log("OnDrag 3");
                break;
        }
    }
}
