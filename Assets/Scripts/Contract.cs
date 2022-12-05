using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : MonoBehaviour
{
    Dictionary<string, string> _currentContractRules = new Dictionary<string, string>();

    public static Contract Instance;

    private void Awake()
    {
        Instance = this;
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
    }
}
