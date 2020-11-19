using UnityEngine;

public class PointsMovement : TransitionBase<Vector3>
{
    #region Methods

    protected override void Lerp(Vector3 current, Vector3 next, float step)
    {
        transform.position = Vector3.Lerp(current, next, step);
    }

    protected override void SetInitialValue()
    {
        SetCurrentValue(transform.position);
    }

    #endregion
}
