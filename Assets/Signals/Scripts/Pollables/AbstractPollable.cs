using UnityEngine;

public abstract class AbstractPollable<T> : ScriptableObject, ISerializationCallbackReceiver
{
	int changedFrame = -1;
	
	[SerializeField]
	T value;

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

	public bool HasBecome(T value){
		return HasChanged() && this.value.Equals(value);
    }

	public T GetValue(){
		return value;
	}

    public void OnBeforeSerialize()
    {
		changedFrame = Time.frameCount+1;
    }

    public void OnAfterDeserialize()
    {
    }
}
