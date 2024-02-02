using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectPosition : MonoBehaviour
{
    [SerializeField] private Transform minPosition;
    [SerializeField] private Transform maxPosition;
    [SerializeField] private Transform obj;
    [SerializeField] private float delayReset;
    [SerializeField] private bool resetRotation;

    private Quaternion _firstRotation;

    private void Awake()
    {
        _firstRotation = obj.rotation;
    }
    public void ResetPosition() 
    {
        Invoke(nameof(ReturnPosition), delayReset);
    }
    private void ReturnPosition() 
    {
        var pos = minPosition.position;
        pos.x = Random.Range(minPosition.position.x, maxPosition.position.x);

        obj.position = pos;

        if(resetRotation) 
            obj.rotation = _firstRotation;
    }
}
