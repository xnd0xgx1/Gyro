using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AiPet : ControllIa{
	public NavMeshAgent agent;
    public GameObject gamecontroll;
    public GameObject Estados;
    public ParticleSystem ps;

    public GameObject pelota2;


    public bool onsearch = false;

    public int Hambre = 100;
    public int Vida = 100;
    public int Bañosl = 100;
    public int Sueño = 100;


    private bool playparticle = false;

	int num = -1;
	float vel;
    public Transform Dormir;
    public Transform Baño;
	protected override void estadopatrullaje(){
       
        
        if (actualestate == estado.patrullaje) {
			agent.speed = vel;
			if (agent.remainingDistance <= agent.stoppingDistance && agent.pathPending == false) {
				num = Random.Range (0, waypoints.Length);
				agent.destination = waypoints [num].position;

			} 

		} 
	}
    public void comida()
    {
        if (Estados.GetComponent<NestadosIA>().BarraHambre.value == 100)
        {
            Estados.GetComponent<NestadosIA>().BarraVida.value -= 10;
        }
        else
        {
            Estados.GetComponent<NestadosIA>().BarraHambre.value += 30;
        }
    }
    public void actionhambre()
    {
        if (actualestate == estado.patrullaje)
        {
            actualestate = estado.hambriento;
        }
    }
    public void call()
    {
        if (actualestate.Equals(estado.patrullaje)||actualestate.Equals(estado.hambriento))
        {
            actualestate = estado.llamado;
        }
       
        Debug.Log("llamado");
        StartCoroutine("llamado");
     
    }
    public void actiondormir()
    {
        StopAllCoroutines();
        agent.stoppingDistance = 0;
        StartCoroutine("dormido");
        actualestate = estado.dormir;
        
        
    }
    public void actionbañar()
    {
        StopAllCoroutines();
        agent.stoppingDistance = 0;
        StartCoroutine("banado");
        actualestate = estado.bañado;


    }
    IEnumerator llamado()
    {
        yield return new WaitForSeconds(5);
        actualestate = estado.patrullaje;
    }
    IEnumerator dormido()
    {
        
        yield return new WaitForSeconds(12);
      
        Estados.GetComponent<NestadosIA>().BarraSueño.value = 100;
        ps.Stop();
            playparticle = false;
       
        actualestate = estado.patrullaje;
        call();
        agent.stoppingDistance = 2;


    }
    IEnumerator banado()
    {

        yield return new WaitForSeconds(5);


        actualestate = estado.llamado;
    

    Debug.Log("llamado de bañar");
        StartCoroutine("llamado");
    agent.stoppingDistance = 2;
        Estados.GetComponent<NestadosIA>().BarraBaño.value = 100;

    }
    // Use this for initialization
    protected override void Start () {
        
        base.Start();
		agent = GetComponent<NavMeshAgent> ();
		vel = agent.speed;

	}
    protected void Update()
    {

        selector();

        if (!onsearch)
        {
            float dis = Vector3.Distance(this.transform.position, Camera.main.transform.position);
        if (dis <= 2.5)
        {
            gamecontroll.GetComponent<Gamecontroller>().change();
        }
        else
        {
            gamecontroll.GetComponent<Gamecontroller>().rev();

        }
    }
       
    }

    private void selector()
    {
        switch (actualestate)
        {
            case estado.patrullaje:
                estadopatrullaje();
                break;
            case estado.llamado:
                Estadollamado();
                break;
            case estado.hambriento:
                estadohambriento();
                break;
            case estado.dormir:
                Estadodormir();
                break;
            case estado.bañado:
                EstadoBañar();
                break;
        }
    }

    protected override void Estadollamado()
    {
        agent.speed = vel;
        agent.destination = Camera.main.transform.position;

        

    }

    protected override void estadohambriento()
    {
        agent.destination = this.transform.position;    
        
    }

    protected override void Estadodormir()
    {
        float dis = Vector3.Distance(this.transform.position, Dormir.position);
        agent.destination = Dormir.position;
       // Debug.Log(dis);
        if (dis<2f && playparticle == false)
        {
            playparticle = true;
            ps.Play();
            Debug.Log("Dormir");
        }
    }

    protected override void EstadoBañar()
    {
        agent.destination = Baño.position;
        
    }

    IEnumerator buscarpelota()
    {
        bool searchingball = true;
        bool first = false;
        while (onsearch)
        {
            if (GameObject.FindGameObjectWithTag("Pelota")) { 
                GameObject pelota = GameObject.FindGameObjectWithTag("Pelota");
                if (!first)
                {
                    Estados.GetComponent<NestadosIA>().BarraVida.value += 30;
                    first = true;
                    yield return new WaitForSeconds(1.0f);
                    
                }

                agent.destination = pelota.transform.position;
                agent.stoppingDistance = 0.0f;


                actualestate = estado.Pelota;
                    if (Vector3.Distance(this.transform.position, pelota.transform.position) <= 1.2)
                    {
                        Debug.Log("Llego a pelota");
                        Destroy(pelota);
                    pelota2.SetActive(true);
                        agent.destination = Camera.main.transform.position;
                        searchingball = false;
                    first = false;
                    agent.stoppingDistance = 2;

                }
                
            }
           else
            {
                if (agent.remainingDistance <= agent.stoppingDistance && searchingball == false)
                {
                    pelota2.SetActive(false);
                    onsearch = false;
                    StartCoroutine(llamado());
                    break;

                }
                else
                {
                    agent.destination = Camera.main.transform.position;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    protected override void Estadobuscarpelota()
    {
          
       
        onsearch = true;
        StopAllCoroutines();
        StartCoroutine(buscarpelota());
    }

    public void pelota()
    {

        if (Estados.GetComponent<NestadosIA>().BarraHambre.value >=10)
        {

            Estadobuscarpelota();
        }
    }
}
