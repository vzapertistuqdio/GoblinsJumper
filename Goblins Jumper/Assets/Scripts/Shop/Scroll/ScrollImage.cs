using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollImage : MonoBehaviour,IObserver {

    
    private Iitem[] items1;
    private GameObject[] itemsObjects; 

    private IShopMode currentmode;

    private HatShopMode hatShopMode;
    private BodyShopMode bodyShopMode;

    [SerializeField] private Image itemImage;
    [SerializeField] private GameObject onj;

    private Shop shop;

    private List<Image> imagesList = new List<Image>();

    private RectTransform rectTransform;
    private float startObjPosition;

    private const float ITEM_OBJ_WIDTH = 100;
    private const float DISTANCE_BEHIND_ITEMS = 300;

    private Camera mainCamera;
    private float centerCameraX;

    private Image it;


    private void Start () {
        shop = GetComponent<Shop>();
        shop.RegisterObserver(this);

        hatShopMode = GetComponent<HatShopMode>();
        bodyShopMode = GetComponent<BodyShopMode>();

        rectTransform = onj.GetComponent<RectTransform>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
  
    }

    private void SpawnItemsOnScroll()
    {
        for (int i = 0; i < itemsObjects.Length; i++)
        {
            it = Instantiate(itemImage);
            it.transform.parent = onj.transform;
            it.GetComponent<Image>().sprite = itemsObjects[i].GetComponent<SpriteRenderer>().sprite;
            it.GetComponent<TriggerReaction>().id = i;
            imagesList.Add(it);
            it.transform.position = new Vector2(onj.transform.position.x - startObjPosition + ITEM_OBJ_WIDTH / 2 + i * DISTANCE_BEHIND_ITEMS, onj.transform.position.y);
        }
    }

    private void DrawScrollList()
    {
        centerCameraX = mainCamera.pixelWidth / 2;

        rectTransform.sizeDelta = new Vector2(itemsObjects.Length * DISTANCE_BEHIND_ITEMS - 200, rectTransform.sizeDelta.y);

        startObjPosition = rectTransform.sizeDelta.x / 2;

        onj.transform.position = new Vector2(centerCameraX + startObjPosition, onj.transform.position.y);
    }

    private void DeleteScrollList()
    {
        GameObject[] image = GameObject.FindGameObjectsWithTag("IconImage");
       
        for (int i=0;i<image.Length;i++)
        {
            Destroy(image[i]);     
        }    
    }

    public bool CheckImageInCenter()
    {
        int count = 0;
        foreach(Image img in imagesList)
        {
            if (img != null)
            {
                if (img.GetComponent<TriggerReaction>().isInCenter)
                {
                    count++;
                }
            }
        }
        if(count>0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public void UpdateObservers(IShopMode mode)
    {
        if (mode.GetType() == typeof(HatShopMode))
        {
            currentmode = hatShopMode;
        }
       if(mode.GetType() == typeof(BodyShopMode))
        {
            currentmode = bodyShopMode;
        }
        items1 = currentmode.GetItems();
        itemsObjects = new GameObject[items1.Length];
        for (int i=0;i<items1.Length;i++)
        {
            itemsObjects[i]= items1[i].GetObject();
        }
        DeleteScrollList();
        DrawScrollList();
        SpawnItemsOnScroll();
    }
}
