//
//	RandomClass.cs - converted by EdzUp
//	converted by Ed 'EdzUp' Upton from source code by Shagwana
//

using UnityEngine;
using System.Collections;

public class RandomClass {
	//Seed the random number generator
	public void Seed( int iRNDSeed ) {
		Random.seed = iRNDSeed;
	}

	//Generate a number from 0 upto iMaxValue (not including)
	public long Generate( int iMaxValue ) {
		//Step up
		return( Random.Range ( 0, iMaxValue ) );
	}
}

/*
Class RNDGenerator	
End

Global Rand:RNDGenerator = New RNDGenerator

#rem
'=========================================================================
'Example of its use...

Print "--------------------------------------------------------"
Print "www.sublimegames.com simple fast random number generator"
Print "--------------------------------------------------------"


Const iMAX:Int = 20							'Max value to show (0 to iMAX-1)
Const iCOUNT:Int = 0						'Array location for the count
Const iSEEDAGE:Int = 1977
Const iTOTALLOOPS:Int = 999999

Local r:RNDGenerator = New RNDGenerator
Local iValues:Int[iMAX,1]


'Init counts
For Local iN:Int = 0 To (iMAX - 1)
  iValues[iN , iCOUNT] = 0
Next	


'Perform the random generating
r.Seed(iSEEDAGE)				'Seed the random number generator
For Local iN:Int = 0 To iTOTALLOOPS-1
	Local iNum:Int = r.Generate(iMAX)											'Generate a number in range
	'Print iNum
	iValues[iNum , iCOUNT] = iValues[iNum , iCOUNT] + 1			'Count how many times we encountered this one
Next


'Show spread
Local fTotal:Float = 0
Print "Show spread over " + iTOTALLOOPS + " loops, max value is " + (iMAX - 1)
Print ""
For Local iN:Int = 0 To (iMAX - 1)
	
	Local fPercent:Float = (Float(iValues[iN , iCOUNT])/Float(iTOTALLOOPS))*100.0
	Print "Number[" + iN + "]  Count(" + iValues[iN , iCOUNT] + ")  Percent(" + fPercent + ")"
	
	fTotal = (fTotal + fPercent)
	
Next	
Print ""
Print "Total Percent : "+fTotal
Print ""

End
#end
 */