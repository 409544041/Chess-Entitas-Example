using System;
using System.Collections.Generic;
using System.Reflection;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyListener
{
    [SerializeField] private float _moveSpeed = 0.1f;
    
    public virtual void Link(IEntity entity)
    {
        AddComponentToEntity(entity);
        gameObject.Link(entity);
        GameEntity e = (GameEntity) entity;
        e.AddPositionListener(this);
        e.AddDestroyListener(this);
        Vector2Int pos = e.position.value;
        OnPosition(e, pos);
    }

    private void AddComponentToEntity(IEntity entity)
    {
        BaseComponentMonoBehaviour[] monoComponents = GetComponents<BaseComponentMonoBehaviour>();
        IContext currentContext = Contexts.sharedInstance.game;
        string componentLookupClassName = currentContext.contextInfo.name + "ComponentsLookup";
        Type[] componentTypes = (Type[]) Type.GetType(componentLookupClassName).GetField("componentTypes", BindingFlags.Public | BindingFlags.Static).GetValue(null);
        for (int i = 0; i < monoComponents.Length; i++)
        {
            var component = monoComponents[i].Component;
            int componentIndex = Array.IndexOf(componentTypes, component.GetType());
            entity.AddComponent(componentIndex, component);
            Destroy(monoComponents[i]);
        }
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
