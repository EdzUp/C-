/*
 * Math.cs - Copyright (C)EdzUp
 * Programmed by Ed 'EdzUp' Upton
 * */

using UnityEngine;
using System;
using System.Collections;

public class MathClass {
	float Intersection_X;				//x coord of intersection
	float Intersection_Y;				//y coord of intersection
	float Intersection_AB;				//distance along seg ab
	float Intersection_CD;				//distance along seg CD

	//----------------------------------------------------------------------------------------------------
	public bool LinesIntersect( float Ax, float Ay, float Bx, float By, float Cx, float Cy, float Dx, float Dy ) {
		float Rn = ( Ay -Cy ) *( Dx -Cx ) -( Ax -Cx ) *( Dy -Cy );
		float Rd = ( Bx -Ax ) *( Dy -Cy ) -( By -Ay ) *( Dx -Cx );
		
		if ( Rd == 0 ) {
			// Lines are parralel.
			// If Rn# is also 0 Then lines are coincident.  All points intersect. 
			// Otherwise, there is no intersection point.
			return( false );
		} else {
			// The lines intersect at some point.  Calculate the intersection point.
			float Sn = ( Ay -Cy ) *( Bx -Ax ) -( Ax -Cx ) *( By -Ay );
			Intersection_AB = Rn /Rd;
			Intersection_CD = Sn /Rd;
			Intersection_X = Ax +Intersection_AB *( Bx -Ax );
			Intersection_Y = Ay +Intersection_AB *( By -Ay );
		}


		if ( Intersection_AB>0 && Intersection_AB<1 && Intersection_CD>0 && Intersection_CD<1 ) {
			return( true );
		} else {
			return( false );
		}
	}

	public float IntersectX() {
		return( Intersection_X );
	}

	public float IntersectY() {
		return( Intersection_Y );
	}

	public char numberToAlphabet( long dNumber ) {
		dNumber +=65;
		int c = Convert.ToInt32( dNumber );
		char chr = Convert.ToChar( c );
		return( chr );
	}
	
	public double Percentage( long MaxValue, long CurrentValue ) {
		double Per = MaxValue /100.0f;
		
		if ( CurrentValue == MaxValue ) return( 100.0f );
		if ( Per<=0.0 ) return( 0.0f );
		
		return( CurrentValue /Per );
	}
	
	public bool IsOdd( long value ) {
		if ( value == 0 ) return( false );
		
		if ( ( value % 2 )!=0.0 ) {
			return( true );
		} else {
			return( false );
		}
	}
	
	public float AngleDistance( float CurrentAngle, float NewAngle ) {
		//this will return the distance between two angles
		return ( Mathf.DeltaAngle( CurrentAngle, NewAngle ) );
	}
	
	public float FindAngle( float x1, float y1, float x2, float y2 ) {
		//returns the angle to a target
		float ReturnedAngle = ( Mathf.Atan2( y2 -y1, x2 -x1 ) *Mathf.Rad2Deg );//*180.0f /(float)Math.PI );

		return( ( ReturnedAngle -270.0f ) );
	}
	
	public float Distancef( float x, float y, float z, float x2, float y2, float z2 ) {
		return( Mathf.Sqrt( ( x -x2 ) * ( x -x2 ) + ( y -y2 ) * ( y -y2 ) +( z -z2 ) *( z -z2 ) ) );
	}

	public float DistanceVec3( Vector3 From, Vector3 To ) {
		return( Mathf.Sqrt( ( From.x -To.x ) * ( From.x -To.x ) + ( From.y -To.y ) * ( From.y -To.y ) +( From.z -To.z ) *( From.z -To.z ) ) );
	}

	public float CameraDistance( Camera from, GameObject to ) {
		//This will return the distance between two gameobjects
		Vector3 frmpos;
		Vector3 topos;
		
		frmpos = from.transform.position;
		topos = to.transform.position;
		
		return( Mathf.Sqrt ( ( frmpos.x - topos.x ) *( frmpos.x -topos.x ) +( frmpos.y -topos.y ) *( frmpos.y -topos.y ) +( frmpos.z -topos.z ) *( frmpos.z -topos.z ) ) );
	}
	
	public float Distance( GameObject from, GameObject to ) {
		//This will return the distance between two gameobjects
		Vector3 frmpos;
		Vector3 topos;
		
		frmpos = from.transform.position;
		topos = to.transform.position;
		
		return( Mathf.Sqrt ( ( frmpos.x - topos.x ) *( frmpos.x -topos.x ) +( frmpos.y -topos.y ) *( frmpos.y -topos.y ) +( frmpos.z -topos.z ) *( frmpos.z -topos.z ) ) );
	}
}
