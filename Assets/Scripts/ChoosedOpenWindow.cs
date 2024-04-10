using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosedOpenWindow : MonoBehaviour
{
    private int i = 0;
    [SerializeField] private GameObject[] windows;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            foreach (var window in windows)
            {
                window.SetActive(false);
            }
            windows[i++].SetActive(true);
            if (i == windows.Length)
                i = 0;
        });
    }
}
