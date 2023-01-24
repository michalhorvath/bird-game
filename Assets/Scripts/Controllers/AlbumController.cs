using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AlbumController : MonoBehaviour
{
    private UIDocument document;

    private VisualElement birdAlbumScreen;
    private VisualElement birdDetailsScreen;
    private VisualElement homeScreen;

    private VisualElement birdAlbumCells;
    private Button menuAlbumButton;

    private Label birdDetailsNameLabel;
    private Button birdDetailsCell;
    private Label birdDetailsSkill0Stars;
    private Label birdDetailsSkill1Stars;
    private Label birdDetailsSkill2Stars;
    private Button birdDetailsPickButton;

    private Button[] cells;

    void Awake(){
        document = GetComponent<UIDocument>();

        birdAlbumScreen = 
            document.rootVisualElement.Q<VisualElement>("BirdAlbumScreen");
        birdDetailsScreen = 
            document.rootVisualElement.Q<VisualElement>("BirdDetailsScreen");
        homeScreen = 
            document.rootVisualElement.Q<VisualElement>("HomeScreen");

        menuAlbumButton = 
            document.rootVisualElement.Q<Button>("MenuAlbumButton");
        birdAlbumCells = 
            document.rootVisualElement.Q<VisualElement>("BirdAlbumCells");

        birdDetailsNameLabel = 
            document.rootVisualElement.Q<Label>("BirdDetailsNameLabel");
        birdDetailsCell = 
            document.rootVisualElement.Q<Button>("BirdDetailsCell");
        birdDetailsSkill0Stars = 
            document.rootVisualElement.Q<Label>("BirdDetailsSkill0Stars");
        birdDetailsSkill1Stars = 
            document.rootVisualElement.Q<Label>("BirdDetailsSkill1Stars");
        birdDetailsSkill2Stars = 
            document.rootVisualElement.Q<Label>("BirdDetailsSkill2Stars");
        birdDetailsPickButton = 
            document.rootVisualElement.Q<Button>("BirdDetailsPickButton");

        menuAlbumButton.clicked += () => {
            reset();
        };
    }

    void Start(){
    }

    private void reset(){
        resetButtons();
    }

    private void resetButtons(){
        BirdData[] birdData = PlayerDataManager.getBirdData();

        cells = new Button[birdData.Length];
        birdAlbumCells.Clear();

        for(int i=0; i<birdData.Length; i++){
            Button newCell = new Button();
            newCell.AddToClassList("albumCell");
            if (birdData[i].isBought){
                newCell.text = ""+birdData[i].id;
                newCell.clicked += showBirdDetails(birdData[i]);
            } else {
                newCell.text = "?";
                newCell.AddToClassList("grayColor");
            }

            cells[i] = newCell;
            birdAlbumCells.Add(newCell);
        }
    }

    private Action showBirdDetails(BirdData birdData){
        return () => {
            birdAlbumScreen.style.display = DisplayStyle.None;
            birdDetailsScreen.style.display = DisplayStyle.Flex;
            resetBirdDetail(birdData);
        };
    }

    private void resetBirdDetail(BirdData birdData){
        birdDetailsCell.text = ""+birdData.id;
        birdDetailsSkill0Stars.text =
            new String('★', birdData.skills[0]);
        birdDetailsSkill1Stars.text =
            new String('★', birdData.skills[1]);
        birdDetailsSkill2Stars.text =
            new String('★', birdData.skills[2]);
        birdDetailsPickButton.clickable = null;
        birdDetailsPickButton.RemoveFromClassList("grayColor");
        if (BirdManager.instance.state == BirdState.Ready){
            birdDetailsPickButton.clicked += () => {
                BirdManager.instance.setActiveBird(birdData.id);
                birdDetailsScreen.style.display = DisplayStyle.None;
                homeScreen.style.display = DisplayStyle.Flex;
            };
        } else {
            birdDetailsPickButton.AddToClassList("grayColor");
        }
    }
}
