// Copyright Epic Games, Inc. All Rights Reserved.

#include "QuixelBridgeGameMode.h"
#include "QuixelBridgeCharacter.h"
#include "UObject/ConstructorHelpers.h"

AQuixelBridgeGameMode::AQuixelBridgeGameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPersonCPP/Blueprints/ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
