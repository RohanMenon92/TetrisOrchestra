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
                audio1.volume = 0f;
                audio1.Play();
                audio1.DOFade(0.8f, 0.25f);
            break;
            case 1:
                // Controls Left and Right
                audio2.volume = 0f;
                audio2.Play();
                audio2.DOFade(0.8f, 0.25f);

                break;
            case 2:
                // For Rotation
                audio3.volume = 0f;
                audio3.Play();
                audio3.DOFade(0.8f, 0.25f);
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
                audio1.DOFade(0f, 0.25f).OnComplete(() =>
                {
                    audio1.Stop();
                });
                break;
            case 1:
                audio2.DOFade(0f, 0.25f).OnComplete(() =>
                {
                    audio2.Stop();
                });
                break;
            case 2:
                audio3.DOFade(0f, 0.25f).OnComplete(() =>
                {
                    audio3.Stop();
                });
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
                Debug.Log(touchDifferenceY);
                if (touchDifferenceY > 0)
                {
                    if(Mathf.Abs(touchDifferenceY) < 100f)
                    {
                        changeValue = - 0.2f;
                    } else {
                        changeValue = - 0.4f;
                    }
                } else {
                    if (Mathf.Abs(touchDifferenceY) < 100f)
                    {
                        changeValue = 0.4f;
                    }
                    else
                    {
                        changeValue = 1f;
                    }
                }

                // Change every 10 frames and duration of pitch change is 1/6 from that value
                if(Time.frameCount%10 == 0)
                {
                    audio1.DOPitch(1f + (-changeValue), 0.167f).SetEase(Ease.InOutBack);
                }

                gameManager.currentPiece.changeValueY = changeValue;
                break;
            case 1:
                // For Side to Side Speed
                float touchDifferenceX = currentButtonPosition.x - Input.mousePosition.x;
                changeValue = touchDifferenceX * -0.005f;

                // Change every 10 frames and duration of pitch change is 1/6  from that value
                if (Time.frameCount % 10 == 0)
                {
                    audio2.DOPitch(1f + (changeValue * 0.2f), 0.167f);
                }


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

                if (Time.frameCount % 10 == 0)
                {
                    audio3.DOPitch((rotationVal * 0.01f) + 1f, 0.167f).SetEase(Ease.InOutBack);
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
