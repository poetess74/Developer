// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "ArenaBattle.h"
#include "GameFramework/Actor.h"
#include "ABWeapon.generated.h"

UCLASS()
class ARENABATTLE_API AABWeapon : public AActor
{
	GENERATED_BODY()

public:
	// Sets default values for this actor's properties
	AABWeapon();

	float GetAttackRange() const;

protected:
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category=Attack)
	float AttackRange;

public:
	UPROPERTY(VisibleAnywhere, Category=Weapon)
	USkeletalMeshComponent *Weapon;

};
