using UnityEngine;

public abstract class ContextView<T> : MonoBehaviour
{
    public T Context { get; private set; }

    public void Setup(T context, bool updateView = true)
    {
        Context = context;

        if (updateView)
            UpdateView();
    }

    public abstract void UpdateView();
}