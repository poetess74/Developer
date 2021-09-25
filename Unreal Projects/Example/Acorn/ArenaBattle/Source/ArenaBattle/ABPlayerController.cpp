// Fill out your copyright notice in the Description page of Project Settings.

#include "ABPlayerController.h"

void AABPlayerController::PostInitializeComponents()
{
    Super::PostInitializeComponents();
}

void AABPlayerController::Possess(APawn *aPawn)
{
    ABLOG_S(Warning);
    Super::Possess(aPawn);
}
