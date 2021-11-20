using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Lang
{
    public static string usedLanguage;
    public static Dictionary<string, Dictionary<string, string>> dictionaries; //[id] = ([id] = String)

    public static string Get(string key)
    {
        bool hasLanguage = dictionaries.ContainsKey(usedLanguage);
        if (!hasLanguage)
        {
            //return self
            Debug.LogWarning($"Used language not included in dictionary : {usedLanguage}");
            return key;
        }
        string value = "xnullx";
        bool hasValue = dictionaries[usedLanguage].TryGetValue(key, out value);
        if (!hasValue)
        {
            //return self
            Debug.LogWarning($"Key not found in dictionary ( usedLang : {usedLanguage}, key : {key} )");
            return key;
        }
        return value;
    }

    public static string Get(string key, params object[] format)
    {
        return string.Format(Get(key), format);
    }
}

public class TranslatableText
{
    string key;

    public TranslatableText(string key)
    {
        this.key = key;
    }

    public string Get() => Lang.Get(key);

    public static implicit operator string(TranslatableText tt) => Lang.Get(tt.key);
}
