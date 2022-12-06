using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnterRule : MonoBehaviour
{
    [SerializeField] TMP_InputField _ruleInputField;
    [SerializeField] TMP_InputField _punishmentInputField;
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

    public void ResetInputFields()
    {
        if(_ruleInputField != null && _punishmentInputField != null)
        {
            _ruleInputField.ResetInputField();
            _punishmentInputField.ResetInputField();
        }
    }
}
