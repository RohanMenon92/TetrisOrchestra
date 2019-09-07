using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int buttonIdentifier;
    private InputController inputController;
    // Start is called before the first frame update
    void Start()
    {
        inputController = FindObjectOfType<InputController>();
    }

    void OnMouseDown() {
        inputController.OnDown(buttonIdentifier);    
    }

    void OnMouseUp() {
        inputController.OnUp(buttonIdentifier);
    }

    void OnMouseDrag() {
        inputController.OnDrag(buttonIdentifier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
