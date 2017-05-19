using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	[System.NonSerialized]
	public Grid.Position position;
    [System.NonSerialized]
    public bool Walking;

    public void SetPosition(Grid.Position toPosition, Vector2 spacing)
    {
        this.position = toPosition;
        transform.localPosition = toPosition.ToWorldPosition(spacing, 1.0f);
    }
}
