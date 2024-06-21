using UnityEngine;

public class SpriteScenePortion : ScenePortionBase
{
    private SpriteRenderer _spriteRenderer;
    
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
    public override Vector3 GetInitPoint() { 
    
        return new Vector3
            (SpriteRenderer.bounds.min.x,
            (SpriteRenderer.bounds.min.y + SpriteRenderer.bounds.max.y) /2.0f,
            transform.position.z);
    }

    public override Vector3 GetEndPoint()
    {

        return new Vector3
            (SpriteRenderer.bounds.max.x,
            (SpriteRenderer.bounds.min.y + SpriteRenderer.bounds.max.y) / 2.0f,
            transform.position.z);
    }
}
