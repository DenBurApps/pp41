using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinCode : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject[] Dots;
    [SerializeField] private CreateSecretPlateData createSecretPlateData;
    [SerializeField] private GameObject[] closeWindows;

    private void OnEnable()
    {
        inputField.text = string.Empty;
        inputField.Select();
    }
    private void Awake()
    {
        inputField.onValueChanged.AddListener((str) =>
        {
            for(int i = 0; i < Dots.Length; i++)
            {
                if (i < str.Length)
                    Dots[i].SetActive(false);
                else
                    Dots[i].SetActive(true);
            }
            if(str.Length == 4)
            {
                if (createSecretPlateData.inEdit)
                    createSecretPlateData.Edit();
                else
                    createSecretPlateData.Save();
                closeWindows[1].GetComponent<Animator>().SetTrigger("Open");
                closeWindows[0].SetActive(false);
            }
        });
    }
}
