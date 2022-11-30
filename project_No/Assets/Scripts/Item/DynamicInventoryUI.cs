using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicInventoryUI : InventoryUI
{
    [SerializeField]
    protected GameObject slotPrefab;

    [SerializeField]
    protected Vector2 start;

    [SerializeField]
    protected Vector2 size;

    [SerializeField]
    protected Vector2 space;

    [Min(1), SerializeField]
    protected int numberOfColum = 4;

    TextMeshProUGUI text;
    Player player;

    protected override void Start()
    {
        text = transform.Find("Gold").GetComponent<TextMeshProUGUI>();
        player = GameManager.Inst.MainPlayer;
    }
    private void Update()
    {
        text.text = $"¼ÒÁö°ñµå : {player.money}";
    }

    public override void CreateSlotUIs()
    {
        slotUIs = new Dictionary<GameObject, InventorySlot>();

        for(int i = 0; i < inventoryObject.Slots.Length; i++)
        {
            GameObject uiGo = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, transform);
            uiGo.GetComponent<RectTransform>().anchoredPosition = CalculatePosition(i);

            AddEvent(uiGo, EventTriggerType.PointerEnter, delegate { OnEnterSlot(uiGo); });
            AddEvent(uiGo, EventTriggerType.PointerExit, delegate { OnExitSlot(uiGo); });
            AddEvent(uiGo, EventTriggerType.BeginDrag, delegate { OnStartDrag(uiGo); });
            AddEvent(uiGo, EventTriggerType.EndDrag, delegate { OnEndDrag(uiGo); });
            AddEvent(uiGo, EventTriggerType.Drag, delegate { OnDrag(uiGo); });
            AddEvent(uiGo, EventTriggerType.PointerClick, (data) => { OnClick(uiGo, (PointerEventData)data); });

            inventoryObject.Slots[i].slotUI = uiGo;
            slotUIs.Add(uiGo, inventoryObject.Slots[i]);

            uiGo.name += ": " + i;
        }
    }

    public Vector3 CalculatePosition(int i)
    {
        float x = start.x + ((space.x + size.x) * (i % numberOfColum));
        float y = start.y + (-(space.y + size.y) * (i / numberOfColum));

        return new Vector3(x, y, 0.0f);
    }

    protected override void OnRightClick(InventorySlot slot)
    {
        inventoryObject.UseItem(slot);
    }


}
