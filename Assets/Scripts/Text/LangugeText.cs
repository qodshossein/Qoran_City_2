using Manager;
using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LangugeText : MonoBehaviour
{
    public List<LangugeHolder> langugeHolders;

    private bool _activeGame;

    private void Start()
    {
        _activeGame = true;

        var languge = PlayerPrefsManager.GetLanguge();
        for (int i = 0; i < langugeHolders.Count; i++)
        {
            langugeHolders[i].textComponent.gameObject.SetActive(false);
        }
        for (int i = 0; i < langugeHolders.Count; i++) 
        {
            if(languge == langugeHolders[i].langugeName) 
            {
                langugeHolders[i].textComponent.gameObject.SetActive(true);
                break;
            }
        }
    }
    public void AddNewText(RTLTextMeshPro text, string name) 
    {
        var langugeHolder = new LangugeHolder();
        langugeHolder.textComponent = text;
        langugeHolder.langugeName = name;
        langugeHolders.Add(langugeHolder);
    }
    private void OnValidate()
    {
        if(langugeHolders == null || _activeGame) return;
        for (int i = 0; i < langugeHolders.Count; i++)
        {
            var component = langugeHolders[i].textComponent;
            var text = langugeHolders[i].text;

            component.text = text;

            component.gameObject.SetActive(langugeHolders[i].Active);
        }
    }
}
[System.Serializable]
public class LangugeHolder 
{
    public string langugeName;
    public RTLTextMeshPro textComponent;
    public bool Active = true;

    [TextArea(5, 10)]
    public string text;
}
