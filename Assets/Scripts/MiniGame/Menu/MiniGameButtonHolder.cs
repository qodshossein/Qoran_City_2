using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame.Menu
{
    public class MiniGameButtonHolder : MonoBehaviour
    {
        [SerializeField] private MiniGameButton miniGameButtonPrefab;
        [SerializeField] private string[] miniGamesName;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        // Start is called before the first frame update
        void Start()
        {
            _button.onClick.AddListener(() =>
            {
                var buttonHolder = UIManager.Instance.miniGameButtonHolder;
                for (int i = 0; i < buttonHolder.childCount; i++)
                {
                    Destroy(buttonHolder.GetChild(i).gameObject);
                }

                for (int i = 0; i < miniGamesName.Length; i++)
                {
                    var miniGameButton = Instantiate(miniGameButtonPrefab, buttonHolder);
                    var Text = miniGameButton.GetComponentInChildren<Text>();
                    var number = i + 1;
                    Text.text = number.ToString();
                    miniGameButton.MiniGameName = miniGamesName[i];
                }
                UIManager.Instance.ActivePanel("MiniGameSelectPanel");
            });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
