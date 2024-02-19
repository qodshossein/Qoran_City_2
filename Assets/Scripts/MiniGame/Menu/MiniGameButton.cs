using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame.Menu
{
    public class MiniGameButton : MonoBehaviour
    {
        public string MiniGameName {  get; set; }

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                GameManager.Instance.LoadLevel(MiniGameName);
            });
        }
    }
}
