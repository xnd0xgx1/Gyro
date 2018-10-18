using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera2 : MonoBehaviour {
	private float initialYAngle = 0f;
	private float appliedGyroYAngle = 0f;
	private float calibrationYAngle = 0f;
    
	public Text txt;
    [SerializeField]
    private bool inShoot = false;
    [SerializeField]
    private GameObject pelota;

    [SerializeField]
    private GameObject sphere;

    private bool shooted = false;

    public GameObject joystick;

    public GameObject gamecntrl;

    public GameObject disparo;

    private AiPet scrpai;
    void Start()
	{

       
		Input.gyro.enabled = true;
		Application.targetFrameRate = 60;
		initialYAngle = transform.eulerAngles.y;
        

    }

	void Update()
	{
       
        ApplyGyroRotation();
        ApplyCalibration();
	}
    public void tiro()
    {
        shooted = true;
    }

    public void minijuego()
    {

        Debug.Log("callbtn desactivado");
        gamecntrl.GetComponent<Gamecontroller>().ocultarbtn();
        joystick.SetActive(false);

        disparo.SetActive(true);
        disparo.GetComponent<Fuerzadedisparo>().start();

        scrpai = sphere.GetComponent<AiPet>();
        if (!scrpai.onsearch && !inShoot)
        {
            inShoot = true;
            scrpai.pelota();

        }
        else
        {
            Debug.Log("Has been shoot");
        }
    }


	public void CalibrateYAngle()
	{
        calibrationYAngle = appliedGyroYAngle - initialYAngle;//calibra la camara
        ApplyCalibration();
        Debug.Log("Camara Calibrada");
        StartCoroutine("message", "Camera Calibrada");

    }
	IEnumerator message(string ms){
		txt.text = ms;
		txt.gameObject.SetActive (true);
		yield return new WaitForSeconds (2);
		txt.gameObject.SetActive (false);
	}
	void ApplyGyroRotation()
	{
		transform.rotation = Input.gyro.attitude;
		transform.Rotate( 0f, 0f, 180f, Space.Self ); // Swap "handedness" of quaternion from gyro.
		transform.Rotate( 90f, 180f, 0f, Space.World ); // Rotate to make sense as a camera pointing out the back of your device.
		appliedGyroYAngle = transform.eulerAngles.y;

        if (inShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {

                

                shooted = false;
                disparo.GetComponent<Fuerzadedisparo>().stop();
                Instantiate(pelota, transform.position, Quaternion.identity);
                  

                    
                    inShoot = false;
                    joystick.SetActive(true);

                
            }
        }// Save the angle around y axis for use in calibration.
    }

	void ApplyCalibration()
	{
		transform.Rotate( 0f, -calibrationYAngle, 0f, Space.World ); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
	}
	public void trans(){
		Vector3 rot = transform.position;
		rot.x = rot.x + 1;
		transform.position = rot;
	}
}
