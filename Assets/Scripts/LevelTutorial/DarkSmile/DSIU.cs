using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DSIU : MonoBehaviour
{
    public TextMeshProUGUI promptText;

    private void Start()
    {

    }

    public void UpdateText(string text)
    {
        promptText.text = text;
    }
}
