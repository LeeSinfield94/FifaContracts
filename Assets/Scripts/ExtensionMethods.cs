using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class ExtensionMethods
{
    public static void ResetInputField(this TMP_InputField inputField)
    {
        inputField.text = "";
    }
}
