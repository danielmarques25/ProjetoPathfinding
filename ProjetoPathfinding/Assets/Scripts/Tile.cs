using UnityEngine;

public class Tile : MonoBehaviour
{
	[System.NonSerialized]
	public Grid.Position position;

	[System.NonSerialized]
	public Grid grid;

	[System.NonSerialized]
	public bool isWall;

	private Renderer tileRenderer;
	private MaterialPropertyBlock propertyBlock;

	public void Highlight( bool highlighted )
	{
		if( isWall )
			return;

		if( highlighted )
			propertyBlock.SetColor( "_Color", Color.yellow );
		else
			propertyBlock.Clear();

		tileRenderer.SetPropertyBlock( propertyBlock );
	}

    public static bool InsideGrid(Grid.Position pos, Tile[,] tiles)
    {
        if(pos.x < 0 || pos.x >= tiles.GetLength(0) || pos.y < 0 || pos.y >= tiles.GetLength(1) || tiles[pos.x, pos.y].isWall)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    private void Awake()
	{
		tileRenderer = GetComponent<Renderer>();
		propertyBlock = new MaterialPropertyBlock();
	}

	private void OnMouseDown()
	{
		grid.MoveTo( position );
	}
}
