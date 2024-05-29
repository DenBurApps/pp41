using System;
using UnityEngine;

public class ToggleMechanic : MonoBehaviour
{
    public bool currentState;
    public Action<bool> action;

    [SerializeField] private GameObject activated;
    [SerializeField] private GameObject disabled;

    public void Init(Action<bool> action)
    {
        this.action = action;
    }
    public void SetState(bool state)
    {
        activated.SetActive(state);
        disabled.SetActive(!state);

        currentState = state;
        action?.Invoke(currentState);
    }
    public void ChangeState()
    {
        currentState = !currentState;

        activated.SetActive(currentState);
        disabled.SetActive(!currentState);

        action?.Invoke(currentState);
    }
}
