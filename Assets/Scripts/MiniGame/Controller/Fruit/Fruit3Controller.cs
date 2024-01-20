using Manager;
using MiniGame.DragAndDrop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit3Controller : MonoBehaviour
{
    [SerializeField] private DragFindText[] textFindings;

    private int _numberFruit;
    private void Start()
    {
        for (int i = 0; i < textFindings.Length; i++)
        {
            textFindings[i].OnDrop.AddListener(OnSetFruit);
        }
    }
    private void OnSetFruit()
    {
        _numberFruit++;


        if (_numberFruit >= textFindings.Length)
        {
            GameManager.Instance.LevelCompelet();
        }
    }
}
