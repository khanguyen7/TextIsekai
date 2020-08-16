using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Responsible for creating textobjects and putting them in the text area
public class TextController : MonoBehaviour {

    public Text textObjectPrefab;
    public int mainFontSize;
    int textCount = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateText(string message) {
        Text newText = Instantiate(textObjectPrefab, transform.position, transform.rotation);
        newText.transform.SetParent(transform);
        newText.transform.localScale = new Vector3(1, 1, 1);
        newText.text = message;
        newText.fontSize = 45;

        textCount++;
    }

    public void DeleteText() {
        Destroy(GetComponent<Transform>().GetChild(0).gameObject);

        textCount--;
    }
}
