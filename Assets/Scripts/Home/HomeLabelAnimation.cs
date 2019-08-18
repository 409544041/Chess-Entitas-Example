using UnityEngine;

public class HomeLabelAnimation : MonoBehaviour, IHomeLabelActiveListener
{
    [SerializeField] private Animator _anim;
    private static readonly int ActiveHash = Animator.StringToHash("isActive");

    void Start()
    {
        var listener = Contexts.sharedInstance.ui.SetHomeLabelActive(true);
        listener.AddHomeLabelActiveListener(this);
    }

    public void OnHomeLabelActive(UiEntity entity, bool value)
    {
        _anim.SetBool(ActiveHash, value);
    }
}
