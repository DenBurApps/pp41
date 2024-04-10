using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSecretPlateData : CreatePlateData
{
    [SerializeField] private protected InputFieldChanger infoField2;
    public bool inEdit;
    public override void Save()
    {
        properties.info2 = infoField2.text;

        base.Save();
    }
    public override void Edit()
    {
        properties.info2 = infoField2.text;

        base.Edit();

    }
    private void OnDisable()
    {
        inEdit = false;
    }
}
