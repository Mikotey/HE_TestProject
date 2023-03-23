using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SpinLogic : MonoBehaviour
{
  public bool startSpinning;
  public float angularVelocity;
  public Vector3 axis;

  public bool isSpinning { get; private set; }

  RectTransform myTransform;

  public void ToggleSpinning()
  {
    isSpinning = !isSpinning;
  }

  void Start()
  {
    myTransform = GetComponent<RectTransform>();
    isSpinning = startSpinning;
  }

  
  void Update()
  {
    if (!isSpinning)
      return;

    myTransform.Rotate(axis, angularVelocity * Time.deltaTime);
  }
}
