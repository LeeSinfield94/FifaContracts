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

    /// <summary>
    /// Loads all contracts in given path
    /// </summary>
    /// <param name="filePath">Parameter value to pass.</param>
    public static string[] LoadContracts(string filePath)
    {
        return Directory.GetFiles(filePath, "*.csv", SearchOption.AllDirectories);
    }


    public static void LoadContract(string saveName)
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Contracts/" + saveName + ".csv");
        string[] newString = sr.ReadToEnd().Split(new string[] { "\n" }, StringSplitOptions.None);
        Contract.Instance.ClearCurrentContractRules();
        for (int i = 1; i <= newString.Length - 1; i++)
        {
            string[] dataValues = newString[i].Split(',');
            Contract.Instance.AddRuleToContract(dataValues[0], dataValues[1]);
        }
        print(newString);
    }
}
