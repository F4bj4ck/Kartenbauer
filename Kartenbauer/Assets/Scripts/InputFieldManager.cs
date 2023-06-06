using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#70100a");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#5f9086");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#302683");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#c99551");
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#878786");
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#3aa935");
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#36a9e0");
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#662382");
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#e84e1b");
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            EventSystem system = EventSystem.current;
            GameObject obj = system.currentSelectedGameObject;
            TMP_InputField field = obj.GetComponent<TMP_InputField>();

            field.text = ColorSelection("#e3051a");
        }
    }

    string ColorSelection(string color)
    {
        EventSystem system = EventSystem.current;
        GameObject obj = system.currentSelectedGameObject;
        TMP_InputField field = obj.GetComponent<TMP_InputField>();

        string s = field.text;

        string returnString = "";

        string first = s.Substring(0, Mathf.Min(field.selectionAnchorPosition, field.selectionFocusPosition));
        string last = s.Substring(Mathf.Max(field.selectionAnchorPosition, field.selectionFocusPosition),
            s.Length - Mathf.Max(field.selectionAnchorPosition, field.selectionFocusPosition));

        string middle = s.Substring(Mathf.Min(field.selectionAnchorPosition, field.selectionFocusPosition),
            Mathf.Max(field.selectionAnchorPosition, field.selectionFocusPosition) -
            Mathf.Min(field.selectionAnchorPosition, field.selectionFocusPosition));

        string newMiddle = "<color=" + color + ">" + middle + "</color>";

        returnString = first + newMiddle + last;

        return returnString;
    }

    public void UpdateTextFields()
    {
        foreach (var input in inputTextPairs)
        {
            input.text.text = input.input.text;
        }
    }
}
