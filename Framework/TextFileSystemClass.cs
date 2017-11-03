using UnityEngine;
using System.Collections;

public class TextFileSystemClass {
	public string LoadFile( string filename ) {
		TextAsset asset = (TextAsset)Resources.Load ( filename );
		string datafileContent = asset.text;

		return( datafileContent );
	}
}
