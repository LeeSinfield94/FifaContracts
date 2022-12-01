using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    Dictionary<string, string> _rules = new Dictionary<string, string>();

    public Dictionary<string, string> _Rules
    {
        get { return _rules; }
    }

    bool _CSVRead = false;
    public bool CSVRead
    {
        get { return _CSVRead; }
        set { _CSVRead = value; }
    }
    public static Rules instance;

    private void Awake()
    {
        instance = this;
    }
    public void AddRules(string rule, string punishment)
    {
        _rules.Add(rule, punishment);
        PrintAllRules();
    }

    public void UpdateRuleDrinkAmount(string key, string newPunishment)
    {
        if(_rules.ContainsKey(key))
        {
            _rules[key] = newPunishment;
        }
    }
    public void PrintAllRules()
    {
        foreach(KeyValuePair<string, string> rule in _rules)
        {
            print(rule.Key + " " + rule.Value);
        }
    }

}
