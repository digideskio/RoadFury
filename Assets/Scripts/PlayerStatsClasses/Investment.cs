﻿using UnityEngine;
using System.Collections;

public class Investment : MonoBehaviour {

	float growthPerYear;	// TODO set these values
	float monetaryValue;

	void OnEnable() {
		PlayerStats.OnYearCompleted += AnnualUpdate;
	}

	void OnDisable() {
		PlayerStats.OnYearCompleted -= AnnualUpdate;
	}

	public void SetMonetaryValue( float value ) {
		monetaryValue = value;
	}

	void AnnualUpdate() {
		monetaryValue *= growthPerYear;
	}

	void AddMoreMoney( float percentage ) {
		float percentToValue = PlayerStats.s_instance.money * percentage;
		monetaryValue += percentToValue;
		PlayerStats.s_instance.money -= percentToValue;
	}

	public void Liquidate() {
		PlayerStats.s_instance.money = monetaryValue;
		PlayerStats.s_instance.playerInvestments.Remove( this );
		Destroy( this );
	}
}
