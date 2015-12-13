using UnityEngine;
using System.Collections;

[RequireComponent (typeof (LineRenderer))]

public class line : MonoBehaviour {




	public star one;
	public star two;
	public bool isActive=false;

	private LineRenderer lineDraw;


	void Start () {
	
		if((one ==null)|| (two==null)){
			Debug.LogError("LINE:   "+this.name+ " PART OF   "+ this.gameObject.transform.parent.name + " HAS AN ERROR WITH STAR");
		}
		if(one==two){
			Debug.LogError("Line:   "+this.name+"   PART OF:   "+this.gameObject.transform.parent.name+"   CONTAINS THE SAME STAR TWICE");
		}
		if((one.transform.parent!=this.gameObject.transform.parent)&&(two.transform.parent!=this.gameObject.transform.parent)){
			Debug.LogError("Line:   "+this.name+"   PART OF:   "+this.gameObject.transform.parent.name+"   HAS A STARS NOT CONNECTED TO THE PARENT OBJECT");
		}

		lineDraw = ((LineRenderer)this.GetComponent (typeof(LineRenderer)));
		//set the proporties

		lineDraw.SetWidth (.025f, .025f);
		lineDraw.SetPosition(0,one.transform.position);
		lineDraw.SetPosition(1,two.transform.position);
		lineDraw.enabled = false;
	}

	void Update(){
		lineDraw.SetPosition(0,one.transform.position);
		lineDraw.SetPosition(1,two.transform.position);
	}
	



}
