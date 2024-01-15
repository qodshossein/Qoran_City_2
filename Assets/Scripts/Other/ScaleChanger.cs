using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale;

    private Vector3 _firstScale;

    private void Awake()
    {
        _firstScale = transform.localScale;
    }
    public void ChangeScale() 
    {
        transform.DOScale(targetScale, 0.3f);
    }
    public void BackToFirstScale() 
    {
        transform.DOScale(_firstScale, 0.3f);
    }
}
