using Unity.VisualScripting;
using UnityEngine;

public class GroundCollision
{
    private int _numLectures = 3;
    private BoxCollider2D _collider;
    private Vector2 _lecturesInitPoint;
    private Vector2 _lecturesEndPoint;
    private LayerMask _layersToIgnore;

    public int NumLectures { get => _numLectures; set => _numLectures = value; }

    public GroundCollision(BoxCollider2D collider, LayerMask layersToIgnore)
    {
        _collider = collider;
        _layersToIgnore = layersToIgnore;
        
    }

    public float DistanceToGround()
    {
        float result = float.MaxValue;
        _lecturesInitPoint = new Vector2(_collider.bounds.min.x, _collider.bounds.min.y);
        _lecturesEndPoint = new Vector2(_collider.bounds.max.x, _collider.bounds.min.y);
        float distanceBetweenLectures = Vector2.Distance(_lecturesInitPoint, _lecturesEndPoint) /( _numLectures -1);
        RaycastHit2D rayHit;
        for (int i = 0; i < NumLectures; i++)
        {
            rayHit = Physics2D.Raycast(_lecturesInitPoint + Vector2.right * i * distanceBetweenLectures, Vector2.down, Mathf.Infinity, _layersToIgnore);
            if (rayHit.collider == null)
            {
                continue;
            }
            if (rayHit.distance < result)
            {
                result = rayHit.distance;
            }
            Debug.DrawLine(_lecturesInitPoint + Vector2.right * i * distanceBetweenLectures, Vector2.down * rayHit.distance + (_lecturesInitPoint + Vector2.right * i * distanceBetweenLectures));
        }
        return result;
    }
}
