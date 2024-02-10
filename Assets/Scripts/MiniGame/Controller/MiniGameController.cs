using Manager;
using MiniGame;
using MiniGame.Collision;
using MiniGame.Finder;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniGameController : MonoBehaviour
{
    public static MiniGameController Instance { get; private set; }

    [SerializeField] protected Drag[] objectDrags;
    [SerializeField] protected TypeFinder[] objectFinder;
    [SerializeField] protected CollisionChecker[] collisionCheckers;
    [SerializeField] protected CollisionChecker[] collisionCheckersFail;
    [SerializeField] protected Button3D[] buttons3D;
    [SerializeField] protected CardChecker cardChecker;
    [SerializeField] protected Match3 match3;
    [SerializeField] protected int maxFind;
    [SerializeField] protected int maxFail;

    public UnityEvent WhenFind;
    public UnityEvent WhenFail;
    public UnityEvent WhenWin;

    protected int _numberFind;
    protected int _numberFail;

    private void Awake()
    {
        Instance = this;
    }
    protected virtual void Start()
    {
        for (int i = 0; i < objectDrags.Length; i++)
        {
            objectDrags[i].OnDrop.AddListener(OnFind);
        }
        for (int i = 0; i < objectFinder.Length; i++)
        {
            objectFinder[i].OnFindSprite.AddListener(OnFind);
        }
        for (int i = 0; i < collisionCheckers.Length; i++)
        {
            collisionCheckers[i].OnHit.AddListener(OnFind);
        }
        for (int i = 0; i < buttons3D.Length; i++)
        {
            buttons3D[i].OnClickUp.AddListener(OnFind);
        }

        cardChecker?.OnFindRightCard.AddListener(OnFind);
        if (match3)
            match3.OnMoveUsed += OnFindMatch;

        for (int i = 0; i < collisionCheckersFail.Length; i++)
        {
            collisionCheckersFail[i].OnHit.AddListener(OnFail);
        }
    }
    private void OnDestroy()
    {
        if (match3)
            match3.OnMoveUsed -= OnFindMatch;
    }

    public virtual void OnFind() 
    {
        _numberFind++;

        if(_numberFind >= maxFind)
        {
            GameManager.Instance.LevelCompelet();
            WhenWin?.Invoke();
        }
        WhenFind?.Invoke();
    }
    protected virtual void OnFindMatch(object sender, EventArgs e)
    {
        OnFind();
    }
    public virtual void OnFail()
    {
        _numberFail++;

        if (_numberFail >= maxFail)
        {
            LevelFail();
        }
        WhenFail?.Invoke();
    }

    public virtual void LevelFail() 
    {
        GameManager.Instance.LevelFail();
    }
}
