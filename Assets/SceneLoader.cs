using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  int currentScene = 0;

  void Awake()
  {
    currentScene = SceneManager.GetActiveScene().buildIndex;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.P))
    {
      DoRestart();
    }

  }

  public void DoRestart()
  {
    SceneManager.LoadScene(currentScene);
  }
}
