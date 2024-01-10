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
            //LoadLevel(levelName);
        }

        #region Level Controle
        public void LoadLevel(string name) 
        {
            var level = _levelsDict[name];

            var levelSpawned = Instantiate(level, levelParent.position, levelParent.rotation, levelParent);
            _activeLevel = levelSpawned;

            PlayerPrefsManager.SetActiveLevelName(name);
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
