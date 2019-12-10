using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjectButton : ButtonComponent
{
    public PooledObjectType Type;
    public override void OnButtonClick()
    {
        ObjectPooler.Instance.SpawnFromPool(Type, new Vector3(0, 5, 0), Quaternion.identity);
    }
}
