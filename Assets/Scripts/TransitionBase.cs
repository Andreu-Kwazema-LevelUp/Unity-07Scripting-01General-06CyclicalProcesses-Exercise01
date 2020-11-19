using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionBase<T> : MonoBehaviour
{
    #region Private Fields

    [SerializeField]
    private float _transition = 2f;
    
    [SerializeField]
    private List<T> _values;


    private int _valueIndex;

    private T _currentValue;

    #endregion


    #region Public Property

    public int Loops { get; private set; }

    #endregion


    #region Unity Lifecycle

    protected virtual void Start()
    {
        _valueIndex = 0;

        Loops = 0;

        SetInitialValue();

        StartCoroutine(DoTransition());
    }

    #endregion


    #region Methods

    protected void SetCurrentValue(T current)
    {
        _currentValue = current;
    }


    protected abstract void Lerp(T current, T next, float step);

    protected abstract void SetInitialValue();

    #endregion


    #region Coroutines

    protected IEnumerator DoTransition()
    {
        float transitionSpet = 0;

        while (_transition > transitionSpet)
        {
            transitionSpet += Time.deltaTime;

            float step = transitionSpet / _transition;

            Lerp(_currentValue, _values[_valueIndex], step);

            yield return null;
        }

        _currentValue = _values[_valueIndex];

        _valueIndex = (_valueIndex + 1) % _values.Count;

        Loops++;

        StartCoroutine(DoTransition());
    }

    #endregion


    #region Events

    #endregion
}
