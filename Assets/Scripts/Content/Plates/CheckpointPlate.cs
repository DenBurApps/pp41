using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPlate : BasePlate
{
    [SerializeField] private CheckpointInPlate prefab;
    [SerializeField] private Transform spawnPlace;

    public override void Init(Properties props, CreatePlateData plateEditor, GameObject editWindowsParent)
    {
        base.Init(props, plateEditor, editWindowsParent);

        SpawnCheckPoints();
    }
    private void SpawnCheckPoints()
    {
        for (int i = 0; i < properties.checkPoints.Count; i++) 
        {
            var prop = properties.checkPoints[i];
            var obj = Instantiate(prefab, spawnPlace);
            obj.Init(prop.name, prop.activated, this, i);
        }
    }
}
