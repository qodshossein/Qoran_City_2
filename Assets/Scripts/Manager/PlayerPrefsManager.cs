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
        public static void SetLocationNumber(int value) => PlayerPrefs.SetInt("location", value);
        #endregion

        #region Setter
        public static string GetActiveLevelName() => PlayerPrefs.GetString("ActiveLevelName");
        public static string GetLanguge() => PlayerPrefs.GetString("Languge", "English");
        public static int GetLocationNumber() => PlayerPrefs.GetInt("location");
        #endregion

        #region Deleter
        public static void DeleteActiveLevelName() => PlayerPrefs.DeleteKey("ActiveLevelName");
        #endregion
    }
}
