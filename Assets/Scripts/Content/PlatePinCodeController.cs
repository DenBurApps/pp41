using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PlatePinCodeController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [HideInInspector]
    public BasePlate plate;

    [SerializeField] private GameObject[] Dots;
    [SerializeField] private TextMeshProUGUI[] numbers;
    [SerializeField] private Button enterButton;
    private bool hidden;
    private void Awake()
    {
        inputField.onValueChanged.AddListener(CheckPin);
        enterButton.onClick.AddListener(() => {
            CheckPinCorrectnes();
        });
    }
    private void OnEnable()
    {
        inputField.Select();
    }
    private void CheckPinCorrectnes()
    {
        if (inputField.text == plate.properties.Password)
        {
            gameObject.SetActive(false);
            plate.GetComponent<Button>().onClick.RemoveAllListeners();
            plate.GetComponent<Button>().onClick.AddListener(plate.OpenPreview);
            plate.hiddenObj.SetActive(false);

        }
        else
            ClearInput();
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
        enterButton.interactable = str.Length == Dots.Length;
    }
    public void ClearInput()
    {
        inputField.text = "";
        CheckPin("");
    }
    public void ChangeHiddenState()
    {
        hidden = !hidden;
        if(hidden)
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
        CheckPin(inputField.text);
        inputField.Select();
        inputField.MoveTextEnd(true);

    }
}
