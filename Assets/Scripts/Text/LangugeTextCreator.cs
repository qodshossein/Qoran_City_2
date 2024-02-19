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
        holder.AddComponent<Text>();
        var langugeText = holder.AddComponent<LangugeText>();

        holder.transform.parent = Selection.objects[0].GameObject().transform;
        holder.transform.localScale = Vector3.one;
        holder.transform.localPosition = Vector3.zero;
    }
}
#endif
