using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LayerMovementBase : MonoBehaviour
{
    [SerializeField] protected List<ScenePortionBase> _scenarioPieces = new List<ScenePortionBase>();
    [SerializeField] protected int _numberOfActivePieces = 3;
    [SerializeField] protected Transform _endPointPosition;
    [SerializeField] protected float _speedMultiplier = 1.0f;
    protected List<ScenePortionBase> _visibleScenarios = new List<ScenePortionBase>();
    protected ScenePortionBase _frontPiece;
    protected ScenePortionBase _backPiece;

    private void Start()
    {
        SetInitialPieces();
    }

    private void Update()
    {
        CheckIfNewPieceNeeded();
    }

    public void MovePieces(float movementValue)
    {
        foreach (ScenePortionBase portion in _visibleScenarios)
        {
            portion.transform.position -= Vector3.right * movementValue * _speedMultiplier;

        }
    }

    protected void CheckIfNewPieceNeeded()
    {
        if (_frontPiece.transform.position.x >= _endPointPosition.position.x)
        {
            return;
        }

        AttachNewPart();
    }

    private void AttachNewPart()
    {
        ScenePortionBase newPart; ;
        _frontPiece.Deactivate();
        _visibleScenarios.Remove(_frontPiece);
        _frontPiece = _visibleScenarios[0];
        newPart = GetFreeScenePortion();
        newPart.PositionateAfterPortion(_backPiece);
        _visibleScenarios.Add(newPart);
        _backPiece = newPart;
        _backPiece.Activate();

    }
    protected void SetInitialPieces()
    {
        ScenePortionBase _freeScenePortion;
        for (int i = 0; i <= _numberOfActivePieces; i++)
        {

            _freeScenePortion = GetFreeScenePortion();
            _visibleScenarios.Add(_freeScenePortion);
            _freeScenePortion.Activate();
            if (i > 0)
            {
                _freeScenePortion.PositionateAfterPortion(_backPiece);
            }
            else
            {
                _freeScenePortion.transform.position = _endPointPosition.position;
            }
            _backPiece = _freeScenePortion;

        }
        _frontPiece = _visibleScenarios[0];
    }

    protected ScenePortionBase GetFreeScenePortion()
    {
        List<ScenePortionBase> _freeScenees = new List<ScenePortionBase>();

        foreach (ScenePortionBase item in _scenarioPieces)
        {
            if (!item.InUse)
            {
                _freeScenees.Add(item);
            }
        }
        int _currentScenePortion = Random.Range(0, _freeScenees.Count - 1);
        return _freeScenees[_currentScenePortion];
    }
}

