using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {  get; private set; }


        [SerializeField] private GameObject[] levels;
        [SerializeField] private Transform levelParent;
        [SerializeField] private GameObject Camera;

        private Dictionary<string, GameObject> _levelsDict;
        private GameObject _activeLevel;

        public UnityAction OnLevelStart;
        public UnityAction OnLevelCompelet;
        public UnityAction OnLevelFail;
        private void Awake()
        {
            Instance = this;

            _levelsDict = new Dictionary<string, GameObject>();

            for (int i = 0; i < levels.Length; i++)
            {
                _levelsDict.Add(levels[i].name, levels[i]);
            }
        }
        private void Start()
        {
            var levelName = PlayerPrefsManager.GetActiveLevelName();
            if (!string.IsNullOrEmpty(levelName))
            {
                SpawnLevel(levelName);
                if (levelName == "Shop" || levelName == "Home")
                    Camera.SetActive(false);
            }
            else
            {
                var locationNumber = PlayerPrefsManager.GetLocationNumber();
                if (locationNumber == 0)
                    UIManager.Instance.ActivePanel("StartMenu");
                else
                {
                    UIManager.Instance.ActivePanel("LocationPanel");
                    UIManager.Instance.ActivePanel("Location" +  locationNumber);
                }
            }
        }
        private void OnApplicationQuit()
        {
            PlayerPrefsManager.DeleteActiveLevelName();
            PlayerPrefsManager.SetLocationNumber(0);
        }
        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                PlayerPrefsManager.DeleteActiveLevelName();
                PlayerPrefsManager.SetLocationNumber(0);
            }
        }

        #region Level Controle
        public void LoadLevel(string name) 
        {
            PlayerPrefsManager.SetActiveLevelName(name);
            ResetLevel();
        }
        private void SpawnLevel(string name) 
        {
            var level = _levelsDict[name];

            var levelSpawned = Instantiate(level, levelParent.position, levelParent.rotation, levelParent);
            _activeLevel = levelSpawned;
        }

        public void ResetLevel() 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion

        #region Game State
        public void LevelStart() 
        {
            OnLevelStart?.Invoke();
        }
        public void LevelCompelet()
        {
            OnLevelCompelet?.Invoke();
        }
        public void LevelFail()
        {
            OnLevelFail?.Invoke();
        }
        #endregion
    }
}
