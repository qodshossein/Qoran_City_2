using Manager;
using MiniGame.Finder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit1Controller : MonoBehaviour
{
    [SerializeField] private TypeFinder[] spriteFindings;

    private int _numberFruit;
    private void Start()
    {
        for (int i = 0; i < spriteFindings.Length; i++)
        {
            spriteFindings[i].OnFindSprite.AddListener(OnSetFruit);
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
