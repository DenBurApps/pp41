using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckMark : MonoBehaviour
{
    [SerializeField] private GameObject check;
    public TextMeshProUGUI status;
    private Check props;

    public void Init(Check props)
    {
        this.props = props;
        status.text = props.Name;
        check.SetActive(props.Checked);
    }
    public Check ReturnStatus()
    {
        return props;
    }
    public void ChangeCheckState()
    {
        props.Checked = !props.Checked;
        check.SetActive(props.Checked);
    }
}
