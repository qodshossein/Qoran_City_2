#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.UI;
using RTLTMPro;

public class LangugeTextCreator
{
    [MenuItem("GameObject/UI/LangugeText")]
    public static void CreateLangugeText() 
    {
        var holder = new GameObject("Languge Text");
        holder.AddComponent<RectTransform>();
        var langugeText = holder.AddComponent<LangugeText>();
        langugeText.langugeHolders = new List<LangugeHolder>();

        var persian = new GameObject("Persian Text");
        var persianText = persian.AddComponent<RTLTextMeshPro>();
        var english = new GameObject("English Text");
        var englishText = english.AddComponent<RTLTextMeshPro>();
        var arabic = new GameObject("Arabic Text");
        var arabicText = arabic.AddComponent<RTLTextMeshPro>();

        langugeText.AddNewText(persianText, "Persian");
        langugeText.AddNewText(englishText, "English");
        langugeText.AddNewText(arabicText, "Arabic");
        persian.transform.parent = holder.transform;
        english.transform.parent = holder.transform;
        arabic.transform.parent = holder.transform;

        holder.transform.parent = Selection.objects[0].GameObject().transform;
        holder.transform.localScale = Vector3.one;
        holder.transform.localPosition = Vector3.zero;
    }
}
#endif
