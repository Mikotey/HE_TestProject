using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NumberCounter : NotifierBehavior<int>
{
  public int initialCount;
  public int incrementValue;

  public int number { get; private set; }

  public void IncrementCount()
  {
    number += incrementValue;
    notifyListeners?.Invoke(number);
    return;
  }

  public void IncrementByAmount(int num)
  {
    number += num;
    notifyListeners?.Invoke(number);
    return;
  }

  void Start()
  {
    number = initialCount;
  }
}
