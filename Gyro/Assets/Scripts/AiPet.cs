using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AiPet : ControllIa{
	public NavMeshAgent agent;
    public GameObject gamecontroll;
    public GameObject Estados;
    public ParticleSystem ps;


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
            Estados.GetComponent<NestadosIA>().BarraVida.value += 30;
        }
        else
        {
            Estados.GetComponent<NestadosIA>().BarraHambre.value += 30;
        }
    }
    public void actionhambre()
    {
        if (actualestate != estado.llamado)
        {
            actualestate = estado.hambriento;
        }
    }
    public void call()
    {
        if (actualestate.Equals(estado.patrullaje))
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

        Estados.GetComponent<NestadosIA>().BarraBaño.value = 100;
        call();
        agent.stoppingDistance = 2;

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
        float dis = Vector3.Distance(this.transform.position,Camera.main.transform.position);
        if (dis <= 2.5)
        {
            gamecontroll.GetComponent<Gamecontroller>().change();
        }
        else
        {
            gamecontroll.GetComponent<Gamecontroller>().rev();
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
}
