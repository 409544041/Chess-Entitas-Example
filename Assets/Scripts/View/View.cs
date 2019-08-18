using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyListener
{
    [SerializeField] private float _moveSpeed = 0.1f;
    
    public virtual void Link(IEntity entity)
    {
        gameObject.Link(entity);
        GameEntity e = (GameEntity) entity;
        e.AddPositionListener(this);
        e.AddDestroyListener(this);
        Vector2Int pos = e.position.value;
        OnPosition(e, pos);
    }

    public virtual void OnPosition(GameEntity entity, Vector2Int value)
    {
        if (entity.isRevertY) value.y = -value.y;
        LeanTween.moveLocal(gameObject, new Vector3(value.x, value.y), _moveSpeed);
    }

    public virtual void OnDestroy()
    {
        gameObject.Unlink();
        Destroy(gameObject);
        
    }

    public void OnDestroy(GameEntity entity)
    {
        OnDestroy();
        entity.Destroy();
    }
}
