using Manager;
using UnityEngine;
using MiniGame;
using MiniGame.DragAndDrop;
using DG.Tweening;

public class Fruit5Controller : MiniGameController
{
    [SerializeField] private SpriteRenderer emptyMixer;
    [SerializeField] private Transform glass;
    [SerializeField] private Transform targetGlass;

    private int _numberFruit;
    
    public override void OnFind()
    {
        _numberFruit++;

        if (_numberFruit >= maxFind)
        {
            emptyMixer.DOFade(0, 1).OnComplete(() => 
            {
                glass.DOMove(targetGlass.position, 1).SetDelay(1).OnComplete(() => 
                {
                    Invoke(nameof(CompeletLevel), 1);
                });
            });
        }
    }

    private void CompeletLevel() 
    {
        GameManager.Instance.LevelCompelet();
    }
}
