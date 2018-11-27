using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerItem : MonoBehaviour {

    public bool visible    = false;
    public bool isSelected = false;
    public int layer;

    private Button expandButton;
    private Image hideIcon;
    private Image showIcon;


    // Use this for initialization
    void Start ()
    {
        if (layer < 3)
        {
            expandButton = this.transform.GetComponentInChildren<Button>();
            hideIcon = this.transform.Find("Hide").GetComponent<Image>();
            showIcon = this.transform.Find("Show").GetComponent<Image>();

            expandButton.onClick.AddListener(ExpandButtonClicked);

            hideIcon.enabled = !isSelected;
            showIcon.enabled = isSelected;
        }

        SetVisibility(visible);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This method will expand the next depth layer.
    /// </summary>
    /// <param name="value"></param>
    public void ExpandLayer(bool value)
    {
        hideIcon.enabled = !value;
        showIcon.enabled = value;
    }

    /// <summary>
    /// This method will set, wheather this item is currently selected/active or not. 
    /// Layer 3 items can not be expandable, so its just for layer 1 and 2.
    /// </summary>
    /// <param name="value"></param>
    public void SetSelected(bool value)
    {
        if (layer < 3)
        {
            isSelected = value;
            ExpandLayer(value);
        }   
    }

    /// <summary>
    /// This function will enable or disable the item prefab in hierarchy.
    /// </summary>
    /// <param name="value"></param>
    public void SetVisibility(bool value)
    {
        this.gameObject.SetActive(value);
    }

    /// <summary>
    /// Action, if youer tips on the item field.
    /// </summary>
    public void ExpandButtonClicked()
    {
        isSelected = !isSelected;

        HideElements(isSelected);
    }

    /// <summary>
    /// Given a start sibling index and a layer id, it will search for the next occurence of an item, with the same id as layer from start index.
    /// </summary>
    /// <param name="startIDX"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public int GetNextIndex(int startIDX, int layer)
    {
        int idx = -1;

        foreach (Transform item in this.transform.parent)
        {

            if (item.GetSiblingIndex() > startIDX)
            {
                if (item.tag.Equals("Layer"+layer))
                {
                    idx = item.GetSiblingIndex();
                    return idx;
                }
            }
        }
        return idx;
    }

    /// <summary>
    /// This method will hide elemens for either layer 1 or layer 2.
    /// </summary>
    /// <param name="value"></param>
    public void HideElements(bool value)
    {
        if (layer.Equals(1))
        {
            HandleLayer1(value);
        } else {
            HandleLayer2(value);
        }
    }

    /// <summary>
    /// Change layer visibility starting from layer 2.
    /// </summary>
    /// <param name="value"></param>
    public void HandleLayer2(bool value)
    {
        int ownIDX = this.transform.GetSiblingIndex();
        int endIDX = GetNextIndex(ownIDX, layer);

        // check layer 2 item, disable the icons
        foreach (Transform item in this.transform.parent)
        {
            LayerItem layertItem = item.GetComponent<LayerItem>();

            // deselect prevous clicked layers 2 items
            if (item.tag.Equals("Layer" + layer))
            {
                layertItem.SetSelected(false);
            }

            // unvisible
            if (item.tag.Equals("Layer" + (layer +1)))
            {
                layertItem.SetVisibility(false);
            }
        }

        // now set actual item to correct icon image
        SetSelected(value);

        // activate intervall data
        foreach (Transform item in this.transform.parent)
        {
            LayerItem layertItem = item.GetComponent<LayerItem>();

            if (((item.GetSiblingIndex() > ownIDX) && (item.GetSiblingIndex() < endIDX)) || ((item.GetSiblingIndex() > ownIDX) && (endIDX < 0)))
            {
                if (item.tag.Equals("Layer" + (layer + 1)))
                {
                    layertItem.SetVisibility(value);
                }
            }
        }
    }

    /// <summary>
    /// Change layer visibility starting from layer 1.
    /// </summary>
    /// <param name="value"></param>
    public void HandleLayer1(bool value)
    {
        int ownIDX = this.transform.GetSiblingIndex();
        int endIDX = GetNextIndex(ownIDX, layer);

        // activate all layer 1, disable others
        foreach (Transform item in this.transform.parent)
        {
            LayerItem layertItem = item.GetComponent<LayerItem>();

            if (item.tag.Equals("Layer" + layer))
            {
                layertItem.SetVisibility(true);
            }
            else
            {
                layertItem.SetVisibility(false);
            }

            layertItem.SetSelected(false);
        }

        // now set actual item to correct icon image
        SetSelected(value);

        // activate intervall data
        foreach (Transform item in this.transform.parent)
        {
            LayerItem layertItem = item.GetComponent<LayerItem>();

            if (((item.GetSiblingIndex() > ownIDX) && (item.GetSiblingIndex() < endIDX)) || ((item.GetSiblingIndex() > ownIDX) && (endIDX < 0)))
            {
                if (item.tag.Equals("Layer" + (layer + 1)))
                {
                    layertItem.SetVisibility(value);
                }
            }
        }
    }
}
