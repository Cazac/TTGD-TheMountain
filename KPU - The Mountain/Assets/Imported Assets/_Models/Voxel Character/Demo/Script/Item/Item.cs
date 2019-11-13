namespace MoenenVoxel {

using UnityEngine;
using System.Collections;


public enum ItemBehaviour {
	None = 0,
	Single = 1,
	Double = 2,
	TwoHands = 3,
}

public class Item : MonoBehaviour {


	public virtual string ItemName {
		get {
			return itemName;
		}
	}

	public virtual ItemBehaviour ItemBehaviourID {
		get {
			return itemBehaviourID;
		}
	}

	[SerializeField]
	private string itemName;
	[SerializeField]
	ItemBehaviour itemBehaviourID;



	public enum ItemList {
		None,
		Hand,
		Axe,
		Shield,
		Spear,
		Sword,
	}


	#region -------- API --------


	public static Transform SpawnItem (Transform tf) {
		return SpawnItem(tf ? tf.GetComponent<Item>() : null);
	}


	public static Transform SpawnItem (Item item) {
		if (!item) {
			return null;
		}
		Transform tf = Instantiate<GameObject>(item.gameObject).transform;
		if (tf) {
			tf.name = item.ItemName;
		}
		return tf;
	}


	public static void DespawnItem (Item item) {
		if (!item) {
			return;
		}
		DestroyImmediate(item.gameObject, false);
	}



	#endregion


}
}
