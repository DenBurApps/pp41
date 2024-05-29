using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenClose : MonoBehaviour
{
    private bool opened = false;
    [SerializeField] private GameObject openGO;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            opened = !opened;
            openGO.SetActive(opened);
        });
    }
}
