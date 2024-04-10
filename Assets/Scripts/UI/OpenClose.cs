using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenClose : MonoBehaviour
{
    private bool state = false;
    [SerializeField] private GameObject obj;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            state = !state;
            obj.SetActive(state);
        });
    }

}
