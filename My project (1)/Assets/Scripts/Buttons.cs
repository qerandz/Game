using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject bhik;
    public void show ()
    {
        bhik.SetActive(true);
        Time.timeScale = 0f;
    }
    public void con()
    {
        Time.timeScale = 1f;
        bhik.SetActive(false);
    }

    public void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ex()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }
    public void mex()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
}
