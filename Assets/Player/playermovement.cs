// using UnityEngine;
// using System.Collections;

// public class moveAxis : MonoBehaviour
// {
//     float _velocidade;
//     float _girar;
// 	//Variável que controla a força do pulo

//     void Start()
//     {
//         _velocidade = 20.0F;
//         _girar = 60.0F;

//     }

//     void Update()
//     {
//         float translate = (Input.GetAxis("Vertical") * _velocidade) * Time.deltaTime;
//         float rotate = (Input.GetAxis("Horizontal") * _girar) * Time.deltaTime;

//         transform.Translate(0, 0, translate);
//         transform.Rotate(0, rotate, 0);

        
//     }


// }

using UnityEngine;

//Requisitamos o componente Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
	//Variável que controla a força do pulo
	public float jumpForce = 5.0f;
	public float mass = 3.0f;
	private Rigidbody rigidbody;
	private bool isGround = false;
    
    float _velocidade;
    float _girar;
	void Start()
	{
		//Assim que o script  é executado, obtemos o componente Rigidbody e atribuimos a nossa variável
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.mass = mass;
        _velocidade = 2.5F;
        _girar = 70.0F;
	}


	void Update()
	{
        float translate = (Input.GetAxis("Vertical") * _velocidade) * Time.deltaTime;
        float rotate = (Input.GetAxis("Horizontal") * _girar) * Time.deltaTime;

        transform.Translate(0, 0, translate);
        transform.Rotate(0, rotate, 0);

		//Verificamos se o usuário NÃO pressionou a tecla Space ou se não está no chão
		if (!Input.GetKeyDown(KeyCode.Space) || !isGround)
			return;

		//Adicionamos uma força ao Rigidbody
		rigidbody.AddForce(
			Vector3.up * jumpForce, //Para fazer o personagem pular, então multiplicamos (0, 1, 0) pelo valor do pulo
			ForceMode.Impulse // Ajustamos a força para o tipo Impulse
			);

	}

	//Verifica se o personagem tocou no chão
	void OnCollisionEnter(Collision collision)
	{
		isGround = true;
	}

	//Verifica se o personagem saiu do chão
	void OnCollisionExit(Collision collision)
	{
		isGround = false;
	}
}
