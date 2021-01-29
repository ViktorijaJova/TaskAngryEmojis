using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Button start;


    void Start()
    {
        start.onClick.AddListener(() => Restart());

    }


    public void Restart()
    {
        SceneManager.LoadScene("Mainlevel");
    }

   
}
