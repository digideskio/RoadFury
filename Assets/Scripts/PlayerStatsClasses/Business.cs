﻿using UnityEngine;
using System.Collections;

public class Business : MonoBehaviour {
	private static int currentIndex = 0;

	public int indexID;
	public int growthProbability;		// Between 1 - 100
	//public int currentRandomNumber;
	public float revenueStream;
	public float valuation;

	void Start () {
		growthProbability = Random.Range( 1, 101 );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CalculateGrowthRatio() {
		// Roll for a random number for growth probablily
		float difference = growthProbability - Random.Range( 1, 101 );
		// Find percentage of proximity (positive or negative) to the growth probability
		float proximity = difference / growthProbability;

		// Use proxmity to determine what bracket of growth/decay the business endured
		float directionOfGrowth = Mathf.Sign( proximity );
		if( proximity <= 0.1f )
			revenueStream *= 10f * directionOfGrowth;
		else if( proximity > 0.1f && proximity <= 0.3f )
			revenueStream *= 3f * directionOfGrowth;
		else if( proximity > 0.3f && proximity <= 0.7f )
			revenueStream *= 1.5f * directionOfGrowth;
		else if( proximity > 0.7f  )
			revenueStream *= 1.2f * directionOfGrowth;


		UpdateValuation( directionOfGrowth );
	}

	private void UpdateValuation( float growth ) {
		// if positive growth, val *- 1.2
		if( growth > 0 )
			valuation *= 1.2f;
		// else val--
		else
			growth *= 0.8f; //TODO update this number to something better
	}

	public static int GenerateIndex() {
		// Returns index and adds one for the next generation
		currentIndex++;
		return currentIndex-1;
	}
}
