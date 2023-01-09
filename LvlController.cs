using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("Lvl_1");
    }
    public void Lvl2()
    {
        SceneManager.LoadScene("Lvl_2");
    }
    public void Lvl3()
    {
        SceneManager.LoadScene("Lvl_3");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Help()
    {
        SceneManager.LoadScene("Help");
    }
}
