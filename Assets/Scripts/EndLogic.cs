using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class EndLogic : MonoBehaviour
{
  public NumberCounter[] numbersToListenTo;
  public int endCount = 10;
  public Action gameEndEvent;

  CanvasGroup myGameOverScreen;

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void Quit()
  {
    Application.Quit();
  }

  void Start()
  {
    //hide and don't block mouse interactions
    myGameOverScreen = GetComponent<CanvasGroup>();
    myGameOverScreen.alpha = 0;
    myGameOverScreen.blocksRaycasts = false;

    foreach (NumberCounter numberCounter in numbersToListenTo)
    {
      numberCounter.notifyListeners += CheckIfEnd;
    }
  }

  void CheckIfEnd(int newValue)
  {
    if (newValue == endCount)
      ShowGameOverScreen();
  }

  void OnDestroy()
  {
    foreach (NumberCounter numberCounter in numbersToListenTo)
    {
      numberCounter.notifyListeners -= CheckIfEnd;
    }
  }

  void ShowGameOverScreen()
  {
    myGameOverScreen.alpha = 1;
    myGameOverScreen.blocksRaycasts = true;
  }
}
