using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIIventory : MonoBehaviour
{
    public List<GameObject> listGUIItemButtons;
    public GridLayoutGroup gridLayoutGroup;
    public void Set(Iventory iventory)
    {
        foreach (var button in listGUIItemButtons)
        {
            GameObject prefabButton = Resources.Load<GameObject>("ItemButton");
            GameObject objButton = Instantiate(prefabButton,gridLayoutGroup.transform);
            GUIItemButton guiItemButton = objButton.GetComponent<GUIItemButton>();
            Button btnButton = objButton.GetComponent<Button>();
            btnButton.onClick.AddListener(() => { guiItemButton.EventClick(iventory.gameObject); });
            listGUIItemButtons.Add(objButton);
        }
    }

    public void Clear()
    {
        foreach( var item in listGUIItemButtons)
        {
            listGUIItemButtons.Remove(item);
        }
        listGUIItemButtons.Clear();
    }

    public Iventory Iventory;

    private void Awake()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Set(Iventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
