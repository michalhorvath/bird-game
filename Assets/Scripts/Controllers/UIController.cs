using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private UIDocument document;

    private VisualElement homeScreen;
    private VisualElement menuScreen;
    private VisualElement settingsScreen;
    private VisualElement gemsScreen;
    private VisualElement shopScreen;
    private VisualElement birdMenu;

    private Button homeCoinsButton;
    private Button homeGemsButton;
    private Button homeShopButton;
    private Button homeMenuButton;
    private Button menuSettingsButton;
    private Button menuPhotoButton;
    private Button menuAlbumButton;
    private Button menuCatalogButton;
    private Button menuBackButton;
    private Button settingsBackButton;
    private Button gemsBackButton;
    private Button shopBackButton;
    private Button birdPetButton;
    private Button birdSendButton;
    private Button birdTrainButton;
    private Button birdMenuCloseButton;
    private Button birdMenuOpenButton;

    private Label homeBirdTimer;

    void Awake() {
        document = GetComponent<UIDocument>();

        homeScreen = document.rootVisualElement.Q<VisualElement>("HomeScreen");
        birdMenu = document.rootVisualElement.Q<VisualElement>("BirdMenu");
        menuScreen = document.rootVisualElement.Q<VisualElement>("MenuScreen");
        settingsScreen = document.rootVisualElement.Q<VisualElement>("SettingsScreen");
        gemsScreen = document.rootVisualElement.Q<VisualElement>("GemsScreen");
        shopScreen = document.rootVisualElement.Q<VisualElement>("ShopScreen");
        
        homeCoinsButton = document.rootVisualElement.Q<Button>("HomeCoinsButton");
        homeGemsButton = document.rootVisualElement.Q<Button>("HomeGemsButton");
        homeShopButton = document.rootVisualElement.Q<Button>("HomeShopButton");
        homeMenuButton = document.rootVisualElement.Q<Button>("HomeMenuButton");
        menuSettingsButton = document.rootVisualElement.Q<Button>("MenuSettingsButton");
        menuPhotoButton = document.rootVisualElement.Q<Button>("MenuPhotoButton");
        menuAlbumButton = document.rootVisualElement.Q<Button>("MenuAlbumButton");
        menuCatalogButton = document.rootVisualElement.Q<Button>("MenuCatalogButton");
        menuBackButton = document.rootVisualElement.Q<Button>("MenuBackButton");
        settingsBackButton = document.rootVisualElement.Q<Button>("SettingsBackButton");
        gemsBackButton = document.rootVisualElement.Q<Button>("GemsBackButton");
        shopBackButton = document.rootVisualElement.Q<Button>("ShopBackButton");
        birdPetButton = document.rootVisualElement.Q<Button>("BirdPetButton");
        birdSendButton = document.rootVisualElement.Q<Button>("BirdSendButton");
        birdTrainButton = document.rootVisualElement.Q<Button>("BirdTrainButton");
        birdMenuCloseButton = document.rootVisualElement.Q<Button>("BirdMenuCloseButton");
        birdMenuOpenButton = document.rootVisualElement.Q<Button>("BirdMenuOpenButton");

        homeBirdTimer = document.rootVisualElement.Q<Label>("HomeBirdTimer");

        homeMenuButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            menuScreen.style.display = DisplayStyle.Flex;

            birdMenuOpenButton.style.display = DisplayStyle.Flex;
            birdMenu.style.display = DisplayStyle.None;
        };

        menuBackButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.Flex;
            menuScreen.style.display = DisplayStyle.None;
        };

        menuSettingsButton.clicked += () => {
            settingsScreen.style.display = DisplayStyle.Flex;
            menuScreen.style.display = DisplayStyle.None;
        };

        settingsBackButton.clicked += () => {
            settingsScreen.style.display = DisplayStyle.None;
            menuScreen.style.display = DisplayStyle.Flex;
        };

        homeGemsButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            gemsScreen.style.display = DisplayStyle.Flex;

            birdMenuOpenButton.style.display = DisplayStyle.Flex;
            birdMenu.style.display = DisplayStyle.None;
        };

        homeCoinsButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            gemsScreen.style.display = DisplayStyle.Flex;

            birdMenuOpenButton.style.display = DisplayStyle.Flex;
            birdMenu.style.display = DisplayStyle.None;
        };

        gemsBackButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.Flex;
            gemsScreen.style.display = DisplayStyle.None;
        };

        homeShopButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            shopScreen.style.display = DisplayStyle.Flex;

            birdMenuOpenButton.style.display = DisplayStyle.Flex;
            birdMenu.style.display = DisplayStyle.None;
        };

        shopBackButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.Flex;
            shopScreen.style.display = DisplayStyle.None;
        };

        birdMenuOpenButton.clicked += () => {
            birdMenuOpenButton.style.display = DisplayStyle.None;
            birdMenu.style.display = DisplayStyle.Flex;
        };

        birdMenuCloseButton.clicked += () => {
            birdMenuOpenButton.style.display = DisplayStyle.Flex;
            birdMenu.style.display = DisplayStyle.None;
        };



        birdSendButton.clicked += () => {
            BirdManager.instance.sendBirdOut();
        };


        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
    }

    private void OnBirdStateChanged(BirdState birdState){
        switch (birdState){
            case BirdState.Ready:
                birdMenu.style.display = DisplayStyle.None;
                homeBirdTimer.style.display = DisplayStyle.None;
                birdMenuOpenButton.style.display = DisplayStyle.Flex;
                break;
            case BirdState.Out:
                birdMenu.style.display = DisplayStyle.None;
                homeBirdTimer.style.display = DisplayStyle.Flex;
                birdMenuOpenButton.style.display = DisplayStyle.None;
                break;
         }
     }

}
