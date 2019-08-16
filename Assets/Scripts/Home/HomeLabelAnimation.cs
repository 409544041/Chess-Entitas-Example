using UnityEngine;

public class HomeLabelAnimation : MonoBehaviour, IAnyActiveListener
{
    [SerializeField] private Animator _anim;
    private static readonly int ActiveHash = Animator.StringToHash("isActive");

    void Start()
    {
        var listener = Contexts.sharedInstance.game.CreateEntity();
        listener.AddAnyActiveListener(this);
    }

    public void OnAnyActive(GameEntity entity, bool value)
    {
        _anim.SetBool(ActiveHash, value);
    }
}
