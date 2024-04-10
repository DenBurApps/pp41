using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMechanic : MonoBehaviour
{
    public bool currentState;

    [SerializeField] private ThemeChanger themeChanger;
    private void Start()
    {
        //SetState(DataProcessor.Instance.allData.theme);
    }
    public void SetState(bool state) {
        if(currentState != state) {
            currentState = state;
            GetComponent<Animator>().SetTrigger(state ? "On" : "Off");
        }
    }

    public void ChangeState() {
        currentState = !currentState;
        GetComponent<Animator>().SetTrigger(currentState ? "On" : "Off");
        themeChanger.ChangeBG(currentState);
    }
}
