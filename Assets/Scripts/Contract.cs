using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Contract : MonoBehaviour
{
    Dictionary<string, string> _currentContractRules = new Dictionary<string, string>();

    public static Contract Instance;

    public string fileName;

    string _saveGamePrefix = "/";
    string _saveGameFileType = ".csv";

    private void Awake()
    {
        Instance = this;
    }

    public void NewRuleByPlayer(string key, string value)
    {
        if(key != "" && value != "")
        {
            StreamWriter tw = new StreamWriter(fileName, true);
            tw.WriteLine();
            tw.Write(key + ", " + value);
            tw.Close();
            AddRuleToContract(key, value);
        }
    }
    public void AddRuleToContract(string key, string value)
    {
        if(!_currentContractRules.ContainsKey(key))
        {
            _currentContractRules.Add(key, value);
        }
    }

    public void ClearCurrentContractRules()
    {
        _currentContractRules.Clear();
    }
    public void OpenContract()
    {
        UIManager.Instance.ClearCurrentContractList();
        UIManager.Instance.PopulateRules(_currentContractRules, false);
    }

    public void SaveContract(string saveName)
    {
        SaveLoad.SaveCurrentContract(_saveGamePrefix + saveName + _saveGameFileType, _currentContractRules);
    }
    public void LoadContract(TMP_Text contractToLoad)
    {
        SaveLoad.LoadContract(contractToLoad.text);
    }
}
