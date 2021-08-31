using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData
{
	public int[] targetA;
	public int[] targetB;
	public int[] targetC;

	public TargetData()
	{
		targetA = new int[8];
		targetB = new int[8];
		targetC = new int[8];

		for (int i = 0; i < targetA.Length; i++)
		{
			targetA[i] = 0;
		}

		for (int i = 0; i < targetB.Length; i++)
		{
			targetB[i] = 0;
		}
		for (int i = 0; i < targetC.Length; i++)
		{
			targetC[i] = 0;
		}

	}

	public TargetData(int ta, int tb, int tc)
	{
		targetA = new int[ta];
		targetB = new int[tb];
		targetC = new int[tc];

		for (int i = 0; i < targetA.Length; i++)
		{
			targetA[i] = 0;
		}

		for (int i = 0; i < targetB.Length; i++)
		{
			targetB[i] = 0;
		}
		for (int i = 0; i < targetC.Length; i++)
		{
			targetC[i] = 0;
		}

	}
}
