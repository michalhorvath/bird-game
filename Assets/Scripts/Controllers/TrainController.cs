using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainController : MonoBehaviour
{
    private UIDocument document;

    private Button trainSkill0Button;
    private Label trainSkill0Stars;
    private Button trainSkill1Button;
    private Label trainSkill1Stars;
    private Button trainSkill2Button;
    private Label trainSkill2Stars;

    private Button trainConfirmButton;
    private Button trainBackButton;
    private Label trainSkillPrice;

    private Button birdTrainButton;

    private int selectedSkill = 0;

    private int[] skillCost = {1, 2, 3, 4, 5};

    void Awake(){
        document = GetComponent<UIDocument>();

        trainSkill0Button = document.rootVisualElement.Q<Button>("TrainSkill0Button");
        trainSkill0Stars = document.rootVisualElement.Q<Label>("TrainSkill0Stars");
        trainSkill1Button = document.rootVisualElement.Q<Button>("TrainSkill1Button");
        trainSkill1Stars = document.rootVisualElement.Q<Label>("TrainSkill1Stars");
        trainSkill2Button = document.rootVisualElement.Q<Button>("TrainSkill2Button");
        trainSkill2Stars = document.rootVisualElement.Q<Label>("TrainSkill2Stars");

        trainConfirmButton = document.rootVisualElement.Q<Button>("TrainConfirmButton");
        trainBackButton = document.rootVisualElement.Q<Button>("TrainBackButton");
        trainSkillPrice = document.rootVisualElement.Q<Label>("TrainSkillPrice");

        birdTrainButton = document.rootVisualElement.Q<Button>("BirdTrainButton");

        trainBackButton.clicked += () => {
            reset();
        };

        trainSkill0Button.clicked += () => {
            selectSkill(0, trainSkill0Button);
        };

        trainSkill1Button.clicked += () => {
            selectSkill(1, trainSkill1Button);
        };

        trainSkill2Button.clicked += () => {
            selectSkill(2, trainSkill2Button);
        };

        trainConfirmButton.clicked += () => {
            confirmSkill();
        };

        birdTrainButton.clicked += () => {
            reset();
        };
    }

    void Start(){
        reset();
    }

    private void reset(){
        selectSkill(-1, null);
        trainConfirmButton.style.display = DisplayStyle.None;
        trainSkill0Stars.text = 
            new String('★', PlayerDataManager.getActiveBird().skills[0]);
        trainSkill1Stars.text = 
            new String('★', PlayerDataManager.getActiveBird().skills[1]);
        trainSkill2Stars.text = 
            new String('★', PlayerDataManager.getActiveBird().skills[2]);
        trainSkillPrice.text = "Price: ";

        if (PlayerDataManager.getActiveBird().skills[0] < 5){
            trainSkill0Button.style.display = DisplayStyle.Flex;
        } else {
            trainSkill0Button.style.display = DisplayStyle.None;
        }
        if (PlayerDataManager.getActiveBird().skills[1] < 5){
            trainSkill1Button.style.display = DisplayStyle.Flex;
        } else {
            trainSkill1Button.style.display = DisplayStyle.None;
        }
        if (PlayerDataManager.getActiveBird().skills[2] < 5){
            trainSkill2Button.style.display = DisplayStyle.Flex;
        } else {
            trainSkill2Button.style.display = DisplayStyle.None;
        }
    }

    private void selectSkill(int i, Button clickedButton){
        cleanButtonColors();
        selectedSkill = i;

        if (i != -1){
            int selectedSkillCost = 
                skillCost[PlayerDataManager.getActiveBird().skills[i]];
            trainSkillPrice.text = "Price: " 
                + selectedSkillCost
                + " gems ";

            if (selectedSkillCost <= PlayerDataManager.gems){
                trainConfirmButton.style.display = DisplayStyle.Flex; 
            }
        }


        if (clickedButton != null) {
            clickedButton.RemoveFromClassList("selectColor");
            clickedButton.AddToClassList("selectedColor");
        }
    }

    private void cleanButtonColors(){
        trainSkill0Button.RemoveFromClassList("selectedColor");
        trainSkill0Button.AddToClassList("selectColor");
        trainSkill1Button.RemoveFromClassList("selectedColor");
        trainSkill1Button.AddToClassList("selectColor");
        trainSkill2Button.RemoveFromClassList("selectedColor");
        trainSkill2Button.AddToClassList("selectColor");
    }

    private void confirmSkill(){
        if (selectedSkill != -1){
            trainSkill(selectedSkill);
        }
    }

    private void trainSkill(int i){
        int selectedSkillCost = 
            skillCost[PlayerDataManager.getActiveBird().skills[i]];
        PlayerDataManager.gems -= selectedSkillCost;

        PlayerDataManager.getActiveBird().skills[i] += 1;
        PlayerDataManager.Instance.playerDataChanged();

        reset();
    }
}
