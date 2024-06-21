using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScenePortionBase : MonoBehaviour
{
    private bool inUse = false;

    public bool InUse { get => inUse;}

    public abstract Vector3 GetInitPoint();
    public abstract Vector3 GetEndPoint();
    public void PositionateAfterPortion(ScenePortionBase otherPortion)
    {
        transform.position = otherPortion.GetEndPoint() + (transform.position - GetInitPoint());
    }
    public void Activate()
    {
        inUse = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        inUse = false;
        gameObject.SetActive(false);
    }
}
