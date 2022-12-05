using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Contract : MonoBehaviour
{
    Dictionary<string, string> _currentContractRules = new Dictionary<string, string>();

    public static Contract Instance;

    public string fileName;

    private void Awake()
    {
        Instance = this;
    }

    public void NewRuleByPlayer(string key, string value)
    {
        StreamWriter tw = new StreamWriter(fileName, true);
        tw.WriteLine();
        tw.Write(key + ", " + value);
        tw.Close();
        AddRuleToContract(key, value);
    }
    public void AddRuleToContract(string key, string value)
    {
        if(!_currentContractRules.ContainsKey(key))
        {
            _currentContractRules.Add(key, value);
        }
    }

    public void OpenContract()
    {
        UIManager.Instance.ClearCurrentContractList();
        UIManager.Instance.PopulateRules(_currentContractRules, false);
        SaveLoad.SaveCurrentContract("/NewContract.csv", _currentContractRules);
    }
}
