using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIRoot : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 50, 20), "用户名:");

    }
}
