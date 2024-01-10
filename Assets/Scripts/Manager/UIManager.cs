using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private PanelHolder[] panelHolders;
        [SerializeField] private Button[] resetLevelButtons;
        [SerializeField] private Button[] nextLevelButtons;

        private Dictionary<string, GameObject> _panelDic;

        private void Awake()
        {
            _panelDic = new Dictionary<string, GameObject>();

            for (int i = 0; i < panelHolders.Length; i++)
            {
                _panelDic.Add(panelHolders[i].PanelName, panelHolders[i].Panel);
            }

            GameManager.Instance.OnLevelCompelet += OnLevelCompelet;
            GameManager.Instance.OnLevelFail += OnLevelFail;
        }
        private void Start()
        {
            for (int i = 0; i < resetLevelButtons.Length; i++)
            {
                resetLevelButtons[i].onClick.AddListener(() =>
                {
                    GameManager.Instance.ResetLevel();
                });
            }
            for (int i = 0; i < nextLevelButtons.Length; i++)
            {
                nextLevelButtons[i].onClick.AddListener(() =>
                {
                    GameManager.Instance.ResetLevel();
                });
            }
        }
        private void OnDestroy()
        {
            GameManager.Instance.OnLevelCompelet -= OnLevelCompelet;
            GameManager.Instance.OnLevelFail -= OnLevelFail;
        }

        public void ActivePanel(string panelName) 
        {
            var panel = _panelDic[panelName];
            panel.SetActive(true);
        }
        public void InactivePanel(string panelName)
        {
            var panel = _panelDic[panelName];
            panel.SetActive(false);
        }
        public void InactiveAllPanels()
        {
            for (int i = 0; i < panelHolders.Length; i++)
            {
                var panel = panelHolders[i].Panel;
                panel.SetActive(false);
            }
        }
        public GameObject GetPanel(string panelName) => _panelDic[panelName];

        private void OnLevelCompelet() 
        {
            ActivePanel("Win");
        }
        private void OnLevelFail()
        {
            ActivePanel("Lose");
        }
    }

    [System.Serializable]
    public class PanelHolder 
    {
        public string PanelName;
        public GameObject Panel;
    }
}
