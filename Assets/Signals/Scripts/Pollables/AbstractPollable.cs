using UnityEngine;

public abstract class AbstractPollable<T> : ScriptableObject, ISerializationCallbackReceiver
{
	int changedFrame = -1;
	
	[SerializeField]
	T value;

	//This is purely used by serialzation so value can be modified in inspector
	//T oldValue;

	public T Value {
		get {
			return value;
		}
		set {
			changedFrame = Time.frameCount+1;
			this.value = value;
		}
	}
	void OnEnable()
	{
		changedFrame = -1;
	}

	public void SetValue(T value){
		changedFrame = Time.frameCount+1;
		this.value = value;
	}
	public bool HasChanged(){		
		return changedFrame == Time.frameCount;
	}

	public T GetValue(){
		return value;
	}

    public void OnBeforeSerialize()
    {
		//Debug.Log("B "+Time.frameCount);
		changedFrame = Time.frameCount+1;
        //oldValue = value;
    }

    public void OnAfterDeserialize()
    {
		/* 
		Debug.Log("A "+oldValue.Equals(value));

		if(oldValue.Equals(value) ){
			changedFrame  = -1;
		}
		oldValue = default(T);
		*/
    }
}
