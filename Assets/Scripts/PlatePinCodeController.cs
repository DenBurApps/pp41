using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatePinCodeController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private BasePlate plate;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject info;


    [SerializeField] private GameObject[] Dots;

    private void Awake()
    {
        inputField.onValueChanged.AddListener(CheckPin);
    }
    private void CheckPin(string str)
    {
        for (int i = 0; i < Dots.Length; i++)
        {
            if (i < str.Length)
                Dots[i].SetActive(false);
            else
                Dots[i].SetActive(true);
        }
        if (str.Length == Dots.Length && str != plate.properties.info2)
            inputField.text = "";
        if (str == plate.properties.info2)
        {
            obj.SetActive(false);
            info.SetActive(true);
        }
    }
}
