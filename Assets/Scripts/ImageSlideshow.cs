using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageSlideshow : MonoBehaviour
{
  public Sprite[] imageSlides;

  Image myImageComponent;

  public void GoToSlide(int slideNum)
  {
    if (slideNum < 0 || slideNum > imageSlides.Length)
    {
      Debug.LogError("ERROR: attempting to access a slide index outside the imageSlides array: " + slideNum);
      return;
    }

    myImageComponent.sprite = imageSlides[slideNum]; 
  }
  
  void Start()
  {
    myImageComponent = GetComponent<Image>();
  }
}
