using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePortion : MonoBehaviour
{
    private Vector3 _initPoint = Vector3.zero;
    private Vector3 _endPoint = Vector3.zero;
    private SpriteRenderer _spriteRenderer;
    public bool inUse = false;

    public SpriteRenderer SpriteRenderer { 
        get 
        {
            if (!_spriteRenderer)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }
    public Vector3 GetInitPoint() { 
    
        return new Vector3
            (SpriteRenderer.bounds.min.x,
            (SpriteRenderer.bounds.min.y + SpriteRenderer.bounds.max.y) /2.0f,
            transform.position.z);
    }

    public Vector3 GetEndPoint()
    {

        return new Vector3
            (SpriteRenderer.bounds.max.x,
            (SpriteRenderer.bounds.min.y + SpriteRenderer.bounds.max.y) / 2.0f,
            transform.position.z);
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

    public void PositionateAfterPortion(ScenePortion otherPortion)
    {
        transform.position = otherPortion.GetEndPoint() + (transform.position  - GetInitPoint());
    }
}
