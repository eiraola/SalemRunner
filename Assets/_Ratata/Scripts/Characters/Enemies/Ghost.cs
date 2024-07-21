using UnityEngine;

public class Ghost : MonoBehaviour, IPoolable
{
    [SerializeField] private PoolSignalSO _poolSignalSO;
    [SerializeField] private GameObject _visual;
    public void Depool()
    {
        _visual.transform.localPosition = Vector3.zero;
    }

    public void Pool()
    {
        gameObject.SetActive(false);
    }

    public void CallPoolAction()
    {
        _poolSignalSO.Pool(this);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
