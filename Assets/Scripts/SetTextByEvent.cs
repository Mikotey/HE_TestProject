using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SetTextByEvent : MonoBehaviour
{
  public NotifierBehavior<int> listenTo;

  TextMeshProUGUI textToSet;


  void Start()
  {
    textToSet = GetComponent<TextMeshProUGUI>();
    listenTo.notifyListeners += SetTextEvent;
  }

  void SetTextEvent(int newValue)
  {
    textToSet.text = newValue.ToString();
  }

  private void OnDestroy()
  {
    listenTo.notifyListeners -= SetTextEvent;
  }
}
