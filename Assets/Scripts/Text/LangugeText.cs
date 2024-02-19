using Manager;
using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LangugeText : MonoBehaviour
{
    public LangugeHolder[] langugeHolders;

    private bool _activeGame;
    private Text _text;

    private Dictionary<string, LangugeHolder> _langugeDic;
    private void Awake()
    {
        _text = GetComponent<Text>();

        _langugeDic = new Dictionary<string, LangugeHolder>();
        for (int i = 0; i < langugeHolders.Length; i++)
        {
            _langugeDic.Add(langugeHolders[i].langugeName, langugeHolders[i]);
        }
    }

    private void Start()
    {
        _activeGame = true;
        var langugeName = PlayerPrefsManager.GetLanguge();
        SetLangugeText(langugeName);
    }

    private void OnValidate()
    {
        if (langugeHolders == null || _activeGame) return;
        _text = GetComponent<Text>();
        for (int i = 0; i < langugeHolders.Length; i++)
        {
            if (langugeHolders[i].Active)
            {
                var text = langugeHolders[i].text;
                _text.text = text;
                return;
            }
        }
    }

    public void SetLangugeText(string langugeName) 
    {
        var langugeHolder = _langugeDic[langugeName];
        var text = langugeHolder.text;

        _text.text = text;
    }
}
[System.Serializable]
public class LangugeHolder 
{
    public string langugeName;
    public bool Active = true;

    [TextArea(5, 10)]
    public string text;
}
