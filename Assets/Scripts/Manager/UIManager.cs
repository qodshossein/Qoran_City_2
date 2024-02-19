using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance {  get; private set; }

        [SerializeField] private PanelHolder[] panelHolders;
        [SerializeField] private Button[] resetLevelButtons;
        [SerializeField] private Button[] nextLevelButtons;
        [SerializeField] private Button[] backToMainMenuButtons;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button cityButton;
        [SerializeField] private Button location1Button;
        [SerializeField] private Button location2Button;
        [SerializeField] private Button location3Button;
        [SerializeField] private Button location4Button;
        [SerializeField] private Button location5Button;

        public Transform miniGameButtonHolder;

        private Dictionary<string, GameObject> _panelDic;

        private void Awake()
        {
            Instance = this;

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
                    GameManager.Instance.LoadLevel("");
                });
            }
            for (int i = 0; i < backToMainMenuButtons.Length; i++)
            {
                backToMainMenuButtons[i].onClick.AddListener(() =>
                {
                    GameManager.Instance.LoadLevel("");
                });
            }

            shopButton.onClick.AddListener(() =>
            {
                GameManager.Instance.LoadLevel("Shop");
            });
            cityButton.onClick.AddListener(() =>
            {
                InactivePanel("StartMenu");
                ActivePanel("LocationSelectPanel");
            });
            location1Button.onClick.AddListener(() => { InactivePanel("LocationSelectPanel"); ActivePanel("Location1");
                PlayerPrefsManager.SetLocationNumber(1);
            });
            location2Button.onClick.AddListener(() => { InactivePanel("LocationSelectPanel"); ActivePanel("Location2");
                PlayerPrefsManager.SetLocationNumber(2);
            });
            location3Button.onClick.AddListener(() => { InactivePanel("LocationSelectPanel"); ActivePanel("Location3");
                PlayerPrefsManager.SetLocationNumber(3);
            });
            location4Button.onClick.AddListener(() => { InactivePanel("LocationSelectPanel"); ActivePanel("Location4");
                PlayerPrefsManager.SetLocationNumber(4);
            });
            location5Button.onClick.AddListener(() => { InactivePanel("LocationSelectPanel"); ActivePanel("Location5");
                PlayerPrefsManager.SetLocationNumber(5);
            });
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
