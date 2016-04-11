using UnityEngine;
using System.Collections;

public class HelpClass : MonoBehaviour {
    public static bool IsArrayEqual(bool[] a, bool[] b)
    {
        if (a == null) Debug.LogError("fck you");
        if (a.Length != b.Length)
            return false;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }
}
