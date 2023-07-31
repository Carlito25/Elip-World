using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleManagement : MonoBehaviour
{
    [SerializeField] private GameObject firstOutpostItems;
    [SerializeField] private GameObject secondOutpostItems;
    [SerializeField] private GameObject thirdOutpostItems;
    [SerializeField] private GameObject fourthOutpostItems;
    [SerializeField] private GameObject fifthOutpostItems;

   
    void Update()
    {
        if (Actions.onGetCollectibles?.Invoke() == 5)
        {
            secondOutpostItems.SetActive(true);
        }
        else if (Actions.onGetCollectibles?.Invoke() == 10)
        {
            thirdOutpostItems.SetActive(true);
        }
        else if (Actions.onGetCollectibles?.Invoke() == 15)
        {
            fourthOutpostItems.SetActive(true);
        }
        else if (Actions.onGetCollectibles?.Invoke() == 20)
        {
            fifthOutpostItems.SetActive(true);
        }
        
    }
}
