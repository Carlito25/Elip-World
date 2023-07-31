using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //AnswerSlot answerslot;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 resetPosition;
   

    public int id;
    private void Awake()
    {
       //answerslot = GameObject.Find("firstAnswerSlot").GetComponent<AnswerSlot>();
        
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }
    private void Start()
    {
        resetPosition = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Actions.onClickSoundEffect?.Invoke();
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {  
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        //if (answerslot.isDrop == false)
        //{
        //    buttonResetPosition();
        //}
        //else
        //{
        //    Debug.Log("On Drop - drag and drop script");
        //    answerslot.isDrop = false; // if button is drop, it will back to false
        //}
    }

   
    public void buttonResetPosition()
    {
        // this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        transform.position = resetPosition;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
     
    }

    

}
