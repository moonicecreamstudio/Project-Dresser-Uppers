using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public TextMeshProUGUI countText;

    [HideInInspector] public Item item;
    [HideInInspector] public ItemType itemType;
    [HideInInspector] public float baseDefenceStat;
    [HideInInspector] public float fireDefenceStat;
    [HideInInspector] public float waterDefenceStat;
    [HideInInspector] public float grassDefenceStat;

    [HideInInspector] public float baseAttackStat;
    [HideInInspector] public float fireAttackStat;
    [HideInInspector] public float waterAttackStat;
    [HideInInspector] public float grassAttackStat;

    [HideInInspector] public Material material;
    [HideInInspector] public Sprite display2DOutfit;

    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentBeforeDrag;

    // Camera
    [HideInInspector] public Camera cam;
    Vector3 point = new Vector3();
    Vector2 mousePos = new Vector2();

    void Start()
    {
        cam = Camera.main;
    }

    public void IntialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        itemType = newItem.itemType;
        baseDefenceStat = newItem.baseDefenceStat;
        fireDefenceStat = newItem.fireDefenceStat;
        waterDefenceStat = newItem.waterDefenceStat;
        grassDefenceStat = newItem.grassDefenceStat;
        baseAttackStat = newItem.baseAttackStat;
        fireAttackStat = newItem.fireAttackStat;
        waterAttackStat = newItem.waterAttackStat;
        grassAttackStat = newItem.grassAttackStat;
        material = newItem.material;
        display2DOutfit = newItem.display2DOutfit;

        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        parentBeforeDrag = transform.parent;
        transform.SetParent(transform.root);

        TelemetryLogger.Log(this, "Click: On Item", new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 52.11f));

        transform.position = point;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
