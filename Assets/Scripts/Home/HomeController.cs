using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Home
{
    public class HomeController : MonoBehaviour
    {
        [SerializeField] private RoomHolder[] roomHolders;
        [SerializeField] private Button backButton;

        private void Awake()
        {
            for (int i = 0; i < roomHolders.Length; i++)
            {
                var button = roomHolders[i].roomButton;
                var room = roomHolders[i].roomObject;

                button.onClick.AddListener(() =>
                {
                    for (int j = 0; j < roomHolders.Length; j++)
                    {
                        roomHolders[j].roomObject.SetActive(false);
                    }
                    room.SetActive(true);
                });
            }
        }

        private void Start()
        {
            backButton.onClick.AddListener(() =>
            {
                GameManager.Instance.LoadLevel("");
                PlayerPrefsManager.SetLocationNumber(0);
            });
        }

        [System.Serializable]
        private class RoomHolder 
        {
            public string Name;
            public Button roomButton;
            public GameObject roomObject;
        }
    }
}
