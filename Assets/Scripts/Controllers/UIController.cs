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
    private VisualElement lootMenu;
    private VisualElement skipMenu;
    private VisualElement currencyTopBar;
    private VisualElement trainScreen;
    private VisualElement buyBirdScreen;
    private VisualElement newBirdScreen;
    private VisualElement birdAlbumScreen;
    private VisualElement birdDetailsScreen;

    private Button homeCoinsButton;
    private Button homeGemsButton;
    private Button homeShopButton;
    private Button homeMenuButton;
    private Button homeSkipButton;
    private Button menuSettingsButton;
    private Button menuPhotoButton;
    private Button menuAlbumButton;
    private Button birdAlbumBackButton;
    private Button birdDetailsBackButton;
    private Button menuCatalogButton;
    private Button menuBackButton;
    private Button settingsBackButton;
    private Button gemsBackButton;
    private Button gemsG2CButton;
    private Button gemsC2GButton;
    private Button gemsM2GButton;
    private Button shopBackButton;
    private Button shopBirdButton;
    private Button birdPetButton;
    private Button birdSendButton;
    private Button birdTrainButton;
    private Button birdMenuCloseButton;
    private Button birdMenuOpenButton;
    private Button birdMenuTrainButton;
    private Button birdMenuPetButton;
    private Button lootMenuClaimButton;
    private Button skipMenuWatchButton;
    private Button skipMenuPayButton;
    private Button skipMenuBackButton;
    private Button trainBackButton;
    private Button buyBirdBackButton;
    private Button buyBirdConfirmButton;
    private Button newBirdContinueButton;

    private Label homeBirdTimer;
    private Label lootMenuPreviewCoins;

    void Awake() {
        document = GetComponent<UIDocument>();

        homeScreen = document.rootVisualElement.Q<VisualElement>("HomeScreen");
        menuScreen = document.rootVisualElement.Q<VisualElement>("MenuScreen");
        settingsScreen = document.rootVisualElement.Q<VisualElement>("SettingsScreen");
        gemsScreen = document.rootVisualElement.Q<VisualElement>("GemsScreen");
        shopScreen = document.rootVisualElement.Q<VisualElement>("ShopScreen");
        birdMenu = document.rootVisualElement.Q<VisualElement>("BirdMenu");
        lootMenu = document.rootVisualElement.Q<VisualElement>("LootMenu");
        skipMenu = document.rootVisualElement.Q<VisualElement>("SkipMenu");
        currencyTopBar = document.rootVisualElement.Q<VisualElement>("CurrencyTopBar");
        trainScreen = document.rootVisualElement.Q<VisualElement>("TrainScreen");
        buyBirdScreen = document.rootVisualElement.Q<VisualElement>("BuyBirdScreen");
        newBirdScreen = document.rootVisualElement.Q<VisualElement>("NewBirdScreen");
        birdAlbumScreen = document.rootVisualElement.Q<VisualElement>("BirdAlbumScreen");
        birdDetailsScreen = document.rootVisualElement.Q<VisualElement>("BirdDetailsScreen");
        
        homeCoinsButton = document.rootVisualElement.Q<Button>("HomeCoinsButton");
        homeGemsButton = document.rootVisualElement.Q<Button>("HomeGemsButton");
        homeShopButton = document.rootVisualElement.Q<Button>("HomeShopButton");
        homeMenuButton = document.rootVisualElement.Q<Button>("HomeMenuButton");
        homeSkipButton = document.rootVisualElement.Q<Button>("HomeSkipButton");
        menuSettingsButton = document.rootVisualElement.Q<Button>("MenuSettingsButton");
        menuPhotoButton = document.rootVisualElement.Q<Button>("MenuPhotoButton");
        menuAlbumButton = document.rootVisualElement.Q<Button>("MenuAlbumButton");
        birdAlbumBackButton = document.rootVisualElement.Q<Button>("BirdAlbumBackButton");
        birdDetailsBackButton = document.rootVisualElement.Q<Button>("BirdDetailsBackButton");
        menuCatalogButton = document.rootVisualElement.Q<Button>("MenuCatalogButton");
        menuBackButton = document.rootVisualElement.Q<Button>("MenuBackButton");
        settingsBackButton = document.rootVisualElement.Q<Button>("SettingsBackButton");
        gemsBackButton = document.rootVisualElement.Q<Button>("GemsBackButton");
        gemsG2CButton = document.rootVisualElement.Q<Button>("GemsG2CButton");
        gemsC2GButton = document.rootVisualElement.Q<Button>("GemsC2GButton");
        gemsM2GButton = document.rootVisualElement.Q<Button>("GemsM2GButton");
        shopBackButton = document.rootVisualElement.Q<Button>("ShopBackButton");
        shopBirdButton = document.rootVisualElement.Q<Button>("ShopBirdButton");
        birdPetButton = document.rootVisualElement.Q<Button>("BirdPetButton");
        birdSendButton = document.rootVisualElement.Q<Button>("BirdSendButton");
        birdTrainButton = document.rootVisualElement.Q<Button>("BirdTrainButton");
        birdMenuCloseButton = document.rootVisualElement.Q<Button>("BirdMenuCloseButton");
        birdMenuOpenButton = document.rootVisualElement.Q<Button>("BirdMenuOpenButton");
        birdMenuTrainButton = document.rootVisualElement.Q<Button>("BirdMenuTrainButton");
        birdMenuPetButton = document.rootVisualElement.Q<Button>("BirdMenuPetButton");
        lootMenuClaimButton = document.rootVisualElement.Q<Button>("LootMenuClaimButton");
        skipMenuWatchButton = document.rootVisualElement.Q<Button>("SkipMenuWatchButton");
        skipMenuPayButton = document.rootVisualElement.Q<Button>("SkipMenuPayButton");
        skipMenuBackButton = document.rootVisualElement.Q<Button>("SkipMenuBackButton");
        trainBackButton = document.rootVisualElement.Q<Button>("TrainBackButton");
        buyBirdBackButton = document.rootVisualElement.Q<Button>("BuyBirdBackButton");
        buyBirdConfirmButton = document.rootVisualElement.Q<Button>("BuyBirdConfirmButton");
        newBirdContinueButton = document.rootVisualElement.Q<Button>("NewBirdContinueButton");

        homeBirdTimer = document.rootVisualElement.Q<Label>("HomeBirdTimer");
        lootMenuPreviewCoins = document.rootVisualElement.Q<Label>("LootMenuPreviewCoins");

        homeMenuButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            menuScreen.style.display = DisplayStyle.Flex;
        };

        menuBackButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.Flex;
            menuScreen.style.display = DisplayStyle.None;
        };

        menuSettingsButton.clicked += () => {
            settingsScreen.style.display = DisplayStyle.Flex;
            menuScreen.style.display = DisplayStyle.None;
        };

        menuAlbumButton.clicked += () => {
            birdAlbumScreen.style.display = DisplayStyle.Flex;
            menuScreen.style.display = DisplayStyle.None;
        };

        birdAlbumBackButton.clicked += () => {
            birdAlbumScreen.style.display = DisplayStyle.None;
            menuScreen.style.display = DisplayStyle.Flex;
        };

        birdDetailsBackButton.clicked += () => {
            birdAlbumScreen.style.display = DisplayStyle.Flex;
            birdDetailsScreen.style.display = DisplayStyle.None;
        };

        settingsBackButton.clicked += () => {
            settingsScreen.style.display = DisplayStyle.None;
            menuScreen.style.display = DisplayStyle.Flex;
        };

        homeGemsButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            gemsScreen.style.display = DisplayStyle.Flex;
            currencyTopBar.style.display = DisplayStyle.Flex;
        };

        homeCoinsButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            gemsScreen.style.display = DisplayStyle.Flex;
            currencyTopBar.style.display = DisplayStyle.Flex;
        };

        gemsG2CButton.clicked += () => {
            TradeManager.instance.tradeG2C(1, 100);
        };

        gemsC2GButton.clicked += () => {
            TradeManager.instance.tradeC2G(120, 1);
        };

        gemsM2GButton.clicked += () => {
            TradeManager.instance.tradeC2G(0, 3);
        };

        gemsBackButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.Flex;
            gemsScreen.style.display = DisplayStyle.None;
            currencyTopBar.style.display = DisplayStyle.None;
        };

        homeShopButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            shopScreen.style.display = DisplayStyle.Flex;
        };

        shopBackButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.Flex;
            shopScreen.style.display = DisplayStyle.None;
        };

        shopBirdButton.clicked += () => {
            buyBirdScreen.style.display = DisplayStyle.Flex;
            shopScreen.style.display = DisplayStyle.None;
            currencyTopBar.style.display = DisplayStyle.Flex;
        };

        buyBirdBackButton.clicked += () => {
            buyBirdScreen.style.display = DisplayStyle.None;
            shopScreen.style.display = DisplayStyle.Flex;
            currencyTopBar.style.display = DisplayStyle.None;
        };

        buyBirdConfirmButton.clicked += () => {
            buyBirdScreen.style.display = DisplayStyle.None;
            newBirdScreen.style.display = DisplayStyle.Flex;
            currencyTopBar.style.display = DisplayStyle.None;
        };

        newBirdContinueButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.Flex;
            newBirdScreen.style.display = DisplayStyle.None;
        };

        birdMenuOpenButton.clicked += () => {
            birdMenuOpenButton.style.display = DisplayStyle.None;
            birdMenu.style.display = DisplayStyle.Flex;
        };

        birdMenuCloseButton.clicked += () => {
            birdMenuOpenButton.style.display = DisplayStyle.Flex;
            birdMenu.style.display = DisplayStyle.None;
        };

        homeSkipButton.clicked += () => {
            skipMenu.style.display = DisplayStyle.Flex;
            homeSkipButton.style.display = DisplayStyle.None;
        };

        skipMenuBackButton.clicked += () => {
            skipMenu.style.display = DisplayStyle.None;
            homeSkipButton.style.display = DisplayStyle.Flex;
        };

        skipMenuWatchButton.clicked += () => {
            BirdManager.instance.skipWaiting();
        };

        skipMenuPayButton.clicked += () => {
            TradeManager.instance.skipWaiting();
        };

        birdSendButton.clicked += () => {
            BirdManager.instance.sendBirdOut();
        };

        birdPetButton.clicked += () => {
            BirdManager.instance.petBird();
            birdMenuOpenButton.style.display = DisplayStyle.Flex;
            birdMenu.style.display = DisplayStyle.None;
        };

        lootMenuClaimButton.clicked += () => {
            BirdManager.instance.makeBirdReady();
            LootManager.instance.getLoot();
        };

        homeCoinsButton.clicked += () => {
            homeScreen.style.display = DisplayStyle.None;
            gemsScreen.style.display = DisplayStyle.Flex;
            currencyTopBar.style.display = DisplayStyle.Flex;
        };

        birdTrainButton.clicked += () => {
            trainScreen.style.display = DisplayStyle.Flex;
            homeScreen.style.display = DisplayStyle.None;
            currencyTopBar.style.display = DisplayStyle.Flex;
        };

        trainBackButton.clicked += () => {
            trainScreen.style.display = DisplayStyle.None;
            homeScreen.style.display = DisplayStyle.Flex;
            currencyTopBar.style.display = DisplayStyle.None;
        };

        BirdManager.OnBirdStateChanged += OnBirdStateChanged;
    }

    private void OnBirdStateChanged(BirdState birdState){
        switch (birdState){
            case BirdState.Ready:
                birdMenu.style.display = DisplayStyle.None;
                homeBirdTimer.style.display = DisplayStyle.None;
                birdMenuOpenButton.style.display = DisplayStyle.Flex;
                lootMenu.style.display = DisplayStyle.None;
                homeSkipButton.style.display = DisplayStyle.None;
                skipMenu.style.display = DisplayStyle.None;
                break;
            case BirdState.Out:
                birdMenu.style.display = DisplayStyle.None;
                homeBirdTimer.style.display = DisplayStyle.Flex;
                birdMenuOpenButton.style.display = DisplayStyle.None;
                lootMenu.style.display = DisplayStyle.None;
                homeSkipButton.style.display = DisplayStyle.Flex;
                skipMenu.style.display = DisplayStyle.None;
                break;
            case BirdState.GotLoot:
                birdMenu.style.display = DisplayStyle.None;
                homeBirdTimer.style.display = DisplayStyle.None;
                birdMenuOpenButton.style.display = DisplayStyle.None;
                lootMenu.style.display = DisplayStyle.Flex;
                lootMenuPreviewCoins.text = $"{LootManager.instance.previewLoot()} coins";
                homeSkipButton.style.display = DisplayStyle.None;
                skipMenu.style.display = DisplayStyle.None;
                break;
         }
     }

}
