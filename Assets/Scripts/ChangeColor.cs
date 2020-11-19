using UnityEngine;

public class ChangeColor : TransitionBase<Color>
{
    #region Private Fields

    private Renderer _myRenderer;

    #endregion


    #region Unity Lifecycle

    private void Awake()
    {
        _myRenderer = GetComponent<Renderer>();
    }

    #endregion


    #region Methods

    protected override void SetInitialValue()
    {
        SetCurrentValue(_myRenderer.material.color);
    }

    protected override void Lerp(Color current, Color next, float step)
    {
        _myRenderer.material.color = Color.Lerp(current, next, step);
    }

    #endregion
}
