using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioMovementHandler : MonoBehaviour
{
    [SerializeField] private List<ScenePortion> _scenarioPieces = new List<ScenePortion>();
    [SerializeField] private List<ParalaxLayer> _paralaxPieces = new List<ParalaxLayer>();
    [SerializeField] private int _numberOfActivePieces = 3;
    [SerializeField] private Transform _endPointPosition;
    [SerializeField] private float  _movementSpeed = 3.0f;

    private List<ScenePortion> _visibleScenarios = new List<ScenePortion>();
    private ScenePortion _frontPiece;
    private ScenePortion _backPiece;
    private float _madeDistance = 0.0f;
    private void Start()
    {
        SetInitialPieces();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveScenario();
        CheckIfNewPieceNeeded();
        MoveParalaxElements();
    }

    private void MoveScenario()
    {
        foreach (ScenePortion portion in _visibleScenarios)
        {
            portion.transform.position -= Vector3.right * _movementSpeed * Time.deltaTime;

        }
        _madeDistance += _movementSpeed * Time.deltaTime;

    }

    private void MoveParalaxElements()
    {
        foreach (ParalaxLayer item in _paralaxPieces)
        {
            item.MoveParalaxLayer(_movementSpeed);
        }
    }
    private void CheckIfNewPieceNeeded()
    {
        if (_frontPiece.transform.position.x >= _endPointPosition.position.x)
        {
            return;
        }

        AttachNewPart();
    }

    private void AttachNewPart()
    {
        ScenePortion newPart; ;
        _frontPiece.Deactivate();
        _visibleScenarios.Remove(_frontPiece);
        _frontPiece = _visibleScenarios[0];
        newPart = GetFreeScenePortion();
        newPart.PositionateAfterPortion(_backPiece);
        _visibleScenarios.Add(newPart);
        _backPiece = newPart;
        _backPiece.Activate();

    }
    private void SetInitialPieces()
    {
        ScenePortion _freeScenePortion;
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

    private ScenePortion GetFreeScenePortion()
    {
        List<ScenePortion> _freeScenees = new List<ScenePortion>();

        foreach (ScenePortion item in _scenarioPieces)
        {
            if (!item.inUse)
            {
                _freeScenees.Add(item);
            }
        }
        int _currentScenePortion = Random.Range(0, _freeScenees.Count - 1);
        return _freeScenees[_currentScenePortion];
    }
}
