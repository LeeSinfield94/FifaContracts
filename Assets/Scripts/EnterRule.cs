using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRule : MonoBehaviour
{
    string _rule;
    string _punishment;

    public void UpdateRule(string rule)
    {
        _rule = rule;
    }

    public void UpdatePunishment(string punishment)
    {
        _punishment = punishment;
    }

    public void ConfirmRuleAndPunishment()
    {
        if(_rule != "" && _punishment != "")
        {
            Contract.Instance.NewRuleByPlayer(_rule, _punishment);
        }
    }
}
