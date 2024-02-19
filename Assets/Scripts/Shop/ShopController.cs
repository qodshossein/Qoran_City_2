using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private Button backButton;

        private void Start()
        {
            backButton.onClick.AddListener(() =>
            {
                GameManager.Instance.LoadLevel("");
                PlayerPrefsManager.SetLocationNumber(0);
            });
        }
    }
}
