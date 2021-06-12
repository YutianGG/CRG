using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("分數")]
    public static float score;
    [Header("分數文字")]
    public Text tscore;

    private void Awake()
    {
        score = 0;
    }
    
    private void Update()
    {
        AddScore(Mathf.Ceil(Time.time*0.1f));
    }
    public void AddScore(float add)
    {
        score += add;                           
        tscore.text = "分數：" + score;       
    }

}
