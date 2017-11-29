using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour {

    private void OnMouseEnter()
    {
        GetComponent<Text>().color = new Color(180, 180, 0);
    }

    private void OnMouseExit()
    {
        GetComponent<Text>().color = new Color(255, 255, 255);
    }
}
