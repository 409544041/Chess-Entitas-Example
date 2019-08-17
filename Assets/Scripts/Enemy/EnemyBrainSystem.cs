using Entitas;
using UnityEngine;

public class EnemyBrainSystem : IInitializeSystem, IExecuteSystem
{
    private Contexts _contexts;
    private float _moveDelay;
    private float _timeStamp;
    
    public EnemyBrainSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _moveDelay = _contexts.config.gameConfig.value.EnemyMoveDelay;
        _timeStamp = Time.time + _moveDelay;
    }
    
    public void Execute()
    {
        if (Time.time >= _timeStamp)
        {
            _timeStamp += _moveDelay;
            Move();
        }
    }

    private void Move()
    {
        Debug.Log("Move");
    }
}
