using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraTracker cameraTracker;
    public Responner responnerPlayer;
    public Responner responnerEagle;
    public Responner responnerOpossum;

    public ItemDataManager itemDataManager;

    public List<Item> listItems;

    public GUIIventory guiIventory;

    public static GameManager instacne;


    private void Awake()
    {
        instacne = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        itemDataManager.Init();
        
        Iventory iventory = responnerPlayer.objPlayer.GetComponent<Iventory>();
        guiIventory.Set(iventory);

        iventory.InitChitItem(itemDataManager);

        for (int i = 0; i < listItems.Count; i++)
        {
            ItemData itemData = itemDataManager.Find(listItems[i].gameObject.name);
            listItems[i].ItemData = itemData;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTracker.objTarget == null)
        {
            cameraTracker.objTarget = responnerPlayer.objPlayer;
        }

        if(responnerEagle.objPlayer)
        {
            Eagle eagle = responnerEagle.objPlayer.GetComponent<Eagle>();
            if (eagle != null)
            {
                if(!eagle.trRetrunPoint) 
                    eagle.trRetrunPoint = responnerEagle.transform;
                if (!eagle.trPatrolPoint) 
                    eagle.trPatrolPoint = responnerOpossum.transform;
            }
        }
    }
}
