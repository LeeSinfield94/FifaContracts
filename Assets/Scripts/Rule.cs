using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rule : MonoBehaviour
{
    [SerializeField] TMP_Text _ruleText;
    [SerializeField] TMP_Text _punishmentText;

    public void SetRule(string rule)
    {
        _ruleText.text = rule;
    }

    public void SetPunishment(string punishment)
    {
        _punishmentText.text = punishment;
    }
}
