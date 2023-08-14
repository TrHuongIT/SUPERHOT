using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayrUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;

    public void UpdateText(string promptMess)
    {
        promptText.text = promptMess;
    }
}
