using UnityEngine;  
using System.Collections;  

public class EnemyAI : MonoBehaviour {  
	public const int STATE_STAND=0;  
	public const int STATE_WALK=1;  
	public const int STATE_RUN=2;  
	private int NowState;  
	public GameObject Hero;   
	public const int AI_THINK_TIME=2;  
	public const int AI_ATTACT_DISTANCE=10;   
	private float LastThinkTime;  
	void Start ()   
	{    
	}  
	void Update ()   
	{  
		if(Vector3.Distance(transform.position,Hero.transform.position)<AI_ATTACT_DISTANCE)  
		{   
			this.GetComponent<Animation>().Play("run");  
			NowState=STATE_RUN;  
			transform.LookAt(Hero.transform);    
			transform.Translate(Vector3.forward*Time.deltaTime * 5);  
		}else  
		{  
			if(Time.time-LastThinkTime>AI_THINK_TIME)  
			{  

				LastThinkTime=Time.time;  
				int Rnd=Random.Range(0,2);          
				switch(Rnd)  
				{  
				case 0:  
					this.GetComponent<Animation>().Play("idle");  
					NowState=STATE_STAND;  
					break;  

				case 1:   
					Quaternion mRotation=Quaternion.Euler(0,Random.Range(1,5)*90,0);  
					transform.rotation=Quaternion.Slerp(transform.rotation,mRotation,Time.deltaTime*1000);  
					this.GetComponent<Animation>().Play("walk");  
					transform.Translate(Vector3.forward*Time.deltaTime * 3);  
					NowState=STATE_WALK;  
					break; 

				case 2:  
					this.GetComponent<Animation>().Play("run");  
					transform.Translate(Vector3.forward*Time.deltaTime * 5);  
					NowState=STATE_RUN;  
					break;  
				}   
			}  
		}  
	}  
}  