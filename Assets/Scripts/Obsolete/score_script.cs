using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class score_script : MonoBehaviour
{
    public Stopwatch timer = new Stopwatch();
    public static double elapsed;
    public Text score;
    public static double best = 9999;

    
    // Start is called before the first frame update
    void Start()
    {
        timer.Start();    
    }

    // Update is called once per frame
    void Update()
    {
        elapsed = timer.Elapsed.TotalSeconds;
        string elapsedText = elapsed.ToString("F" +1);
        string bestText = best.ToString("F" + 1);
        if (best >= 9999)
            bestText = "0";
        score.text = "Elapsed:\t" + elapsedText + "\n"+
            "Best:\t" + bestText;
    }
}
