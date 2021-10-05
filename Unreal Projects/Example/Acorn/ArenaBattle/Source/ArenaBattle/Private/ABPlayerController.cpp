// Fill out your copyright notice in the Description page of Project Settings.

#include "ABPlayerController.h"
#include "ABHUDWidget.h"
#include "ABPlayerState.h"
#include "ABCharacter.h"

AABPlayerController::AABPlayerController()
{
    static ConstructorHelpers::FClassFinder<UABHUDWidget> UI_HUD_C(TEXT("/Game/Book/UI/UI_HUD.UI_HUD_C"));
    if(UI_HUD_C.Succeeded())
    {
        HUDWidgetClass = UI_HUD_C.Class;
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

    FInputModeGameOnly InputMode;
    SetInputMode(InputMode);

    HUDWidget = CreateWidget<UABHUDWidget>(this, HUDWidgetClass);
    HUDWidget->AddToViewport();

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
