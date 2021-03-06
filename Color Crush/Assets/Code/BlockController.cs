﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BlockController : MonoBehaviour {
	public BlockType type;
	public enum BlockType {
		Red,
		Blue,
		Green,
		Yellow,
		Purple
	}

	public enum Direction {
		up,
		down,
		right,
		left
	}

	Vector3 mousePosition;

	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetType(BlockType t) {
		switch(t) {
			case BlockType.Blue:
				this.GetComponent<Image>().sprite = sprites[0];
				type = BlockType.Blue;
				break;
			case BlockType.Green:
				this.GetComponent<Image>().sprite = sprites[1];
				type = BlockType.Green;
				break;
			case BlockType.Purple:
				this.GetComponent<Image>().sprite = sprites[2];
				type = BlockType.Purple;
				break;
			case BlockType.Red:
				this.GetComponent<Image>().sprite = sprites[3];
				type = BlockType.Red;
				break;
			case BlockType.Yellow:
				this.GetComponent<Image>().sprite = sprites[4];
				type = BlockType.Yellow;
				break;

		}
	}

	public void BeginMouseDrag(BaseEventData b) {
		Debug.Log("BeginMouseDrag");
		mousePosition = Input.mousePosition;
	}

	public void EndMouseDrag(BaseEventData b) {
		Debug.Log("EndMouseDrag");
		Vector3 currentMousePosition = Input.mousePosition;

		if (Mathf.Abs(currentMousePosition.x - mousePosition.x) > Mathf.Abs(currentMousePosition.y - mousePosition.y)) {
			// horizontal
			if (currentMousePosition.x > mousePosition.x) {
				// right
				GameObject.Find("Main Camera").GetComponent<GameController>().MoveBlock(this.gameObject, Direction.right);
			} else {
				// left
				GameObject.Find("Main Camera").GetComponent<GameController>().MoveBlock(this.gameObject, Direction.left);
			}
		} else {
			// vertical
			if (currentMousePosition.y > mousePosition.y) {
				// up
				GameObject.Find("Main Camera").GetComponent<GameController>().MoveBlock(this.gameObject, Direction.up);
			} else {
				// down
				GameObject.Find("Main Camera").GetComponent<GameController>().MoveBlock(this.gameObject, Direction.down);
			}
		}
	}
}
