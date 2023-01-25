using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuyBirdController : MonoBehaviour
{
    private UIDocument document;

    private Button buyBirdConfirmButton;
    private Button buyBirdBackButton;
    private Button newBirdContinueButton;
    private Button shopBirdButton;
    private Label newBirdNameLabel;
    private Label buyBirdInfoLabel;

    [SerializeField] private CameraController mainCamera;

    void Awake(){
        document = GetComponent<UIDocument>();

        buyBirdBackButton = document.rootVisualElement.Q<Button>("BuyBirdBackButton");
        buyBirdConfirmButton = document.rootVisualElement.Q<Button>("BuyBirdConfirmButton");
        newBirdContinueButton = document.rootVisualElement.Q<Button>("NewBirdContinueButton");
        shopBirdButton = document.rootVisualElement.Q<Button>("ShopBirdButton");
        newBirdNameLabel = document.rootVisualElement.Q<Label>("NewBirdNameLabel");
        buyBirdInfoLabel = document.rootVisualElement.Q<Label>("BuyBirdInfoLabel");

        buyBirdConfirmButton.clicked += () => {
            buyBird();
        };

        shopBirdButton.clicked += () => {
            reset();
        };

        newBirdContinueButton.clicked += () => {
            mainCamera.changeCameraPosition(CameraState.Default);
        };

        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
    }

    void Start(){
        reset();
    }

    void OnDestroy(){
        BirdManager.OnBirdStateChanged -= OnBirdStateChanged;
    }

    private void reset(){
        if (PlayerDataManager.gems >= 4 
                && BirdManager.instance.state == BirdState.Ready
                && BirdManager.instance.isNewBirdAvailable()){
            buyBirdConfirmButton.style.display = DisplayStyle.Flex;
        } else {
            buyBirdConfirmButton.style.display = DisplayStyle.None;
        }
        if (!BirdManager.instance.isNewBirdAvailable()){
            buyBirdInfoLabel.text = "You got all birds!"; 
        }
    }

    private void buyBird(){
        int i = BirdManager.instance.buyNewBird();
        mainCamera.changeCameraPosition(CameraState.Closeup);
        newBirdNameLabel.text=$"<u>{PredefinedData.birdNames[i]}</u>";
    }

    private void OnBirdStateChanged(BirdState birdState){
        if (BirdManager.instance.isNewBirdAvailable()){
            switch (birdState){
                case BirdState.Ready:
                    buyBirdInfoLabel.text = "Price: 4 gems"; 
                    break;
                case BirdState.Out:
                    buyBirdInfoLabel.text = "Bird must come back!"; 
                    break;
                case BirdState.GotLoot:
                    buyBirdInfoLabel.text = "Collect loot first!"; 
                    break;
            }
        }
    }
}
