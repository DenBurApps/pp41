using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinCodeManager : MonoBehaviour
{
    public TMP_InputField input;

    [SerializeField] private GameObject[] Dots;
    [SerializeField] private TextMeshProUGUI[] numbers;
    Action<string> action;

    private bool hidden;

    public void Init(Action<string> action)
    {
        input = GetComponent<TMP_InputField>();
        this.action = action;
        input.onValueChanged.AddListener((str) =>
        {
            CheckPin(str);
        });
    }
    public void ChangeHiddenState()
    {
        hidden = !hidden;
        if (hidden)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i].text = "";
            }
        }
        else
        {
            for (int i = 0; i < Dots.Length; i++)
            {
                Dots[i].SetActive(false);
            }
        }
        CheckPin(input.text);
        input.Select();
        input.MoveTextEnd(true);
        
    }
    private void CheckPin(string str)
    {
        if (hidden)
        {
            for (int i = 0; i < Dots.Length; i++)
            {
                if (i < str.Length)
                    Dots[i].SetActive(true);
                else
                    Dots[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < str.Length; i++)
            {
                numbers[i].text = str[i].ToString();
            }
        }
        if (input.text.Length == 4)
        {
            action?.Invoke(input.text);
        }
    }
    public void ClearInput()
    {
        input.text = string.Empty;
    }
}
