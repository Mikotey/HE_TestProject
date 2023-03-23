using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ImageSlideshow))]
public class SwitchLogic : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
  public float cooldownTime = 5;
  public UnityEvent switchFlipped;

  bool switchActive = false;
  Vector3 startPos;
  ImageSlideshow mySwitchSprites;
  float timer = 0;

  void Start()
  {
    mySwitchSprites = GetComponent<ImageSlideshow>();
  }

  void Update()
  {
    if (switchActive == false)
      return;

    timer -= Time.deltaTime;

    if (timer <= 0)
    {
      mySwitchSprites.GoToSlide(0);
      switchActive = false;
    }
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    startPos = Input.mousePosition;
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    if (switchActive)
      return;

    switchActive = Input.mousePosition.y > startPos.y;
    if (switchActive)
    {
      mySwitchSprites.GoToSlide(1);
      timer = cooldownTime;
      switchFlipped?.Invoke();
    }
  }
}
