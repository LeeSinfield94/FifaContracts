using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void SaveCurrentContract(string saveName, Dictionary<string, string> rules)
    {
        StreamWriter tw = new StreamWriter(Application.dataPath + saveName, false);
        tw.Write("rule, punishment");
        foreach (KeyValuePair<string, string> rule in rules)
        {
            tw.WriteLine();
            tw.Write(rule.Key + ", " + rule.Value);
        }
        tw.Close();
    }

    public static void LoadContract(string saveName)
    {
        StreamReader sr = new StreamReader(Application.dataPath + saveName);
        string[] newString = sr.ReadToEnd().Split(new string[] { "\n" }, StringSplitOptions.None);
        for (int i = 1; i <= newString.Length - 1; i++)
        {
            string[] dataValues = newString[i].Split(',');
            Contract.Instance.AddRuleToContract(dataValues[0], dataValues[1]);
        }
        print(newString);
    }
}
