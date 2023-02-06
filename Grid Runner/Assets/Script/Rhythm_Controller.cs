using UnityEngine;
using System.Collections;

public class Rhythm_Controller : MonoBehaviour {

	float hitmo1, intervalo1, intervalo2;
	float[] speed = new float[13] {1.339f, 1.179f, 1.069f, 1.006f, 0.922f, 0.847f, 0.775f, 0.701f, 0.626f, 0.552f, 0.479f, 0.4f, 0.35f};
	int tempo = 1, setSpeed = 0;

	public int motionSpeed = 4;
	public float rollMotionSpeen = 3;

	public GameObject Kubo;
	bool voltou = false;
	int posicao = 2, bkpPosicao = 2;
	public Transform[] posicoes;

	public GameObject blackQuad;

	int idCmdStart = 1, idCommand = 1, contBack = 0;
	public int cmd;

	public AudioClip[] hits;
	AudioSource audioSource;

	ParticleSystem particleSys;

	void Awake ()
	{
		audioSource = GetComponent<AudioSource> ();
		particleSys = GameObject.Find ("SquareBubble").GetComponent<ParticleSystem>();
	}

	void Start ()
	{
	}

	void Update ()
	{
		GetCommand ();
		setSpeed = Kubo.GetComponent<Kubo_Attributes> ().MatchColorRhythm ();
	}

	void FixedUpdate () 
	{
		hitmo1 = speed [setSpeed];

		if (Time.fixedTime >= intervalo1) 
		{
			intervalo1 = Time.fixedTime + hitmo1;
			tempo++;
			idCommand = idCmdStart;

			SetSongSpeed ();

			if (tempo > 5) 
			{
				idCmdStart = 0;
			}

			if (tempo > 2) 
			{
				GridTagChange (idCommand);
			}

			ChamaLerMatriz (idCommand);
		}

		if (Time.fixedTime >= intervalo2)
		{
			if (Time.fixedTime >= intervalo2 + 0.30)
			{
				intervalo2 = intervalo1;
				Kubo.transform.rotation = Quaternion.Euler (0, 0, 0);

				if (tempo > 5) 
				{
					idCommand = 0;
					posicao = bkpPosicao;
					particleSys.Emit (1);

					if (contBack != 0) {
						voltou = true;
						contBack = 0;
					} else {
						voltou = false;
					}
				}
			}

			if (tempo > 1) 
			{
				GridMove (idCommand);
			}

			if (tempo > 5)
			{
				KuboRotation (idCommand);
			}
		}
	}

	void KuboRotation (int cmd)
	{
		if (cmd == 1) 
		{
			Quaternion newRot = Quaternion.Euler (90, 0, 0);
			Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed * rollMotionSpeen) * Time.fixedDeltaTime);
		}
		else if (cmd == 2)
		{
			if (!voltou) 
			{
				Quaternion newRot = Quaternion.Euler (-90, 0, 0);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed * rollMotionSpeen) * Time.fixedDeltaTime);
			}
		}
		else if (cmd == 3)
		{
			Quaternion newRot = Quaternion.Euler (0, 0, 90);

			if (posicao == 4) 
			{				
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, posicoes[3].position, motionSpeed * Time.fixedDeltaTime);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed  * rollMotionSpeen) * Time.fixedDeltaTime);
				bkpPosicao = 3;
			}
			else if (posicao == 3)
			{
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, posicoes[2].position, motionSpeed * Time.fixedDeltaTime);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed  * rollMotionSpeen) * Time.fixedDeltaTime);
				bkpPosicao = 2;
			}
			else if (posicao == 2)
			{
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, posicoes[1].position, motionSpeed * Time.fixedDeltaTime);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed  * rollMotionSpeen) * Time.fixedDeltaTime);
				bkpPosicao = 1;
			}
			else if (posicao == 1)
			{
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, posicoes[0].position, motionSpeed * Time.fixedDeltaTime);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed  * rollMotionSpeen) * Time.fixedDeltaTime);
				bkpPosicao = 0;
			}
			else
			{
				return;
			}
		}
		else if (cmd == 4)
		{
			Quaternion newRot = Quaternion.Euler (0, 0, -90);
			/*Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed + 5f) * Time.fixedDeltaTime);
			float xPos = Kubo.transform.position.x;
			if (xPos <= 4f) 
			{
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, new Vector3(xPos + 0.07f, 0.5f, -1f), (motionSpeed * 10f) * Time.fixedDeltaTime);
			}*/
			if (posicao == 0) 
			{				
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, posicoes[1].position, motionSpeed * Time.fixedDeltaTime);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed  * rollMotionSpeen) * Time.fixedDeltaTime);
				bkpPosicao = 1;
			}
			else if (posicao == 1)
			{
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, posicoes[2].position, motionSpeed * Time.fixedDeltaTime);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed  * rollMotionSpeen) * Time.fixedDeltaTime);
				bkpPosicao = 2;
			}
			else if (posicao == 2)
			{
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, posicoes[3].position, motionSpeed * Time.fixedDeltaTime);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed  * rollMotionSpeen) * Time.fixedDeltaTime);
				bkpPosicao = 3;
			}
			else if (posicao == 3)
			{
				Kubo.transform.position = Vector3.MoveTowards (Kubo.transform.position, posicoes[4].position, motionSpeed * Time.fixedDeltaTime);
				Kubo.transform.rotation = Quaternion.Slerp (Kubo.transform.rotation, newRot, (motionSpeed  * rollMotionSpeen) * Time.fixedDeltaTime);
				bkpPosicao = 4;
			}
			else
			{
				return;
			}
		}
	}

	void ChamaLerMatriz (int cmd)
	{
		if (cmd == 1) 
		{
			this.gameObject.GetComponent<Grid_Generator> ().PreencherMatriz_1D ();
		}
	}

	void GridTagChange (int cmd)
	{
		GameObject [] quads = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject [];
		int qntCubes = quads.Length;
		if (cmd == 1) 
		{
			for (int i = 0; i < qntCubes; i++) {
				
				if (quads[i].CompareTag ("Back")) {
					//	Destroy (quads[i].gameObject);
				}
				else if (quads[i].CompareTag ("Base"))
				{
					quads[i].tag = "Back";
				}
				else if (quads[i].CompareTag ("Next"))
				{
					quads[i].tag = "Base";
				}
				else if (quads[i].CompareTag ("Instanced"))
				{
					quads[i].tag = "Next";
				}
				else if (quads[i].CompareTag ("Instance"))
				{
					quads[i].tag = "Instanced";
				}
				else if (quads[i].CompareTag ("Quad"))
				{
					quads[i].tag = "Instance";
				}
			}
		}
		else if (cmd == 2) 
		{
			if (!voltou) 
			{
				for (int i = 0; i < qntCubes; i++) {
					if (quads[i].CompareTag ("Quad")) 
					{
						Destroy (quads[i].gameObject);
					}
					else if (quads[i].CompareTag ("Back")) {
						quads[i].tag = "Base";
					}
					else if (quads[i].CompareTag ("Base"))
					{
						quads[i].tag = "Next";
					}
					else if (quads[i].CompareTag ("Next"))
					{
						quads[i].tag = "Instanced";
					}
					else if (quads[i].CompareTag ("Instanced"))
					{
						quads[i].tag = "Instance";
					}
					else if (quads[i].CompareTag ("Instance"))
					{
						quads[i].tag = "Quad";
					}
				}
			}
		}
	}

	void GridMove (int cmd)
	{
		GameObject [] quads = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject [];
		int qntCubes = quads.Length;

		if (cmd == 1) 
		{
			for (int i = 0; i < qntCubes; i++) {
				float xPos = quads[i].transform.position.x;
				
				if (quads[i].CompareTag ("Back")) {
					Destroy (quads[i].gameObject);
				}
				else if (quads[i].CompareTag ("Base"))
				{
					quads [i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3(xPos, 0, -2.2f), motionSpeed * Time.fixedDeltaTime);
				}
				else if (quads[i].CompareTag ("Next"))
				{
					quads[i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3(xPos, 0, -1f), motionSpeed * Time.fixedDeltaTime);
				}
				else if (quads[i].CompareTag ("Instanced"))
				{
					quads [i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3 (xPos, 0, 0), motionSpeed * Time.fixedDeltaTime);
				}
				else if (quads[i].CompareTag ("Instance"))
				{
					quads[i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3(xPos, -0.4f, 1f), motionSpeed * Time.fixedDeltaTime);
				}
				else if (quads[i].CompareTag ("Quad"))
				{
					quads[i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3(xPos, -0.9f, 2f), motionSpeed * Time.fixedDeltaTime);
					/*if (quads[i].GetComponent<MeshRenderer>().material.color == blackQuad.GetComponent<MeshRenderer>().material.color)
				{
					Destroy (quads[i].gameObject);
				}*/
				}
			}
		}
		else if (cmd == 2) 
		{
			if (!voltou) 
			{
				for (int i = 0; i < qntCubes; i++) {
					float xPos = quads[i].transform.position.x;

					if (quads[i].CompareTag ("Back")) {
						Destroy (quads[i].gameObject);
					}
					else if (quads[i].CompareTag ("Base"))
					{
						quads [i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3(xPos, 0, -2.2f), motionSpeed * Time.fixedDeltaTime);
					}
					else if (quads[i].CompareTag ("Next"))
					{
						quads[i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3(xPos, 0, -1f), motionSpeed * Time.fixedDeltaTime);
					}
					else if (quads[i].CompareTag ("Instanced"))
					{
						quads [i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3 (xPos, 0, 0), motionSpeed * Time.fixedDeltaTime);
					}
					else if (quads[i].CompareTag ("Instance"))
					{
						quads[i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3(xPos, -0.4f, 1f), motionSpeed * Time.fixedDeltaTime);
					}
					else if (quads[i].CompareTag ("Quad"))
					{
						quads[i].transform.position = Vector3.MoveTowards (quads[i].transform.position, new Vector3(xPos, -0.9f, 2f), motionSpeed * Time.fixedDeltaTime);
					}
				}
			}
		}
		else if (cmd == 3 || cmd == 4) 
		{
			
		}
	}
		
	void GetCommand ()
	{
		if (tempo > 5) 
		{
			if (contBack == 0 && cmd == 2)
			{
				idCmdStart = 2;
				contBack ++;
				cmd = 0;
			}
			else if (cmd == 4)
			{
				idCmdStart = 3;
				cmd = 0;
			}
			else if (cmd == 3)
			{
				idCmdStart = 4;
				cmd = 0;
			}
			else if (cmd == 1) 
			{
				idCmdStart = 1;
				cmd = 0;
			}
			else if (Input.GetKeyDown ("space")) 
			{
				setSpeed++;
			}
		}
	}

	void SetSongSpeed ()
	{
		if (hitmo1 == speed[0]) 
		{
			audioSource.clip = hits [0];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[1])
		{
			audioSource.clip = hits [1];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[2])
		{
			audioSource.clip = hits [2];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[3])
		{
			audioSource.clip = hits [3];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[4])
		{
			audioSource.clip = hits [4];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[5])
		{
			audioSource.clip = hits [5];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[6])
		{
			audioSource.clip = hits [6];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[7])
		{
			audioSource.clip = hits [7];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[8])
		{
			audioSource.clip = hits [8];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[9])
		{
			audioSource.clip = hits [9];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[10])
		{
			audioSource.clip = hits [10];
			audioSource.pitch = 1f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[11])
		{
			audioSource.clip = hits [10];
			audioSource.pitch = 1.079f;
			audioSource.Play ();
		}
		else if (hitmo1 == speed[12])
		{
			audioSource.clip = hits [10];
			audioSource.pitch = 1.124f;
			audioSource.Play ();
		}
	}
}
