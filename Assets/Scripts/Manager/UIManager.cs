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
        [SerializeField] private Button startButton;
        [SerializeField] private Button[] resetLevelButtons;
        [SerializeField] private Button[] nextLevelButtons;
        [SerializeField] private Button[] backToMainMenuButtons;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button cityButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button[] locationButtons;

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
        }
        private void Start()
        {
            GameManager.Instance.OnLevelStart += OnLevelStart;
            GameManager.Instance.OnLevelCompelet += OnLevelCompelet;
            GameManager.Instance.OnLevelFail += OnLevelFail;

            startButton.onClick.AddListener(() =>
            {
                GameManager.Instance.LevelStart();
            });

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
            homeButton.onClick.AddListener(() =>
            {
                GameManager.Instance.LoadLevel("Home");
            });

            for (int i = 0; i < locationButtons.Length; i++)
            {
                var number = i + 1;
                locationButtons[i].onClick.AddListener(() => { ActiveLocation(number); });
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
        private void ActiveLocation(int numberLocation) 
        {
            for (int i = 0; i < locationButtons.Length; i++)
            {
                var number = i + 1;
                InactivePanel("Location" + number);
            }

            InactivePanel("LocationSelectPanel");
            ActivePanel("Location" + numberLocation);
            ActivePanel("LocationPanel");
            PlayerPrefsManager.SetLocationNumber(numberLocation);
        }

        private void OnLevelStart() 
        {
            InactivePanel("Start");
            ActivePanel("GamePlay");
        }
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
