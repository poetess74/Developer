// Fill out your copyright notice in the Description page of Project Settings.

#include "ABAIController.h"
#include "BehaviorTree/BehaviorTree.h"
#include "BehaviorTree/BlackboardData.h"

AABAIController::AABAIController()
{
    static ConstructorHelpers::FObjectFinder<UBlackboardData> BBObject(TEXT("/Game/Book/AI/BB_ABCharacter.BB_ABCharacter"));
    if(BBObject.Succeeded())
    {
        BBAsset = BBObject.Object;
    }

    static ConstructorHelpers::FObjectFinder<UBehaviorTree> BTObject(TEXT("/Game/Book/AI/BT_ABCharacter.BT_ABCharacter"));
    if(BTObject.Succeeded())
    {
        BTAsset = BTObject.Object;
    }
}

void AABAIController::Possess(APawn *InPawn)
{
    Super::Possess(InPawn);

    if(UseBlackboard(BBAsset, Blackboard))
    {
        if(!RunBehaviorTree(BTAsset))
        {
            ABLOG(Error, TEXT("AIController could not run behavior tree!"));
        }
    }
}
