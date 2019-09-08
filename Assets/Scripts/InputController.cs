using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputController : MonoBehaviour
{
    public SpriteRenderer bgRenderer;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;

    private GameManager gameManager;

    int currentButtonPress;
    Vector3 currentButtonPosition;

    Tween rotationTween = null;
    int rotationVal = 1;
    bool stopRotation = false;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame

    public void OnDown(int buttonNumber, Vector3 touchPosition) {
        if (currentButtonPress != -1)
        {
            return;
        }

        currentButtonPress = buttonNumber;
        currentButtonPosition = touchPosition;

        switch (buttonNumber) {
            case 0:
                // Controls Speed Downwards

            break;
            case 1:
                // Controls Left and Right

            break;
            case 2:
                // For Rotation
                stopRotation = false;
                rotationTween = gameManager.currentPiece.transform.DORotate(new Vector3(0f, 0f, rotationVal * 90f), 0.3f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.InOutQuad)
                    .OnComplete(RotationCheck);
            break;
        }
    }

    public void RotationCheck()
    {
        if(stopRotation)
        {
            return;
        }
        rotationTween = gameManager.currentPiece.transform.DORotate(new Vector3(0f, 0f, rotationVal * 90f), 0.3f, RotateMode.LocalAxisAdd)
            .SetEase(Ease.InOutQuad)
            .OnComplete(RotationCheck);

    }

    public void KillRotationTween()
    {
        stopRotation = true;
        rotationTween.Kill(true);
    }

    public void OnUp(int buttonNumber) {
        switch (currentButtonPress) {
            case 0:
                //Debug.Log("OnUp 0");            
            break;
            case 1:
                //Debug.Log("OnUp 1");
            break;
            case 2:
                stopRotation = true;
                rotationTween.OnStepComplete(KillRotationTween);
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
                // For Up and Down Speed
                float touchDifferenceY = currentButtonPosition.y - Input.mousePosition.y;
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
                break;
            case 1:
                // For Side to Side Speed
                float touchDifferenceX = currentButtonPosition.x - Input.mousePosition.x;
                changeValue = touchDifferenceX * -0.0005f;

                gameManager.currentPiece.changeValueX = changeValue;
                break;
            case 2:
                // For roatation
                float touchDifferenceRotation = currentButtonPosition.x - Input.mousePosition.x;
                if (touchDifferenceRotation > 0)
                {
                    rotationVal = 1;
                }
                else
                {
                    rotationVal = -1;
                }

                break;
        }
    }

    void Update()
    {
        //Fade in backgrounds
        if (currentButtonPress == -1)
        {
            if (bgRenderer.color.a > 0.1)
            {
                bgRenderer.color = new Color(bgRenderer.color.r, bgRenderer.color.g, bgRenderer.color.b, bgRenderer.color.a - 0.005f);
            }
        }
        else
        {
            if (bgRenderer.color.a < 0.9)
            {
                bgRenderer.color = new Color(bgRenderer.color.r, bgRenderer.color.g, bgRenderer.color.b, bgRenderer.color.a + 0.005f);
            }
        }
    }
}
