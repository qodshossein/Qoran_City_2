using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class PlayerPrefsManager
    {
        #region Setter
        public static void SetActiveLevelName(string value) => PlayerPrefs.SetString("ActiveLevelName", value);
        public static void SetLanguge(string value) => PlayerPrefs.SetString("Languge", value);
        #endregion

        #region Setter
        public static string GetActiveLevelName(string defaultValue = "MainMenu") => PlayerPrefs.GetString("ActiveLevelName", defaultValue);
        public static string GetLanguge() => PlayerPrefs.GetString("Languge", "English");
        #endregion
    }
}
