using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Qoran
{
    public class QoranJson : MonoBehaviour
    {
        [SerializeField] private InputField QoranName;
        [SerializeField] private InputField QoranText;
        [SerializeField] private InputField EnglishText;
        [SerializeField] private InputField IndonesianText;
        [SerializeField] private InputField UrdoText;
        [SerializeField] private InputField HindiText;
        [SerializeField] private InputField BengaliText;
        [SerializeField] private InputField TurkishText;
        [SerializeField] private InputField ChineseText;
        [SerializeField] private InputField RussianText;
        [SerializeField] private InputField FrenchText;
        [SerializeField] private InputField PersianText;
        [SerializeField] private InputField AudioName;


        [SerializeField] private Button saveButton;

        private void Start()
        {
            saveButton.onClick.AddListener(SaveJson);
        }

        private void SaveJson() 
        {
            var qoranData = new QoranData();

            qoranData.QoranText = QoranText.text;
            qoranData.EnglishText = EnglishText.text;
            qoranData.IndonesianText = IndonesianText.text;
            qoranData.UrdoText = UrdoText.text;
            qoranData.HindiText = HindiText.text;
            qoranData.BengaliText = BengaliText.text;
            qoranData.TurkishText = TurkishText.text;
            qoranData.ChineseText = ChineseText.text;
            qoranData.RussianText = RussianText.text;
            qoranData.FrenchText = FrenchText.text;
            qoranData.PersianText = PersianText.text;
            qoranData.AudioName = AudioName.text;

            string json = JsonUtility.ToJson(qoranData, true);
            File.WriteAllText(Application.dataPath + "/QoranSource/" + QoranName.text + ".json", json);
        }

       /* private void LoadData() 
        {
            var path = AssetDatabase.GetAssetPath(jsonFile);
            string json = File.ReadAllText(path);
            QoranData data = JsonUtility.FromJson<QoranData>(json);

            print(data.AudioName);
        }*/
    }
}
