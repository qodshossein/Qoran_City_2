using Manager;
using MiniGame.DragAndDrop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit2Controller : MonoBehaviour
{
    [SerializeField] private DragFindColor[] spriteFindings;

    private int _numberFruit;
    private void Start()
    {
        for (int i = 0; i < spriteFindings.Length; i++)
        {
            spriteFindings[i].OnDrop.AddListener(OnSetFruit);
        }
    }
    private void OnSetFruit()
    {
        _numberFruit++;


        if (_numberFruit >= spriteFindings.Length)
        {
            GameManager.Instance.LevelCompelet();
        }
    }
}
