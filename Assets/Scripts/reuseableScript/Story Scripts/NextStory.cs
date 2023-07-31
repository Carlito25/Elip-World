using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStory : MonoBehaviour
{
    [SerializeField] private GameObject currentSlide;
    [SerializeField] private GameObject nextStorySlide;
  

  
    public void nextSlide()
    {
        currentSlide.SetActive(false);
        nextStorySlide.SetActive(true);
        
    }

}
