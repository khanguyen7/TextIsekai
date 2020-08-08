using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextObject : MonoBehaviour {

    // Variables
    Text textToEdit;
    public Font selectedFont;

    // Start is called before the first frame update
    void Start() {
        textToEdit = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetupText(string message, int fontSize) {
        textToEdit.text = message;
        textToEdit.font = selectedFont;
        textToEdit.fontSize = fontSize;
        //.fontStyle = fontStyle;
    }
}
