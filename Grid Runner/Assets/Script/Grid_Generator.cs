using UnityEngine;

[System.Serializable]
public struct ColorPos
{
	public Color cor;
	public Vector3 pos;
}

public class Grid_Generator : MonoBehaviour {

	int tamanhoMatriz_1D;

	public GameObject quad;
	GameObject proximoQuad;

	public void PreencherMatriz_1D()
	{
		ColorPos[] matriz_1D;
		tamanhoMatriz_1D = 5;

		matriz_1D = new ColorPos[tamanhoMatriz_1D];

		for (int i = 0; i < matriz_1D.Length; i++) 
		{
			Color[] cores = new Color[4] {new Color (1f, 0, 0), new Color (0, 1f, 0), new Color (0, 0, 1f), new Color (0, 0, 0)};

			Color randCor = cores[Random.Range (0, 4)];
//			float colorR = Random.Range (0f, 1f);
//			float colorG = Random.Range (0f, 1f);
//			float colorB = Random.Range (0f, 1f);
//			Color randCor = new Color (colorR, colorG, colorB);
			matriz_1D[i].cor = randCor;
			Vector3 nextPos = new Vector3();
			nextPos.x = i * 1;
			matriz_1D[i].pos = nextPos;
		}

		LerMatriz (matriz_1D);
	}

	void LerMatriz(ColorPos[] matriz)
	{
		for (int i = 0; i < matriz.Length; i++) 
		{
			proximoQuad = Instantiate(quad, new Vector3 (matriz[i].pos.x, -0.9f, 2f), Quaternion.Euler(90f, 0f, 0f)) as GameObject; 
			proximoQuad.GetComponent<MeshRenderer>().material.color = matriz[i].cor;
		}
	}
}
