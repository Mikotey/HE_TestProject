using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NotifierBehavior<T> : MonoBehaviour
{
  public Action<T> notifyListeners { get; set; }
}
