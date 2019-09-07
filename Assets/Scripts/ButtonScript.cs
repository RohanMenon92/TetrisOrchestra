using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private int ButtonIdentifier;
    private InputController inputController;
    // Start is called before the first frame update
    void Start()
    {
        inputController = FindObjectOfType<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
