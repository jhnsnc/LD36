using UnityEngine;
using System.Collections;

public class TextureScale : MonoBehaviour {

	public float scaleX = 1.0f;
	public float scaleY = 1.0f;

	void Start () {
		GetComponent<Renderer>().material.mainTextureScale = new Vector2(scaleX, scaleY);
	}
}
