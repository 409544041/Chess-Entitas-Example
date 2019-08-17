using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyListener
{
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
        transform.localPosition = new Vector3(value.x, value.y);
    }

    public virtual void OnDestroy()
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }

    public void OnDestroy(GameEntity entity)
    {
        OnDestroy();
    }
}
