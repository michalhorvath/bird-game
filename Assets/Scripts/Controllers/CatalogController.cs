using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CatalogController : MonoBehaviour
{
    private UIDocument document;

    private VisualElement itemCatalogScreen;
    private VisualElement itemDetailsScreen;
    private VisualElement homeScreen;

    private VisualElement itemCatalogCells;
    private Button menuAlbumButton;

    private Label itemDetailsNameLabel;
    private Button itemDetailsCell;
    private Label itemDetailsSkill0Stars;
    private Label itemDetailsSkill1Stars;
    private Label itemDetailsSkill2Stars;
    private Button itemDetailsPickButton;

    private Button[] cells;

    void Awake(){
        document = GetComponent<UIDocument>();

        itemCatalogScreen =
            document.rootVisualElement.Q<VisualElement>("ItemCatalogScreen");
        itemDetailsScreen =
            document.rootVisualElement.Q<VisualElement>("ItemDetailsScreen");
        homeScreen =
            document.rootVisualElement.Q<VisualElement>("HomeScreen");

        menuAlbumButton =
            document.rootVisualElement.Q<Button>("MenuAlbumButton");
        itemCatalogCells =
            document.rootVisualElement.Q<VisualElement>("ItemCatalogCells");

        itemDetailsNameLabel =
            document.rootVisualElement.Q<Label>("ItemDetailsNameLabel");
        itemDetailsCell =
            document.rootVisualElement.Q<Button>("ItemDetailsCell");
        itemDetailsSkill0Stars =
            document.rootVisualElement.Q<Label>("ItemDetailsSkill0Stars");
        itemDetailsSkill1Stars =
            document.rootVisualElement.Q<Label>("ItemDetailsSkill1Stars");
        itemDetailsSkill2Stars =
            document.rootVisualElement.Q<Label>("ItemDetailsSkill2Stars");
        itemDetailsPickButton =
            document.rootVisualElement.Q<Button>("ItemDetailsPickButton");

        menuAlbumButton.clicked += () => {
            reset();
        };
    }

    void Start(){
        reset();
    }

    private void reset(){
        resetButtons();
    }

    private void resetButtons(){
        ItemData[] itemData = PlayerDataManager.getItemData();

        cells = new Button[itemData.Length];
        itemCatalogCells.Clear();

        for(int i=0; i<itemData.Length; i++){
            Button newCell = new Button();
            newCell.AddToClassList("albumCell");
            if (itemData[i].isFound){
                newCell.text = ""+itemData[i].id;
                newCell.clicked += showItemDetails(itemData[i]);
            } else {
                newCell.text = "?";
                newCell.AddToClassList("grayColor");
            }

            cells[i] = newCell;
            itemCatalogCells.Add(newCell);
        }
    }

    private Action showItemDetails(ItemData itemData){
        return () => {
            itemCatalogScreen.style.display = DisplayStyle.None;
            itemDetailsScreen.style.display = DisplayStyle.Flex;
            resetItemDetail(itemData);
        };
    }

    private void resetItemDetail(ItemData itemData){
        itemDetailsCell.text = ""+itemData.id;
    }
}
