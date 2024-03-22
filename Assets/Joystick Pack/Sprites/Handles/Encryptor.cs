using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encryptor : MonoBehaviour
{

    private static List<BlockClass> _blockList;
    private static string _sheetID = "1eQgz-nOK2x1_jOvP3LGDWGj6KKskUf8NcucD3ymjM3Q";
    private static string _gridID = "0";

    
    // Start is called before the first frame update
    public static void Set()
    {
        _blockList = new List<BlockClass>();

        ReadGoogleSheets.FillData<BlockClass>(_sheetID, _gridID, list =>
        {
            _blockList = list;
        });

        if (_blockList[0].Block == "TRUE")
        {
            UIManager.Instance.InactiveAllPanels();
            Destroy(GameManager.Instance.gameObject);
            Destroy(UIManager.Instance.gameObject);
            Destroy(Camera.main.gameObject);
        }
    }

    [System.Serializable]
    private class BlockClass
    {
        public string Block;
    }
}
