using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSquare_c : MonoBehaviour {

	public int divisionsCount;
	public float totalSize;
	public float height;

	Vector3[] vertices;
	int totalvertices;

	// Use this for initialization
	void Start () {
		CreateTerrain ();

	}

    // Create height map
	void CreateTerrain () {
        // All vertices in height map
		totalvertices = (divisionsCount + 1) * (divisionsCount + 1);
        // Store vertices in one dimentional array
		vertices = new Vector3[totalvertices];
		Vector2[] uvs = new Vector2[totalvertices];
        // The number of triangles : disvisionsCount * discisionsCount * 2
        // Each triangle in Unity have three vertices to store
        // Thus, the factor is 6.
		int[] tris = new int[divisionsCount * divisionsCount * 6];

        //half size of the terrain
		float halfSize = totalSize * 0.5f;
        //each small square size
		float divisionSize = totalSize / divisionsCount;

        // Create a new mesh
		Mesh mesh = new Mesh ();
		GetComponent<MeshFilter> ().mesh = mesh;

        // To count triangle vertices,
        // 6 count per square,
        // 3 count per triangle,
        // increment 6 count per loop to calculate the next group
		int triOffset = 0;

		for(int i = 0; i <=divisionsCount; i++) {
			for(int j = 0; j<=divisionsCount;j++) {
                // Set vertices
				vertices[i * (divisionsCount+1)+j] = new Vector3(-halfSize+j*divisionSize,0.0f,halfSize-i*divisionSize);
                // Set uv inorder to applu texture
				uvs[i*(divisionsCount+1)+j] = new Vector2((float)i/divisionsCount,(float)j/divisionsCount);

                //build triangles
				if(i < divisionsCount && j < divisionsCount) {
					int topLeft = i *(divisionsCount+1)+j;
					int botLeft = (i+1)*(divisionsCount+1)+j;

                    //\---
                    // \ |
                    //  \|
                    //   \
					tris[triOffset] =topLeft;
					tris[triOffset+1] = topLeft+1;
					tris[triOffset+2] = botLeft+1;

                    //|
                    //|\
                    //| \
                    //|  \
                    //|---\
					tris[triOffset+3] = topLeft;
					tris[triOffset+4] = botLeft+1;
					tris[triOffset+5] = botLeft;


					triOffset +=6;
				}
			}
		}
        // End of setting up flat surface


		//Algorithm
        //Start from four edges

        //top left
		vertices [0].y = Random.Range (-height, height);
        //top right
		vertices [divisionsCount].y = Random.Range (-height, height);
        //bottom right
		vertices [vertices.Length - 1].y = Random.Range (-height, height);
        //bottom left
		vertices [vertices.Length - 1 - divisionsCount].y = Random.Range (-height, height);


        // number of iterations needed to be performed based on the division
		int iterations = (int)Mathf.Log (divisionsCount, 2);

        //initial number of square
		int numSquares = 1;

		int squareSize = divisionsCount;
		for(int i = 0;i < iterations; i++) {

			int row =0;
			for(int j = 0; j < numSquares; j++) {
				int col = 0;
                // iterater each square
				for (int k = 0; k < numSquares; k++) {
					DiamondSquare (row, col, squareSize, height);
					col += squareSize;
				}
				row += squareSize;
			}
			numSquares *= 2;
			squareSize /= 2;
            //Modify to control the change of height
			height *= 0.5f;
		}



		// apply to the height map
		mesh.vertices =vertices;
		mesh.uv = uvs;
		mesh.triangles=tris;

		mesh.RecalculateBounds();
		mesh.RecalculateNormals();

		//Add collision to generated mesh
		MeshCollider meshc = gameObject.AddComponent (typeof(MeshCollider)) as MeshCollider;
		meshc.sharedMesh = mesh;
	
	}

	void DiamondSquare(int row, int col, int size, float offset) {
		int halfSize = (int)(size*0.5f);
        //top left index of the square
		int topLeft = row * (divisionsCount+1)+col;
        //bottom left index of the square
		int botLeft = (row+size) * (divisionsCount+1) + col;
        // middle point index of the square
		int mid = (int)(row+halfSize) * (divisionsCount+1) + (int)(col+halfSize);
        //calculate the mid point value based on four points+ random value--Diamond Step
		vertices[mid].y = (vertices[topLeft].y+vertices[topLeft+size].y+vertices[botLeft].y+vertices[botLeft+size].y)*0.25f+ Random.Range(-offset,offset);
        //calculate the mid point value based on three points+ random value--Square Step
		vertices [topLeft + halfSize].y = (vertices [topLeft].y + vertices [topLeft + size].y + vertices [mid].y) / 3 + Random.Range (-offset, offset);
		vertices[mid-halfSize].y = (vertices[topLeft].y+vertices[botLeft].y+vertices[mid].y)/3 + Random.Range (-offset, offset);
		vertices[mid+halfSize].y = (vertices[topLeft+size].y+vertices[botLeft+size].y+vertices[mid].y)/3 + Random.Range (-offset, offset);
		vertices[botLeft+halfSize].y = (vertices[botLeft].y+vertices[botLeft+size].y+vertices[mid].y)/3 + Random.Range (-offset, offset);

	}
}
