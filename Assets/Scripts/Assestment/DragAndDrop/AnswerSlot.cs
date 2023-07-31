using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerSlot : MonoBehaviour, IDropHandler
{
  
    public int id;
    private Image buttonImage;
    //public int numberOfCorrect;
    //public bool isCorrect;
    // public bool isDrop;

    [SerializeField] private GameObject firstLine;
    [SerializeField] private GameObject Fuse;

    private bool answerIsCorrect;


    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        
        
    }
    private void OnEnable()
    {
        Actions.onButtonImage += ButtonImage;
    }

    private void OnDisable()
    {
        Actions.onButtonImage -= ButtonImage;
    }

    public void OnDrop(PointerEventData eventData)
    {
       
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id == id)
            {
                answerIsCorrect = true;
                Debug.Log("Correct");
            }
            else
            {
                answerIsCorrect = false;       
            }

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Actions.onDropSoundEffect?.Invoke();
        }
    }

    private Image ButtonImage()
    {
        return buttonImage;
    }

    public void changeLineColors()
    {
        if (answerIsCorrect == true)
        {
            Fuse.SetActive(true);
            firstLine.SetActive(true);
        }
        else
        {
            firstLine.SetActive(false);
            Fuse.SetActive(false);
        }      
    }


}
