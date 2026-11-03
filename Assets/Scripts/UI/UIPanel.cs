using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    public bool IsVisible => gameObject.activeSelf;

    public virtual void Show()
    {
        if (IsVisible)
            return;

        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        if (!IsVisible)
            return;

        gameObject.SetActive(false);
    }
}