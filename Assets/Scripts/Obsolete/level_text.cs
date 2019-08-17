using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level_text : MonoBehaviour
{
    public Text curlevel;
    // Start is called before the first frame update
    void Start()
    {
        string raw_level = SceneManager.GetActiveScene().name.ToString();
        string level = raw_level.Substring(0, raw_level.Length - 1) + " "+raw_level[raw_level.Length-1];
        curlevel.text = level;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}