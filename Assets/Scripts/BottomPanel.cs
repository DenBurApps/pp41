using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
    public static BottomPanel instance;

    [Serializable]
    private struct buttonsAndWindows
    {
        public Button button;
        public GameObject window;
        public GameObject[] disableWindows;
        public GameObject enableWindow;
    }
    [SerializeField]
    private buttonsAndWindows[] BAW;
    private void Awake()
    {
        instance = this;
        foreach (var obj in BAW)
        {
            obj.button.onClick.AddListener(() =>
            OnClick(obj.button, obj.window,obj.enableWindow,obj.disableWindows));
        }
    }
    private void OnClick(Button button, GameObject window,GameObject enableWindow, GameObject[] disableWindows)
    {
        foreach(var obj in BAW)
        {
            obj.button.interactable = true;
            obj.window.SetActive(false);
        }
        window.SetActive(true);
        enableWindow.SetActive(true);
        button.interactable = false;

        foreach (var item in disableWindows)
            item.SetActive(false);
    }
}
