using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeText : MonoBehaviour
{
    public Text textLable;

    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        textLable.transform.position = namePos;
    }
}
