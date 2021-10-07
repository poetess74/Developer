// Fill out your copyright notice in the Description page of Project Settings.

#include "ABPlayerController.h"
#include "ABHUDWidget.h"
#include "ABPlayerState.h"
#include "ABCharacter.h"
#include "ABGameplayWidget.h"

AABPlayerController::AABPlayerController()
{
    static ConstructorHelpers::FClassFinder<UABHUDWidget> UI_HUD_C(TEXT("/Game/Book/UI/UI_HUD.UI_HUD_C"));
    if(UI_HUD_C.Succeeded())
    {
        HUDWidgetClass = UI_HUD_C.Class;
    }

    static ConstructorHelpers::FClassFinder<UABGameplayWidget> UI_MENU_C(TEXT("/Game/Book/UI/UI_Menu.UI_Menu_C"));
    if(UI_MENU_C.Succeeded())
    {
        MenuWidgetClass = UI_MENU_C.Class;
    }
}

void AABPlayerController::PostInitializeComponents()
{
    Super::PostInitializeComponents();
}

void AABPlayerController::Possess(APawn *aPawn)
{
    ABLOG_S(Display);
    Super::Possess(aPawn);
}

void AABPlayerController::BeginPlay()
{
    Super::BeginPlay();
    ChangeInputMode(true);

    FInputModeGameOnly InputMode;
    SetInputMode(InputMode);

    HUDWidget = CreateWidget<UABHUDWidget>(this, HUDWidgetClass);
    ABCHECK(HUDWidget != nullptr);
    HUDWidget->AddToViewport(1);

    ABPlayerState = Cast<AABPlayerState>(PlayerState);
    ABCHECK(ABPlayerState != nullptr);
    HUDWidget->BindPlayerState(ABPlayerState);
    ABPlayerState->OnPlayerStateChanged.Broadcast();
}

UABHUDWidget* AABPlayerController::GetHUDWidget() const
{
    return HUDWidget;
}

void AABPlayerController::NPCKill(AABCharacter *KilledNPC) const
{
    ABPlayerState->AddExp(KilledNPC->GetExp());
}

void AABPlayerController::AddGameScore() const
{
    ABPlayerState->AddGameScore();
}

void AABPlayerController::SetupInputComponent()
{
    Super::SetupInputComponent();
    InputComponent->BindAction(TEXT("GamePause"), EInputEvent::IE_Pressed, this, &AABPlayerController::OnGamePause);
}

void AABPlayerController::OnGamePause()
{
    MenuWidget = CreateWidget<UABGameplayWidget>(this, MenuWidgetClass);
    ABCHECK(MenuWidget != nullptr);
    MenuWidget->AddToViewport(3);

    SetPause(true);
    ChangeInputMode(false);
}

void AABPlayerController::ChangeInputMode(bool bGameMode)
{
    if(bGameMode)
    {
        SetInputMode(GameInputMode);
        bShowMouseCursor = false;
    }
    else
    {
        SetInputMode(UIInputMode);
        bShowMouseCursor = true;
    }
}
