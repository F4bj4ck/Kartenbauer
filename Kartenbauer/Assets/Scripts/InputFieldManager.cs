using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    [Serializable]
    public class TextPairs
    {
        public TMP_InputField input;
        public TMP_Text text;
    }

    [SerializeField]
    private TextPairs[] inputTextPairs;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var input in inputTextPairs)
        {
            input.input.onValueChanged.AddListener(delegate { UpdateTextFields(); });
        }
    }

    public void UpdateTextFields()
    {
        foreach (var input in inputTextPairs)
        {
            input.text.text = input.input.text;
        }
    }
}
