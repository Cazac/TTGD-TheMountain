namespace MoenenVoxel {

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;


[CustomEditor(typeof(CharacterBehaviour), true)]
[CanEditMultipleObjects]
public class CharacterBehaviourInspector : Editor {


	#region -------- VAR --------

	private Object WeaponObj;

	private static GUIStyle QSetUpStyle {
		get {
			if (qSetUpStyle == null) {
				qSetUpStyle = new GUIStyle(GUI.skin.box);
				qSetUpStyle.fontSize = 12;
				qSetUpStyle.normal.textColor = new Color(0.8f, 0.8f, 0.8f);
				qSetUpStyle.alignment = TextAnchor.MiddleCenter;
				qSetUpStyle.richText = true;
			}
			return qSetUpStyle;
		}
	}
	private static GUIStyle qSetUpStyle;

	private static GUIStyle QSetUpInfoStyle {
		get {
			if (qSetUpInfoStyle == null) {
				qSetUpInfoStyle = new GUIStyle(GUI.skin.box);
				qSetUpInfoStyle.fontSize = 11;
				qSetUpInfoStyle.normal.textColor = new Color(0.8f, 0.8f, 0.8f);
				qSetUpInfoStyle.alignment = TextAnchor.UpperLeft;
				qSetUpInfoStyle.richText = true;
			}
			return qSetUpInfoStyle;
		}
	}
	private static GUIStyle qSetUpInfoStyle;

	private static Texture RedPannel {
		get {
			if (!redPannel) {
				redPannel = TextureUtil.QuickTexture(120, 24, new Color(0.8f, 0f, 0f, 0.3f));
			}
			return redPannel;
		}
	}
	private static Texture redPannel = null;

	private static Texture OrangePannel {
		get {
			if (!orangePannel) {
				orangePannel = TextureUtil.QuickTexture(120, 24, new Color(0.8f, 0.6f, 0f, 0.3f));
			}
			return orangePannel;
		}
	}
	private static Texture orangePannel = null;

	private static Texture GreenPannel {
		get {
			if (!greenPannel) {
				greenPannel = TextureUtil.QuickTexture(120, 24, new Color(0f, 0.6f, 0f, 0.24f));
			}
			return greenPannel;
		}
	}
	private static Texture greenPannel = null;

	private static bool QSetupOpen = false;
	private static bool HelpBoxOpen = false;


	#endregion



	#region -------- MSG --------


	[MenuItem("GameObject/3D Object/_2L2H")]
	private static void Create2L2HCharacter () {


		#region --- Transform Init ---

		Transform root = new GameObject("New_2L2H").transform;
		Transform body = new GameObject("Body").transform;
		Transform head = new GameObject("Head").transform;
		Transform armL = new GameObject("ArmL").transform;
		Transform armR = new GameObject("ArmR").transform;
		Transform legL = new GameObject("LegL").transform;
		Transform legR = new GameObject("LegR").transform;
		Transform handL = new GameObject("HandL").transform;
		Transform handR = new GameObject("HandR").transform;
		Transform footL = new GameObject("FootL").transform;
		Transform footR = new GameObject("FootR").transform;
		Transform bodyM = new GameObject("_model").transform;
		Transform headM = new GameObject("_model").transform;
		Transform armML = new GameObject("_model").transform;
		Transform armMR = new GameObject("_model").transform;
		Transform legML = new GameObject("_model").transform;
		Transform legMR = new GameObject("_model").transform;
		Transform handML = new GameObject("_model").transform;
		Transform handMR = new GameObject("_model").transform;
		Transform footML = new GameObject("_model").transform;
		Transform footMR = new GameObject("_model").transform;
		Transform bodyH = new GameObject("_holder").transform;
		Transform headH = new GameObject("_holder").transform;
		Transform armHL = new GameObject("_holder").transform;
		Transform armHR = new GameObject("_holder").transform;
		Transform legHL = new GameObject("_holder").transform;
		Transform legHR = new GameObject("_holder").transform;
		Transform handHL = new GameObject("_holder").transform;
		Transform handHR = new GameObject("_holder").transform;
		Transform footHL = new GameObject("_holder").transform;
		Transform footHR = new GameObject("_holder").transform;



		body.SetParent(root);
		head.SetParent(body);
		armL.SetParent(body);
		armR.SetParent(body);
		legL.SetParent(body);
		legR.SetParent(body);
		handL.SetParent(armL);
		handR.SetParent(armR);
		footL.SetParent(legL);
		footR.SetParent(legR);
		bodyM.SetParent(body);
		headM.SetParent(head);
		armML.SetParent(armL);
		armMR.SetParent(armR);
		legML.SetParent(legL);
		legMR.SetParent(legR);
		handML.SetParent(handL);
		handMR.SetParent(handR);
		footML.SetParent(footL);
		footMR.SetParent(footR);
		bodyH.SetParent(body);
		headH.SetParent(head);
		armHL.SetParent(armL);
		armHR.SetParent(armR);
		legHL.SetParent(legL);
		legHR.SetParent(legR);
		handHL.SetParent(handL);
		handHR.SetParent(handR);
		footHL.SetParent(footL);
		footHR.SetParent(footR);

		#endregion

		CharacterBehaviour ch = root.gameObject.AddComponent<CharacterBehaviour>();
		ch.behaviourSetting.characterType = CharacterBehaviour.BehaviourSetting.CharacterType._2L2H;
		
		ResetCharacter(ch);
		ResetCharacterSetting(ch);

	}


	[MenuItem("GameObject/3D Object/_2L")]
	private static void Create2LCharacter () {

		#region --- Transform Init ---

		Transform root = new GameObject("New_2L").transform;
		Transform body = new GameObject("Body").transform;
		Transform head = new GameObject("Head").transform;
		Transform LegL = new GameObject("LegL").transform;
		Transform LegR = new GameObject("LegR").transform;
		Transform FootL = new GameObject("FootL").transform;
		Transform FootR = new GameObject("FootR").transform;
		Transform Tail = new GameObject("Tail").transform;

		Transform bodyM = new GameObject("_model").transform;
		Transform headM = new GameObject("_model").transform;
		Transform LegML = new GameObject("_model").transform;
		Transform LegMR = new GameObject("_model").transform;
		Transform FootML = new GameObject("_model").transform;
		Transform FootMR = new GameObject("_model").transform;
		Transform TailM = new GameObject("_model").transform;

		Transform bodyH = new GameObject("_holder").transform;
		Transform headH = new GameObject("_holder").transform;
		Transform LegHL = new GameObject("_holder").transform;
		Transform LegHR = new GameObject("_holder").transform;
		Transform FootHL = new GameObject("_holder").transform;
		Transform FootHR = new GameObject("_holder").transform;
		Transform TailH = new GameObject("_holder").transform;

		body.SetParent(root);
		head.SetParent(body);
		LegL.SetParent(body);
		LegR.SetParent(body);
		Tail.SetParent(body);
		FootL.SetParent(LegL);
		FootR.SetParent(LegR);

		bodyM.SetParent(body);
		headM.SetParent(head);
		LegML.SetParent(LegL);
		LegMR.SetParent(LegR);
		FootML.SetParent(FootL);
		FootMR.SetParent(FootR);
		TailM.SetParent(Tail);

		bodyH.SetParent(body);
		headH.SetParent(head);
		LegHL.SetParent(LegL);
		LegHR.SetParent(LegR);
		FootHL.SetParent(FootL);
		FootHR.SetParent(FootR);
		TailH.SetParent(Tail);

		#endregion

		CharacterBehaviour ch = root.gameObject.AddComponent<CharacterBehaviour>();
		ch.behaviourSetting.characterType = CharacterBehaviour.BehaviourSetting.CharacterType._2L;

		ResetCharacter(ch);
		ResetCharacterSetting(ch);

	}


	[MenuItem("GameObject/3D Object/_4L2H")]
	private static void Create4L2HCharacter () {

		#region --- Transform Init ---

		Transform root = new GameObject("New_4L2H").transform;
		Transform body = new GameObject("Body").transform;
		Transform head = new GameObject("Head").transform;
		Transform armL = new GameObject("ArmL").transform;
		Transform armR = new GameObject("ArmR").transform;
		Transform handL = new GameObject("HandL").transform;
		Transform handR = new GameObject("HandR").transform;
		Transform LegL = new GameObject("LegL").transform;
		Transform LegR = new GameObject("LegR").transform;
		Transform Leg2L = new GameObject("Leg2L").transform;
		Transform Leg2R = new GameObject("Leg2R").transform;
		Transform FootL = new GameObject("FootL").transform;
		Transform FootR = new GameObject("FootR").transform;
		Transform Foot2L = new GameObject("Foot2L").transform;
		Transform Foot2R = new GameObject("Foot2R").transform;
		Transform Tail = new GameObject("Tail").transform;
		Transform armML = new GameObject("_model").transform;
		Transform armMR = new GameObject("_model").transform;
		Transform handML = new GameObject("_model").transform;
		Transform handMR = new GameObject("_model").transform;
		Transform armHL = new GameObject("_holder").transform;
		Transform armHR = new GameObject("_holder").transform;
		Transform handHL = new GameObject("_holder").transform;
		Transform handHR = new GameObject("_holder").transform;

		Transform bodyM = new GameObject("_model").transform;
		Transform headM = new GameObject("_model").transform;
		Transform LegML = new GameObject("_model").transform;
		Transform LegMR = new GameObject("_model").transform;
		Transform Leg2ML = new GameObject("_model").transform;
		Transform Leg2MR = new GameObject("_model").transform;
		Transform FootML = new GameObject("_model").transform;
		Transform FootMR = new GameObject("_model").transform;
		Transform Foot2ML = new GameObject("_model").transform;
		Transform Foot2MR = new GameObject("_model").transform;
		Transform TailM = new GameObject("_model").transform;

		Transform bodyH = new GameObject("_holder").transform;
		Transform headH = new GameObject("_holder").transform;
		Transform LegHL = new GameObject("_holder").transform;
		Transform LegHR = new GameObject("_holder").transform;
		Transform Leg2HL = new GameObject("_holder").transform;
		Transform Leg2HR = new GameObject("_holder").transform;
		Transform FootHL = new GameObject("_holder").transform;
		Transform FootHR = new GameObject("_holder").transform;
		Transform Foot2HL = new GameObject("_holder").transform;
		Transform Foot2HR = new GameObject("_holder").transform;
		Transform TailH = new GameObject("_holder").transform;

		body.SetParent(root);
		head.SetParent(body);
		armL.SetParent(body);
		armR.SetParent(body);
		handL.SetParent(armL);
		handR.SetParent(armR);
		LegL.SetParent(body);
		LegR.SetParent(body);
		Leg2L.SetParent(body);
		Leg2R.SetParent(body);
		Tail.SetParent(body);
		FootL.SetParent(LegL);
		FootR.SetParent(LegR);
		Foot2L.SetParent(Leg2L);
		Foot2R.SetParent(Leg2R);
		
		
		bodyM.SetParent(body);
		headM.SetParent(head);
		LegML.SetParent(LegL);
		LegMR.SetParent(LegR);
		Leg2ML.SetParent(Leg2L);
		Leg2MR.SetParent(Leg2R);
		FootML.SetParent(FootL);
		FootMR.SetParent(FootR);
		Foot2ML.SetParent(Foot2L);
		Foot2MR.SetParent(Foot2R);
		TailM.SetParent(Tail);
		armML.SetParent(armL);
		armMR.SetParent(armR);
		handML.SetParent(handL);
		handMR.SetParent(handR);

		bodyH.SetParent(body);
		headH.SetParent(head);
		LegHL.SetParent(LegL);
		LegHR.SetParent(LegR);
		Leg2HL.SetParent(Leg2L);
		Leg2HR.SetParent(Leg2R);
		FootHL.SetParent(FootL);
		FootHR.SetParent(FootR);
		Foot2HL.SetParent(Foot2L);
		Foot2HR.SetParent(Foot2R);
		TailH.SetParent(Tail);
		armHL.SetParent(armL);
		armHR.SetParent(armR);
		handHL.SetParent(handL);
		handHR.SetParent(handR);

		#endregion

		CharacterBehaviour ch = root.gameObject.AddComponent<CharacterBehaviour>();
		ch.behaviourSetting.characterType = CharacterBehaviour.BehaviourSetting.CharacterType._4L2H;

		ResetCharacter(ch);
		ResetCharacterSetting(ch);

	}


	[MenuItem("GameObject/3D Object/_4L")]
	private static void Create4LCharacter () {

		#region --- Transform Init ---

		Transform root = new GameObject("New_4L").transform;
		Transform body = new GameObject("Body").transform;
		Transform head = new GameObject("Head").transform;
		Transform LegL = new GameObject("LegL").transform;
		Transform LegR = new GameObject("LegR").transform;
		Transform Leg2L = new GameObject("Leg2L").transform;
		Transform Leg2R = new GameObject("Leg2R").transform;
		Transform FootL = new GameObject("FootL").transform;
		Transform FootR = new GameObject("FootR").transform;
		Transform Foot2L = new GameObject("Foot2L").transform;
		Transform Foot2R = new GameObject("Foot2R").transform;
		Transform Tail = new GameObject("Tail").transform;

		Transform bodyM = new GameObject("_model").transform;
		Transform headM = new GameObject("_model").transform;
		Transform LegML = new GameObject("_model").transform;
		Transform LegMR = new GameObject("_model").transform;
		Transform Leg2ML = new GameObject("_model").transform;
		Transform Leg2MR = new GameObject("_model").transform;
		Transform FootML = new GameObject("_model").transform;
		Transform FootMR = new GameObject("_model").transform;
		Transform Foot2ML = new GameObject("_model").transform;
		Transform Foot2MR = new GameObject("_model").transform;
		Transform TailM = new GameObject("_model").transform;

		Transform bodyH = new GameObject("_holder").transform;
		Transform headH = new GameObject("_holder").transform;
		Transform LegHL = new GameObject("_holder").transform;
		Transform LegHR = new GameObject("_holder").transform;
		Transform Leg2HL = new GameObject("_holder").transform;
		Transform Leg2HR = new GameObject("_holder").transform;
		Transform FootHL = new GameObject("_holder").transform;
		Transform FootHR = new GameObject("_holder").transform;
		Transform Foot2HL = new GameObject("_holder").transform;
		Transform Foot2HR = new GameObject("_holder").transform;
		Transform TailH = new GameObject("_holder").transform;

		body.SetParent(root);
		head.SetParent(body);
		LegL.SetParent(body);
		LegR.SetParent(body);
		Leg2L.SetParent(body);
		Leg2R.SetParent(body);
		Tail.SetParent(body);
		FootL.SetParent(LegL);
		FootR.SetParent(LegR);
		Foot2L.SetParent(Leg2L);
		Foot2R.SetParent(Leg2R);

		bodyM.SetParent(body);
		headM.SetParent(head);
		LegML.SetParent(LegL);
		LegMR.SetParent(LegR);
		Leg2ML.SetParent(Leg2L);
		Leg2MR.SetParent(Leg2R);
		FootML.SetParent(FootL);
		FootMR.SetParent(FootR);
		Foot2ML.SetParent(Foot2L);
		Foot2MR.SetParent(Foot2R);
		TailM.SetParent(Tail);

		bodyH.SetParent(body);
		headH.SetParent(head);
		LegHL.SetParent(LegL);
		LegHR.SetParent(LegR);
		Leg2HL.SetParent(Leg2L);
		Leg2HR.SetParent(Leg2R);
		FootHL.SetParent(FootL);
		FootHR.SetParent(FootR);
		Foot2HL.SetParent(Foot2L);
		Foot2HR.SetParent(Foot2R);
		TailH.SetParent(Tail);

		#endregion

		CharacterBehaviour ch = root.gameObject.AddComponent<CharacterBehaviour>();
		ch.behaviourSetting.characterType = CharacterBehaviour.BehaviourSetting.CharacterType._4L;
		
		ResetCharacter(ch);
		ResetCharacterSetting(ch);

	}






	void OnEnable () {
		if (target && target is CharacterBehaviour) {
			Item item = ((CharacterBehaviour)target).HoldingItemL ?? ((CharacterBehaviour)target).HoldingItemR;
			WeaponObj = item ? item.gameObject : null;
		}
		QSetupOpen = EditorPrefs.GetBool("MoenenVoxel_Character.CharacterBehaviourInspector.QSetupOpen", false);
		HelpBoxOpen = EditorPrefs.GetBool("MoenenVoxel_Character.CharacterBehaviourInspector.HelpBoxOpen", false);
		TryResetCharacter();
	}



	public override void OnInspectorGUI () {

		base.DrawDefaultInspector();

		CharacterBehaviour ch = (CharacterBehaviour)target;

		if (!ch) {
			return;
		}

		Rect foldoutRect = GUILayoutUtility.GetRect(0f, 24f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true));

		GUI.Label(foldoutRect, "Tools");

		foldoutRect.x -= 12f;

		QSetupOpen = EditorGUI.Toggle(
			foldoutRect,
			QSetupOpen, GUI.skin.GetStyle("foldout")
		);

		if (QSetupOpen) {

			GUILayout.BeginHorizontal();

			#region --- Organ ---

			if (GUI.Button(
				GUILayoutUtility.GetRect(0f, 24f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true)),
				"Fix Organ")
			) {
				FixOrgan();
				TryResetCharacter();
				ApplyPrefab();
			}

			#endregion

			
			#region --- Reset Setting ---


			Rect resetSettingRect = GUILayoutUtility.GetRect(0f, 24f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true));
			if (GUI.Button(resetSettingRect, "ResetSetting")) {
				ResetCharacterSetting();
				ApplyPrefab();
			}

			if (targets.Length == 1 && NeedResetSetting(ch)) {
				GUI.DrawTexture(resetSettingRect, GreenPannel);
			}


			#endregion


			#region --- Fix Component ---

			Rect fixComponentRect = GUILayoutUtility.GetRect(0f, 24f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true));

			if (GUI.Button(fixComponentRect, "Fix Cmpnent")) {
				FixComponents();
				ApplyPrefab();
			}

			if (targets.Length == 1 && NeedFixComponent(ch)) {
				GUI.DrawTexture(fixComponentRect, GreenPannel);
			}
			

			#endregion

			GUILayout.EndHorizontal(); 

			GUILayout.Space(6f);

			#region --- Switch ---

			Rect switchRect = GUILayoutUtility.GetRect(0f, 20f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true));

			if (ch.gameObject.GetComponent<PlayerBehaviour>()) {
				if (GUI.Button(switchRect, "Switch To CharacterBehaviour")) {
					ToCharacterBehavior(ch);
				}
				GUI.DrawTexture(switchRect, OrangePannel);
			} else {
				if (GUI.Button(switchRect, "Switch To PlayerBehaviour")) {
					ToPlayerBehavior(ch);
				}
				GUI.DrawTexture(switchRect, RedPannel);
			}

			

			#endregion

			GUILayout.Space(10f);


			#region --- Quick Setup ---

			GUILayout.BeginHorizontal();

			Rect rect0 = GUILayoutUtility.GetRect(0f, 24f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true));

			GUILayout.Space(1f);

			if (GUI.Button(GUILayoutUtility.GetRect(24f, 24f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(false)), "?")) {
				HelpBoxOpen = !HelpBoxOpen;
			}

			GUI.Box(rect0, "<b>Drag Prefabs HERE</b>", QSetUpStyle);


			GUILayout.EndHorizontal();


			GUILayout.Space(6f);

			Rect infoRect = new Rect();

			if (HelpBoxOpen) {
				string infoStr = "Drag prefabs to set up this character's models.\nYou can also drag a folder with those prefabs.\nThe prefabs should named as:\n<color=#339933FF>Head, Body, Arm, Hand, Leg, Foot,\nArmL, ArmR, HandL, HandR,\nLegL, LegR, FootL, FootR,\nArmLeg, LegArm, HandFoot, FootHand,\nArm_Leg, Leg_Arm, Foot_Hand, Hand_Foot,\nBody_Head, Head_Body, BodyHead, HeadBody,\nLegFoot, FootLeg, Leg_Foot, Foot_Leg,\nArmHand, HandArm, Arm_Hand, Hand_Arm</color>\n(Yes, me OCD...)";
				infoRect = GUILayoutUtility.GetRect(0f, 230f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true));
				GUI.Box(infoRect, infoStr, QSetUpInfoStyle);
			}
			
			if (Event.current.type == EventType.DragPerform || Event.current.type == EventType.DragUpdated) {

				if (rect0.Contains(Event.current.mousePosition) || infoRect.Contains(Event.current.mousePosition)) {

					DragAndDrop.visualMode = DragAndDropVisualMode.Link;

					if (Event.current.type == EventType.DragPerform) {
						DragAndDrop.AcceptDrag();
						foreach (string path in DragAndDrop.paths) {
							if (Path.GetExtension(path) == "") {
								ClearModels(ch);
								string name = Path.GetFileNameWithoutExtension(path);
								ch.transform.name = name;
								FileInfo[] infos = new DirectoryInfo(path).GetFiles();
								foreach (FileInfo info in infos) {
									GameObject o = AssetDatabase.LoadAssetAtPath<GameObject>(PathUtil_Editor.GetReletivePath(info.FullName));
									if (o) {
										StartQuickSetUp(o);
									}
								}
								break;
							} else {
								GameObject o = AssetDatabase.LoadAssetAtPath<GameObject>(path);
								if (o) {
									StartQuickSetUp(o);
								}
							}
						}
						//FixOrgan();
						TryResetCharacter();
						ResetCharacterSetting();
						FixComponents();
						ApplyPrefab();
						Event.current.Use();
					}
				}
			}

			#endregion



			if (ch.behaviourSetting.HasHand) {

				GUILayout.Space(6f);

				#region --- Weapon ---

				Object currentObj = EditorGUI.ObjectField(
					GUILayoutUtility.GetRect(0f, 16f, GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(true)),
					"Weapon",
					WeaponObj,
					typeof(GameObject),
					false
				);


				if (currentObj != WeaponObj) {
					WeaponObj = currentObj;

					bool oldActive = ch.gameObject.activeSelf;
					ch.gameObject.SetActive(true);
					if (ch.itemHolder.HandLHolder != null) {
						if (WeaponObj) {
							Transform tf = Item.SpawnItem(((GameObject)WeaponObj).GetComponent<Item>());
							if (tf != null) {
								if (tf.gameObject.GetComponent<Weapon>() != null) {
									ch.SetItem(tf.gameObject.GetComponent<Weapon>());
								}
							}
						} else {
							ch.SetItem((Weapon)null);
						}
						ApplyPrefab();
					}
					ch.gameObject.SetActive(oldActive);

				}
				


				GUILayout.Space(6f);

				#endregion

			}

		}
		

		if (GUI.changed) {
			EditorPrefs.SetBool("MoenenVoxel_Character.CharacterBehaviourInspector.QSetupOpen", QSetupOpen);
			EditorPrefs.SetBool("MoenenVoxel_Character.CharacterBehaviourInspector.HelpBoxOpen", HelpBoxOpen);
		}



	}


	#endregion



	#region -------- LGC --------



	#region --- Reset ---


	private void TryResetCharacter () {
		foreach (Object o in targets) {
			CharacterBehaviour ch = (CharacterBehaviour)o;
			if(!ch){
				continue;
			}
			if (NeedReset(ch)) {
				ResetCharacter(ch);
				ApplyPrefab(ch);
			}
		}
	}

	private static void ResetCharacter (CharacterBehaviour ch) {

		if (!ch) {
			return;
		}

		Transform tf = ch.gameObject.transform;

		ch.characterOrgan.Head = tf.Find("Body/Head");
		ch.characterOrgan.Body = tf.Find("Body");
		ch.characterOrgan.ArmL = tf.Find("Body/ArmL");
		ch.characterOrgan.ArmR = tf.Find("Body/ArmR");
		ch.characterOrgan.HandL = tf.Find("Body/ArmL/HandL");
		ch.characterOrgan.HandR = tf.Find("Body/ArmR/HandR");
		ch.characterOrgan.LegL = tf.Find("Body/LegL");
		ch.characterOrgan.LegR = tf.Find("Body/LegR");
		ch.characterOrgan.FootL = tf.Find("Body/LegL/FootL");
		ch.characterOrgan.FootR = tf.Find("Body/LegR/FootR");
		ch.characterOrgan.Leg2L = tf.Find("Body/Leg2L");
		ch.characterOrgan.Leg2R = tf.Find("Body/Leg2R");
		ch.characterOrgan.Foot2L = tf.Find("Body/Leg2L/Foot2L");
		ch.characterOrgan.Foot2R = tf.Find("Body/Leg2R/Foot2R");
		ch.characterOrgan.Tail = tf.Find("Body/Tail");


		if (ch.characterOrgan.Head) { ch.characterOrgan.Head.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.Body) { ch.characterOrgan.Body.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.ArmL) { ch.characterOrgan.ArmL.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.ArmR) { ch.characterOrgan.ArmR.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.HandL) { ch.characterOrgan.HandL.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.HandR) { ch.characterOrgan.HandR.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.LegL) { ch.characterOrgan.LegL.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.LegR) { ch.characterOrgan.LegR.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.FootL) { ch.characterOrgan.FootL.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.FootR) { ch.characterOrgan.FootR.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.Leg2L) { ch.characterOrgan.Leg2L.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.Leg2R) { ch.characterOrgan.Leg2R.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.Foot2L) { ch.characterOrgan.Foot2L.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.Foot2R) { ch.characterOrgan.Foot2R.localRotation = Quaternion.identity; }
		if (ch.characterOrgan.Tail) { ch.characterOrgan.Tail.localRotation = Quaternion.identity; }


		ch.characterModel.HeadModel = tf.Find("Body/Head/_model");
		ch.characterModel.BodyModel = tf.Find("Body/_model");
		ch.characterModel.ArmLModel = tf.Find("Body/ArmL/_model");
		ch.characterModel.ArmRModel = tf.Find("Body/ArmR/_model");
		ch.characterModel.HandLModel = tf.Find("Body/ArmL/HandL/_model");
		ch.characterModel.HandRModel = tf.Find("Body/ArmR/HandR/_model");
		ch.characterModel.LegLModel = tf.Find("Body/LegL/_model");
		ch.characterModel.LegRModel = tf.Find("Body/LegR/_model");
		ch.characterModel.FootLModel = tf.Find("Body/LegL/FootL/_model");
		ch.characterModel.FootRModel = tf.Find("Body/LegR/FootR/_model");
		ch.characterModel.Leg2LModel = tf.Find("Body/Leg2L/_model");
		ch.characterModel.Leg2RModel = tf.Find("Body/Leg2R/_model");
		ch.characterModel.Foot2LModel = tf.Find("Body/Leg2L/Foot2L/_model");
		ch.characterModel.Foot2RModel = tf.Find("Body/Leg2R/Foot2R/_model");
		ch.characterModel.TailModel = tf.Find("Body/Tail/_model");


		ch.itemHolder.HeadHolder = tf.Find("Body/Head/_holder");
		ch.itemHolder.BodyHolder = tf.Find("Body/_holder");
		ch.itemHolder.ArmLHolder = tf.Find("Body/ArmL/_holder");
		ch.itemHolder.ArmRHolder = tf.Find("Body/ArmR/_holder");
		ch.itemHolder.HandLHolder = tf.Find("Body/ArmL/HandL/_holder");
		ch.itemHolder.HandRHolder = tf.Find("Body/ArmR/HandR/_holder");
		ch.itemHolder.LegLHolder = tf.Find("Body/LegL/_holder");
		ch.itemHolder.LegRHolder = tf.Find("Body/LegR/_holder");
		ch.itemHolder.FootLHolder = tf.Find("Body/LegL/FootL/_holder");
		ch.itemHolder.FootRHolder = tf.Find("Body/LegR/FootR/_holder");
		ch.itemHolder.Leg2LHolder = tf.Find("Body/Leg2L/_holder");
		ch.itemHolder.Leg2RHolder = tf.Find("Body/Leg2R/_holder");
		ch.itemHolder.Foot2LHolder = tf.Find("Body/Leg2L/Foot2L/_holder");
		ch.itemHolder.Foot2RHolder = tf.Find("Body/Leg2R/Foot2R/_holder");
		ch.itemHolder.TailHolder = tf.Find("Body/Tail/_holder");


		if (ch) {
			if (ch.itemHolder.HeadHolder) { ch.itemHolder.HeadHolder.position = ch.characterModel.HeadModel.position; }
			if (ch.itemHolder.BodyHolder) { ch.itemHolder.BodyHolder.position = ch.characterModel.BodyModel.position; }
			if (ch.itemHolder.ArmLHolder) { ch.itemHolder.ArmLHolder.position = ch.characterModel.ArmLModel.position; }
			if (ch.itemHolder.ArmRHolder) { ch.itemHolder.ArmRHolder.position = ch.characterModel.ArmRModel.position; }
			if (ch.itemHolder.HandLHolder) { ch.itemHolder.HandLHolder.position = ch.characterModel.HandLModel.position; }
			if (ch.itemHolder.HandRHolder) { ch.itemHolder.HandRHolder.position = ch.characterModel.HandRModel.position; }
			if (ch.itemHolder.LegLHolder) { ch.itemHolder.LegLHolder.position = ch.characterModel.LegLModel.position; }
			if (ch.itemHolder.LegRHolder) { ch.itemHolder.LegRHolder.position = ch.characterModel.LegRModel.position; }
			if (ch.itemHolder.FootLHolder) { ch.itemHolder.FootLHolder.position = ch.characterModel.FootLModel.position; }
			if (ch.itemHolder.FootRHolder) { ch.itemHolder.FootRHolder.position = ch.characterModel.FootRModel.position; }
			if (ch.itemHolder.Leg2LHolder) { ch.itemHolder.Leg2LHolder.position = ch.characterModel.Leg2LModel.position; }
			if (ch.itemHolder.Leg2RHolder) { ch.itemHolder.Leg2RHolder.position = ch.characterModel.Leg2RModel.position; }
			if (ch.itemHolder.Foot2LHolder) { ch.itemHolder.Foot2LHolder.position = ch.characterModel.Foot2LModel.position; }
			if (ch.itemHolder.Foot2RHolder) { ch.itemHolder.Foot2RHolder.position = ch.characterModel.Foot2RModel.position; }
			if (ch.itemHolder.TailHolder) { ch.itemHolder.TailHolder.position = ch.characterModel.TailModel.position; }
		}


	}

	private static bool NeedReset (CharacterBehaviour ch) {
		if (!ch.characterOrgan.Head) { return true; }
		if (!ch.characterOrgan.Body) { return true; }
		if (ch.behaviourSetting.HasHand && !ch.characterOrgan.ArmL) { return true; }
		if (ch.behaviourSetting.HasHand && !ch.characterOrgan.ArmR) { return true; }
		if (ch.behaviourSetting.HasHand && !ch.characterOrgan.HandL) { return true; }
		if (ch.behaviourSetting.HasHand && !ch.characterOrgan.HandR) { return true; }
		if (!ch.characterOrgan.LegL) { return true; }
		if (!ch.characterOrgan.LegR) { return true; }
		if (!ch.behaviourSetting.Has2L && !ch.characterOrgan.Leg2L) { return true; }
		if (!ch.behaviourSetting.Has2L && !ch.characterOrgan.Leg2R) { return true; }
		if (!ch.characterOrgan.FootL) { return true; }
		if (!ch.characterOrgan.FootR) { return true; }
		if (!ch.behaviourSetting.Has2L && !ch.characterOrgan.Foot2L) { return true; }
		if (!ch.behaviourSetting.Has2L && !ch.characterOrgan.Foot2R) { return true; }
		if (!ch.behaviourSetting.Has2L && !ch.characterOrgan.Tail) { return true; }
		return false;
	}

	
	#endregion



	#region --- Reset Setting ---

	private void ResetCharacterSetting () {
		foreach (Object o in targets) {
			ResetCharacterSetting((CharacterBehaviour)o);
		}
	}

	private static void ResetCharacterSetting (CharacterBehaviour ch) {
		ch.behaviourSetting.RunSpeed = 6f;
		ch.behaviourSetting.WalkSpeed = 2f;
		ch.behaviourSetting.JumpPower = 16;
		ch.behaviourSetting.JumpCount = 2;
		ch.behaviourSetting.DashSpeed = 24f;
		ch.behaviourSetting.DashDistance = 3f;
		ch.behaviourSetting.DashGap = 0.2f;
		ch.behaviourSetting.DefaultHand.Default();
	}

	private static bool NeedResetSetting (CharacterBehaviour ch) {
		return ch.behaviourSetting.RunSpeed == 0f ||
			ch.behaviourSetting.WalkSpeed == 0f ||
			ch.behaviourSetting.DashSpeed == 0f ||
			ch.behaviourSetting.DashGap == 0f ||
			ch.behaviourSetting.DefaultHand.AttackSpeed1 == 0f ||
			ch.behaviourSetting.DefaultHand.AttackSpeed2 == 0f ||
			ch.behaviourSetting.DefaultHand.AttackRange == 0f;
	}


	#endregion



	#region --- Quick Setup ---

	private void StartQuickSetUp (GameObject o) {
		foreach (Object obj in targets) {
			CharacterBehaviour ch = (CharacterBehaviour)obj;
			if (!ch) {
				continue;
			}
			switch (ch.behaviourSetting.characterType) {
				case CharacterBehaviour.BehaviourSetting.CharacterType._2L2H:
					StartQuickSetUp_2L2H(ch, o);
					break;
				case CharacterBehaviour.BehaviourSetting.CharacterType._2L:
					StartQuickSetUp_2L(ch, o);
					break;
				case CharacterBehaviour.BehaviourSetting.CharacterType._4L2H:
					StartQuickSetUp_4L2H(ch, o);
					break;
				case CharacterBehaviour.BehaviourSetting.CharacterType._4L:
					StartQuickSetUp_4L(ch, o);
					break;
			}
		}
	}

	private static void StartQuickSetUp_2L2H (CharacterBehaviour ch, GameObject o) {
		if (!ch) {
			return;
		}
		switch (o.name.ToLower()) {
			case "arm_leg":
			case "armleg":
			case "leg_arm":
			case "legarm":
				QuickSetUp("Body/ArmL/_model", o, ch);
				QuickSetUp("Body/ArmR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;
			case "arml":
				QuickSetUp("Body/ArmL/_model", o, ch);
				break;
			case "armr":
				QuickSetUp("Body/ArmR/_model", o, ch);
				break;
			case "arm":
				QuickSetUp("Body/ArmL/_model", o, ch);
				QuickSetUp("Body/ArmR/_model", o, ch);
				break;
			case "legl":
				QuickSetUp("Body/LegL/_model", o, ch);
				break;
			case "legr":
				QuickSetUp("Body/LegR/_model", o, ch);
				break;
			case "leg":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;
			case "footl":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				break;
			case "footr":
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;
			case "foot":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;
			case "legfoot":
			case "footleg":
			case "leg_foot":
			case "foot_leg":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;
			case "armhand":
			case "handarm":
			case "arm_hand":
			case "hand_arm":
				QuickSetUp("Body/ArmL/HandL/_model", o, ch);
				QuickSetUp("Body/ArmR/HandR/_model", o, ch);
				QuickSetUp("Body/ArmL/_model", o, ch);
				QuickSetUp("Body/ArmR/_model", o, ch);
				break;
			case "foot_hand":
			case "foothand":
			case "hand_foot":
			case "handfoot":
				QuickSetUp("Body/ArmL/HandL/_model", o, ch);
				QuickSetUp("Body/ArmR/HandR/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;
			case "hand":
				QuickSetUp("Body/ArmL/HandL/_model", o, ch);
				QuickSetUp("Body/ArmR/HandR/_model", o, ch);
				break;
			case "handl":
				QuickSetUp("Body/ArmL/HandL/_model", o, ch);
				break;
			case "handr":
				QuickSetUp("Body/ArmR/HandR/_model", o, ch);
				break;
			case "head":
				QuickSetUp("Body/Head/_model", o, ch);
				break;
			case "body":
			case "body_head":
			case "head_body":
			case "bodyhead":
			case "headbody":
				QuickSetUp("Body/_model", o, ch);
				break;
		}
	}

	private static void StartQuickSetUp_2L (CharacterBehaviour ch, GameObject o) {
		if (!ch) {
			return;
		}
		switch (o.name.ToLower()) {
			case "head":
				QuickSetUp("Body/Head/_model", o, ch);
				break;

			case "body":
			case "body_head":
			case "head_body":
			case "bodyhead":
			case "headbody":
				QuickSetUp("Body/_model", o, ch);
				break;

			case "tail":
				QuickSetUp("Body/Tail/_model", o, ch);
				break;



			case "arml":
				QuickSetUp("Body/LegL/_model", o, ch);
				break;
			case "armr":
				QuickSetUp("Body/LegR/_model", o, ch);
				break;
			case "arm":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;

			case "legl":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				break;
			case "legr":
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;
			case "leg":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;

			case "hand":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;
			case "handl":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				break;
			case "handr":
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;

			case "footl":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				break;
			case "footr":
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;
			case "foot":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;



			case "legfoot":
			case "footleg":
			case "leg_foot":
			case "foot_leg":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;

			case "armhand":
			case "handarm":
			case "arm_hand":
			case "hand_arm":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;

			case "foot_hand":
			case "foothand":
			case "hand_foot":
			case "handfoot":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;

			case "arm_leg":
			case "armleg":
			case "leg_arm":
			case "legarm":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;

		}
	}

	private static void StartQuickSetUp_4L2H (CharacterBehaviour ch, GameObject o) {
		if (!ch) {
			return;
		}
		switch (o.name.ToLower()) {
			case "head":
				QuickSetUp("Body/Head/_model", o, ch);
				break;

			case "body":
			case "body_head":
			case "head_body":
			case "bodyhead":
			case "headbody":
				QuickSetUp("Body/_model", o, ch);
				break;

			case "tail":
				QuickSetUp("Body/Tail/_model", o, ch);
				break;



			case "arml":
				QuickSetUp("Body/ArmL/_model", o, ch);
				break;
			case "armr":
				QuickSetUp("Body/ArmR/_model", o, ch);
				break;
			case "arm":
				QuickSetUp("Body/ArmL/_model", o, ch);
				QuickSetUp("Body/ArmR/_model", o, ch);
				break;

			case "legl":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/Leg2L/_model", o, ch);
				break;
			case "legr":
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/Leg2R/_model", o, ch);
				break;
			case "leg":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/Leg2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/_model", o, ch);
				break;

			case "hand":
				QuickSetUp("Body/ArmL/HandL/_model", o, ch);
				QuickSetUp("Body/ArmR/HandR/_model", o, ch);
				break;
			case "handl":
				QuickSetUp("Body/ArmL/HandL/_model", o, ch);
				break;
			case "handr":
				QuickSetUp("Body/ArmR/HandR/_model", o, ch);
				break;

			case "footl":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/Leg2L/Foot2L/_model", o, ch);
				break;
			case "footr":
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/Leg2R/Foot2R/_model", o, ch);
				break;
			case "foot":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/Leg2L/Foot2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/Foot2R/_model", o, ch);
				break;



			case "legfoot":
			case "footleg":
			case "leg_foot":
			case "foot_leg":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/Leg2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/Leg2L/Foot2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/Foot2R/_model", o, ch);
				break;

			case "armhand":
			case "handarm":
			case "arm_hand":
			case "hand_arm":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;

			case "foot_hand":
			case "foothand":
			case "hand_foot":
			case "handfoot":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/Leg2L/Foot2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/Foot2R/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;

			case "arm_leg":
			case "armleg":
			case "leg_arm":
			case "legarm":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/Leg2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;

		}
	}

	private static void StartQuickSetUp_4L (CharacterBehaviour ch, GameObject o) {
		if (!ch) {
			return;
		}
		switch (o.name.ToLower()) {
			case "head":
				QuickSetUp("Body/Head/_model", o, ch);
				break;

			case "body":
			case "body_head":
			case "head_body":
			case "bodyhead":
			case "headbody":
				QuickSetUp("Body/_model", o, ch);
				break;

			case "tail":
				QuickSetUp("Body/Tail/_model", o, ch);
				break;

			

			case "arml":
				QuickSetUp("Body/LegL/_model", o, ch);
				break;
			case "armr":
				QuickSetUp("Body/LegR/_model", o, ch);
				break;
			case "arm":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;

			case "legl":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/Leg2L/_model", o, ch);
				break;
			case "legr":
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/Leg2R/_model", o, ch);
				break;
			case "leg":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/Leg2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/_model", o, ch);
				break;

			case "hand":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;
			case "handl":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				break;
			case "handr":
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;

			case "footl":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/Leg2L/Foot2L/_model", o, ch);
				break;
			case "footr":
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/Leg2R/Foot2R/_model", o, ch);
				break;
			case "foot":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/Leg2L/Foot2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/Foot2R/_model", o, ch);
				break;



			case "legfoot":
			case "footleg":
			case "leg_foot":
			case "foot_leg":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/Leg2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/Leg2L/Foot2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/Foot2R/_model", o, ch);
				break;

			case "armhand":
			case "handarm":
			case "arm_hand":
			case "hand_arm":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;

			case "foot_hand":
			case "foothand":
			case "hand_foot":
			case "handfoot":
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				QuickSetUp("Body/Leg2L/Foot2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/Foot2R/_model", o, ch);
				QuickSetUp("Body/LegL/FootL/_model", o, ch);
				QuickSetUp("Body/LegR/FootR/_model", o, ch);
				break;

			case "arm_leg":
			case "armleg":
			case "leg_arm":
			case "legarm":
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				QuickSetUp("Body/Leg2L/_model", o, ch);
				QuickSetUp("Body/Leg2R/_model", o, ch);
				QuickSetUp("Body/LegL/_model", o, ch);
				QuickSetUp("Body/LegR/_model", o, ch);
				break;
			
		}
	}

	private static void QuickSetUp (string path, GameObject o, CharacterBehaviour ch) {
		if (!ch) {
			return;
		}
		GameObject o1;
		Transform tf = ch.transform.Find(path);
		if (tf.childCount > 0) {
			Transform t = tf.Find(o.name);
			while (t) {
				DestroyImmediate(t.gameObject, false);
				t = tf.Find(o.name);
			}
		}
		o1 = Instantiate(o);
		o1.transform.SetParent(tf);
		o1.transform.localPosition = Vector3.zero;
		o1.transform.localRotation = Quaternion.identity;
		o1.transform.localScale = Vector3.one;
		o1.name = o.name;
	}

	#endregion



	#region --- Fix Organ ---

	private void FixOrgan () {
		foreach (Object o in targets) {
			CharacterBehaviour ch = (CharacterBehaviour)o;
			if (!ch) {
				continue;
			}
			switch (ch.behaviourSetting.characterType) {
				case CharacterBehaviour.BehaviourSetting.CharacterType._2L2H:
					FixOrgan_2L2H(ch);
					break;
				case CharacterBehaviour.BehaviourSetting.CharacterType._2L:
					FixOrgan_2L(ch);
					break;
				case CharacterBehaviour.BehaviourSetting.CharacterType._4L2H:
					FixOrgan_4L2H(ch);
					break;
				case CharacterBehaviour.BehaviourSetting.CharacterType._4L:
					FixOrgan_4L(ch);
					break;
			}
		}
	}

	private static void FixOrgan_2L2H (CharacterBehaviour ch) {

		if (!ch.behaviourSetting.Is2L2H) {
			return;
		}

		Vector3 bodyPos, headPos, ArmPos, LegPos, HandPos, FootPos;
		Vector3 bodyMPos, headMPos, ArmMPos, LegMPos, HandMPos, FootMPos;

		Vector3 bodySize = MeshUtil.GetMeshSize(ch.characterModel.BodyModel);
		Vector3 legSize = MeshUtil.GetMeshSize(ch.characterModel.LegLModel);
		Vector3 footSize = MeshUtil.GetMeshSize(ch.characterModel.FootLModel);
		Vector3 armSize = MeshUtil.GetMeshSize(ch.characterModel.ArmLModel);
		Vector3 handSize = MeshUtil.GetMeshSize(ch.characterModel.HandLModel);
		Vector3 bodyLMin, bodyLMax;
		MeshUtil.GetExtremeMargin(ch.characterModel.BodyModel, out bodyLMin, out bodyLMax, MeshUtil.Direction.Left);
		Vector3 bodyBMin, bodyBMax;
		MeshUtil.GetExtremeMargin(ch.characterModel.BodyModel, out bodyBMin, out bodyBMax, MeshUtil.Direction.Bottom);
		Vector3 footTAvr = MeshUtil.GetExtremeAverage(ch.characterModel.FootLModel, MeshUtil.Direction.Top);
		Vector3 handBAvr = MeshUtil.GetExtremeAverage(ch.characterModel.HandLModel, MeshUtil.Direction.Bottom);
		Vector3 bodyTAvr = MeshUtil.GetExtremeAverage(ch.characterModel.BodyModel, MeshUtil.Direction.Top);
		Vector3 headBAvr = MeshUtil.GetExtremeAverage(ch.characterModel.HeadModel, MeshUtil.Direction.Bottom);


		bodyPos = Vector3.zero;
		bodyMPos = new Vector3(0f, legSize.y + footSize.y, 0f);
		headPos = new Vector3(0f, bodyMPos.y + bodySize.y, bodyTAvr.z);
		headMPos = new Vector3(0f, 0f, -headBAvr.z);
		ArmPos = new Vector3(-bodySize.x * 0.5f - armSize.x * 0.5f, bodyMPos.y + bodyLMax.y - 0.05f, 0f);
		ArmMPos = new Vector3(0f, -armSize.y, 0f);
		HandPos = new Vector3(0f, -armSize.y, 0f);
		HandMPos = new Vector3(0f, -handSize.y, -handBAvr.z);
		LegPos = new Vector3(bodyBMin.x + 0.05f, legSize.y + footSize.y, 0f);
		LegMPos = new Vector3(0f, -legSize.y, 0f);
		FootPos = new Vector3(0f, -legSize.y, 0f);
		FootMPos = new Vector3(0f, -footSize.y, -footTAvr.z);


		ch.characterOrgan.Body.localPosition = bodyPos;
		ch.characterOrgan.Head.localPosition = headPos;
		ch.characterOrgan.ArmL.localPosition = ArmPos;
		ArmPos.x *= -1f;
		ch.characterOrgan.ArmR.localPosition = ArmPos;
		ch.characterOrgan.LegL.localPosition = LegPos;
		LegPos.x *= -1f;
		ch.characterOrgan.LegR.localPosition = LegPos;
		ch.characterOrgan.HandL.localPosition = HandPos;
		ch.characterOrgan.HandR.localPosition = HandPos;
		ch.characterOrgan.FootL.localPosition = FootPos;
		ch.characterOrgan.FootR.localPosition = FootPos;

		ch.characterModel.BodyModel.localPosition = bodyMPos;
		ch.characterModel.HeadModel.localPosition = headMPos;
		ch.characterModel.ArmLModel.localPosition = ArmMPos;
		ch.characterModel.ArmRModel.localPosition = ArmMPos;
		ch.characterModel.LegLModel.localPosition = LegMPos;
		ch.characterModel.LegRModel.localPosition = LegMPos;
		ch.characterModel.HandLModel.localPosition = HandMPos;
		ch.characterModel.HandRModel.localPosition = HandMPos;
		ch.characterModel.FootLModel.localPosition = FootMPos;
		ch.characterModel.FootRModel.localPosition = FootMPos;

	}

	private static void FixOrgan_2L (CharacterBehaviour ch) {

		if (!ch.behaviourSetting.Is2L) {
			return;
		}

		Vector3 bodyPos, headPos, LegPos, FootPos, TailPos;
		Vector3 bodyMPos, headMPos, LegMPos, FootMPos, TailMPos;

		Vector3 bodySize = MeshUtil.GetMeshSize(ch.characterModel.BodyModel);
		Vector3 tailSize = MeshUtil.GetMeshSize(ch.characterModel.TailModel);
		Vector3 headSize = MeshUtil.GetMeshSize(ch.characterModel.HeadModel);
		Vector3 footSize = MeshUtil.GetMeshSize(ch.characterModel.FootLModel);
		Vector3 legSize = MeshUtil.GetMeshSize(ch.characterModel.LegLModel);
		Vector3 bodyLMin, bodyLMax;
		MeshUtil.GetExtremeMargin(ch.characterModel.BodyModel, out bodyLMin, out bodyLMax, MeshUtil.Direction.Left);
		Vector3 foot2TAvr = MeshUtil.GetExtremeAverage(ch.characterModel.Foot2LModel, MeshUtil.Direction.Top);
		Vector3 bodyBAvr = MeshUtil.GetExtremeAverage(ch.characterModel.BodyModel, MeshUtil.Direction.Back);
		Vector3 bodyBoAvr = MeshUtil.GetExtremeAverage(ch.characterModel.BodyModel, MeshUtil.Direction.Bottom);
		Vector3 bodyFAvr = MeshUtil.GetExtremeAverage(ch.characterModel.BodyModel, MeshUtil.Direction.Front);
		Vector3 headFAvr = MeshUtil.GetExtremeAverage(ch.characterModel.HeadModel, MeshUtil.Direction.Front);


		bodyPos = Vector3.zero;
		bodyMPos = new Vector3(0f, legSize.y + footSize.y - bodyLMin.y, 0f);
		headPos = new Vector3(0f, bodyMPos.y + bodyBAvr.y, -bodySize.z * 0.5f);
		headMPos = new Vector3(0f, -headFAvr.y, -headSize.z * 0.5f);
		LegPos = new Vector3(bodyLMin.x + legSize.x * 0.5f, legSize.y + footSize.y, bodyBoAvr.z);
		LegMPos = new Vector3(0f, -legSize.y, 0f);
		FootPos = new Vector3(0f, -legSize.y, 0f);
		FootMPos = new Vector3(0f, -footSize.y, -foot2TAvr.z);
		TailPos = new Vector3(0f, bodyFAvr.y + bodyMPos.y, bodyFAvr.z);
		TailMPos = new Vector3(0f, -tailSize.y + 0.05f, tailSize.z * 0.5f);

		ch.characterOrgan.Body.localPosition = bodyPos;
		ch.characterOrgan.Head.localPosition = headPos;
		ch.characterOrgan.LegL.localPosition = LegPos;
		LegPos.x *= -1f;
		ch.characterOrgan.LegR.localPosition = LegPos;
		ch.characterOrgan.FootL.localPosition = FootPos;
		ch.characterOrgan.FootR.localPosition = FootPos;
		ch.characterOrgan.Tail.localPosition = TailPos;

		ch.characterModel.BodyModel.localPosition = bodyMPos;
		ch.characterModel.HeadModel.localPosition = headMPos;
		ch.characterModel.LegLModel.localPosition = LegMPos;
		ch.characterModel.LegRModel.localPosition = LegMPos;
		ch.characterModel.FootLModel.localPosition = FootMPos;
		ch.characterModel.FootRModel.localPosition = FootMPos;
		ch.characterModel.TailModel.localPosition = TailMPos;

	}

	private static void FixOrgan_4L2H (CharacterBehaviour ch) {

		if (!ch.behaviourSetting.Is4L2H) {
			return;
		}

		Vector3 bodyPos, headPos, LegPos, ArmPos, HandPos, Leg2Pos, FootPos, Foot2Pos, TailPos;
		Vector3 bodyMPos, headMPos, LegMPos, ArmMPos, HandMPos, Leg2MPos, FootMPos, Foot2MPos, TailMPos;

		Vector3 bodySize = MeshUtil.GetMeshSize(ch.characterModel.BodyModel);
		Vector3 tailSize = MeshUtil.GetMeshSize(ch.characterModel.TailModel);
		Vector3 headSize = MeshUtil.GetMeshSize(ch.characterModel.HeadModel);
		Vector3 armSize = MeshUtil.GetMeshSize(ch.characterModel.ArmLModel);
		Vector3 handSize = MeshUtil.GetMeshSize(ch.characterModel.HandLModel);
		Vector3 leg2Size = MeshUtil.GetMeshSize(ch.characterModel.Leg2LModel);
		Vector3 foot2Size = MeshUtil.GetMeshSize(ch.characterModel.Foot2LModel);
		Vector3 legSize = MeshUtil.GetMeshSize(ch.characterModel.LegLModel);
		Vector3 footSize = MeshUtil.GetMeshSize(ch.characterModel.FootLModel);
		Vector3 bodyLMin, bodyLMax;
		MeshUtil.GetExtremeMargin(ch.characterModel.BodyModel, out bodyLMin, out bodyLMax, MeshUtil.Direction.Left);
		Vector3 foot2TAvr = MeshUtil.GetExtremeAverage(ch.characterModel.Foot2LModel, MeshUtil.Direction.Top);
		Vector3 bodyBAvr = MeshUtil.GetExtremeAverage(ch.characterModel.BodyModel, MeshUtil.Direction.Back);
		Vector3 bodyFAvr = MeshUtil.GetExtremeAverage(ch.characterModel.BodyModel, MeshUtil.Direction.Front);
		Vector3 headFAvr = MeshUtil.GetExtremeAverage(ch.characterModel.HeadModel, MeshUtil.Direction.Front);
		Vector3 handBAvr = MeshUtil.GetExtremeAverage(ch.characterModel.HandLModel, MeshUtil.Direction.Bottom);
		

		bodyPos = Vector3.zero;
		bodyMPos = new Vector3(0f, leg2Size.y + foot2Size.y - bodyLMin.y, 0f);
		headPos = new Vector3(0f, bodyMPos.y + bodyBAvr.y, -bodySize.z * 0.5f);
		headMPos = new Vector3(0f, -headFAvr.y, -headSize.z * 0.5f);
		ArmPos = new Vector3(-bodySize.x * 0.5f - armSize.x * 0.5f, bodyMPos.y + bodyLMax.y - 0.05f, 0f);
		ArmMPos = new Vector3(0f, -armSize.y, 0f);
		HandPos = new Vector3(0f, -armSize.y, 0f);
		HandMPos = new Vector3(0f, -handSize.y, -handBAvr.z);
		LegPos = new Vector3(bodyLMin.x + legSize.x * 0.5f, leg2Size.y + foot2Size.y, bodyLMin.z + legSize.z * 0.5f);
		LegMPos = new Vector3(0f, -legSize.y, 0f);
		FootPos = new Vector3(0f, -legSize.y, 0f);
		FootMPos = new Vector3(0f, -footSize.y, -foot2TAvr.z);
		Leg2Pos = new Vector3(bodyLMin.x + leg2Size.x * 0.5f, leg2Size.y + foot2Size.y, bodyLMax.z - leg2Size.z * 0.5f);
		Leg2MPos = new Vector3(0f, -leg2Size.y, 0f);
		Foot2Pos = new Vector3(0f, -leg2Size.y, 0f);
		Foot2MPos = new Vector3(0f, -foot2Size.y, -foot2TAvr.z);
		TailPos = new Vector3(0f, bodyFAvr.y + bodyMPos.y, bodyFAvr.z);
		TailMPos = new Vector3(0f, -tailSize.y + 0.05f, tailSize.z * 0.5f);

		ch.characterOrgan.Body.localPosition = bodyPos;
		ch.characterOrgan.Head.localPosition = headPos;
		ch.characterOrgan.ArmL.localPosition = ArmPos;
		ArmPos.x *= -1f;
		ch.characterOrgan.ArmR.localPosition = ArmPos;
		ch.characterOrgan.HandL.localPosition = HandPos;
		ch.characterOrgan.HandR.localPosition = HandPos;
		ch.characterOrgan.LegL.localPosition = LegPos;
		LegPos.x *= -1f;
		ch.characterOrgan.LegR.localPosition = LegPos;
		ch.characterOrgan.Leg2L.localPosition = Leg2Pos;
		Leg2Pos.x *= -1f;
		ch.characterOrgan.Leg2R.localPosition = Leg2Pos;
		ch.characterOrgan.FootL.localPosition = FootPos;
		ch.characterOrgan.FootR.localPosition = FootPos;
		ch.characterOrgan.Foot2L.localPosition = Foot2Pos;
		ch.characterOrgan.Foot2R.localPosition = Foot2Pos;
		ch.characterOrgan.Tail.localPosition = TailPos;

		ch.characterModel.BodyModel.localPosition = bodyMPos;
		ch.characterModel.HeadModel.localPosition = headMPos;
		ch.characterModel.ArmLModel.localPosition = ArmMPos;
		ch.characterModel.ArmRModel.localPosition = ArmMPos;
		ch.characterModel.HandLModel.localPosition = HandMPos;
		ch.characterModel.HandRModel.localPosition = HandMPos;
		ch.characterModel.LegLModel.localPosition = LegMPos;
		ch.characterModel.LegRModel.localPosition = LegMPos;
		ch.characterModel.Leg2LModel.localPosition = Leg2MPos;
		ch.characterModel.Leg2RModel.localPosition = Leg2MPos;
		ch.characterModel.FootLModel.localPosition = FootMPos;
		ch.characterModel.FootRModel.localPosition = FootMPos;
		ch.characterModel.Foot2LModel.localPosition = Foot2MPos;
		ch.characterModel.Foot2RModel.localPosition = Foot2MPos;
		ch.characterModel.TailModel.localPosition = TailMPos;

	}

	private static void FixOrgan_4L (CharacterBehaviour ch) {

		if (!ch.behaviourSetting.Is4L) {
			return;
		}
		
		Vector3 bodyPos, headPos, LegPos, Leg2Pos, FootPos, Foot2Pos, TailPos;
		Vector3 bodyMPos, headMPos, LegMPos, Leg2MPos, FootMPos, Foot2MPos, TailMPos;

		Vector3 bodySize = MeshUtil.GetMeshSize(ch.characterModel.BodyModel);
		Vector3 tailSize = MeshUtil.GetMeshSize(ch.characterModel.TailModel);
		Vector3 headSize = MeshUtil.GetMeshSize(ch.characterModel.HeadModel);
		Vector3 leg2Size = MeshUtil.GetMeshSize(ch.characterModel.Leg2LModel);
		Vector3 foot2Size = MeshUtil.GetMeshSize(ch.characterModel.Foot2LModel);
		Vector3 legSize = MeshUtil.GetMeshSize(ch.characterModel.LegLModel);
		Vector3 footSize = MeshUtil.GetMeshSize(ch.characterModel.FootLModel);
		Vector3 bodyLMin, bodyLMax;
		MeshUtil.GetExtremeMargin(ch.characterModel.BodyModel, out bodyLMin, out bodyLMax, MeshUtil.Direction.Left);
		Vector3 foot2TAvr = MeshUtil.GetExtremeAverage(ch.characterModel.Foot2LModel, MeshUtil.Direction.Top);
		Vector3 bodyBAvr = MeshUtil.GetExtremeAverage(ch.characterModel.BodyModel, MeshUtil.Direction.Back);
		Vector3 bodyFAvr = MeshUtil.GetExtremeAverage(ch.characterModel.BodyModel, MeshUtil.Direction.Front);
		Vector3 headFAvr = MeshUtil.GetExtremeAverage(ch.characterModel.HeadModel, MeshUtil.Direction.Front);


		bodyPos = Vector3.zero;
		bodyMPos = new Vector3(0f, leg2Size.y + foot2Size.y - bodyLMin.y, 0f);
		headPos = new Vector3(0f, bodyMPos.y + bodyBAvr.y, -bodySize.z * 0.5f);
		headMPos = new Vector3(0f, -headFAvr.y, -headSize.z * 0.5f);
		LegPos = new Vector3(bodyLMin.x + legSize.x * 0.5f, leg2Size.y + foot2Size.y, bodyLMin.z + legSize.z * 0.5f);
		LegMPos = new Vector3(0f, -legSize.y, 0f);
		FootPos = new Vector3(0f, -legSize.y, 0f);
		FootMPos = new Vector3(0f, -footSize.y, -foot2TAvr.z);
		Leg2Pos = new Vector3(bodyLMin.x + leg2Size.x * 0.5f, leg2Size.y + foot2Size.y, bodyLMax.z - leg2Size.z * 0.5f);
		Leg2MPos = new Vector3(0f, -leg2Size.y, 0f);
		Foot2Pos = new Vector3(0f, -leg2Size.y, 0f);
		Foot2MPos = new Vector3(0f, -foot2Size.y, -foot2TAvr.z);
		TailPos = new Vector3(0f, bodyFAvr.y + bodyMPos.y, bodyFAvr.z);
		TailMPos = new Vector3(0f, -tailSize.y + 0.05f, tailSize.z * 0.5f);

		ch.characterOrgan.Body.localPosition = bodyPos;
		ch.characterOrgan.Head.localPosition = headPos;
		ch.characterOrgan.LegL.localPosition = LegPos;
		LegPos.x *= -1f;
		ch.characterOrgan.LegR.localPosition = LegPos;
		ch.characterOrgan.Leg2L.localPosition = Leg2Pos;
		Leg2Pos.x *= -1f;
		ch.characterOrgan.Leg2R.localPosition = Leg2Pos;
		ch.characterOrgan.FootL.localPosition = FootPos;
		ch.characterOrgan.FootR.localPosition = FootPos;
		ch.characterOrgan.Foot2L.localPosition = Foot2Pos;
		ch.characterOrgan.Foot2R.localPosition = Foot2Pos;
		ch.characterOrgan.Tail.localPosition = TailPos;

		ch.characterModel.BodyModel.localPosition = bodyMPos;
		ch.characterModel.HeadModel.localPosition = headMPos;
		ch.characterModel.LegLModel.localPosition = LegMPos;
		ch.characterModel.LegRModel.localPosition = LegMPos;
		ch.characterModel.Leg2LModel.localPosition = Leg2MPos;
		ch.characterModel.Leg2RModel.localPosition = Leg2MPos;
		ch.characterModel.FootLModel.localPosition = FootMPos;
		ch.characterModel.FootRModel.localPosition = FootMPos;
		ch.characterModel.Foot2LModel.localPosition = Foot2MPos;
		ch.characterModel.Foot2RModel.localPosition = Foot2MPos;
		ch.characterModel.TailModel.localPosition = TailMPos;

	}



	#endregion



	#region -- Fix Component ---


	private void FixComponents () {
		foreach (Object o in targets) {
			CharacterBehaviour ch = (CharacterBehaviour)o;
			if (!ch) {
				continue;
			}
			switch (ch.behaviourSetting.characterType) {
				case CharacterBehaviour.BehaviourSetting.CharacterType._2L2H:
					FixComponents_2L2H(ch);
					break;
				case CharacterBehaviour.BehaviourSetting.CharacterType._2L:
				case CharacterBehaviour.BehaviourSetting.CharacterType._4L:
				case CharacterBehaviour.BehaviourSetting.CharacterType._4L2H:
					FixComponents_2L_4L_4L2H(ch);
					break;
			}
		}
	}


	private static void FixComponents_2L2H (CharacterBehaviour ch) {

		Vector3 bodySize = MeshUtil.GetMeshSize(ch.characterModel.BodyModel);
		Vector3 headSize = MeshUtil.GetMeshSize(ch.characterModel.HeadModel);

		CharacterController chc = ch.gameObject.GetComponent<CharacterController>();
		if (chc) {
			chc.radius = bodySize.x * 0.5f + 0.1f;
			chc.height = Mathf.Max(0.3f, ch.characterOrgan.Head.localPosition.y + ch.characterModel.HeadModel.localPosition.y + headSize.y);
			chc.center = new Vector3(0f, chc.height * 0.5f, 0f);
			chc.slopeLimit = 45f;
			chc.stepOffset = 0.3f;
			chc.skinWidth = 0.08f;
		}

		Animator ani = ch.gameObject.GetComponent<Animator>();
		if (ani) {
			ani.runtimeAnimatorController = PathUtil_Editor.GetRootAsset<RuntimeAnimatorController>("Character", "Animation", "2L2H", "2L2H.controller");
		}

	}

	private static void FixComponents_2L_4L_4L2H (CharacterBehaviour ch) {

		Vector3 bodySize = MeshUtil.GetMeshSize(ch.characterModel.BodyModel);
		Vector3 legSize = MeshUtil.GetMeshSize(ch.characterModel.LegLModel);
		Vector3 footSize = MeshUtil.GetMeshSize(ch.characterModel.FootLModel);

		CharacterController chc = ch.gameObject.GetComponent<CharacterController>();
		if (chc) {
			chc.radius = bodySize.x * 0.5f + 0.1f;
			chc.height = Mathf.Max(0.3f, legSize.y + footSize.y + bodySize.y);
			chc.center = new Vector3(0f, chc.height * 0.5f, 0f);
			chc.slopeLimit = 45f;
			chc.stepOffset = 0.3f;
			chc.skinWidth = 0.08f;
		}

		Animator ani = ch.gameObject.GetComponent<Animator>();
		if (ani) {
			string key = ch.behaviourSetting.characterType.ToString();
			key = key.Replace("_", "");
			ani.runtimeAnimatorController = PathUtil_Editor.GetRootAsset<RuntimeAnimatorController>("Character", "Animation", key, key + ".controller");
		}

	}


	private static bool NeedFixComponent (CharacterBehaviour ch) {
		Animator ani = ch.GetComponent<Animator>();
		CharacterController chc = ch.GetComponent<CharacterController>();

		if (ani) {
			string key = ch.behaviourSetting.characterType.ToString();
			key = key.Replace("_", "");
			RuntimeAnimatorController rac = PathUtil_Editor.GetRootAsset<RuntimeAnimatorController>("Character", "Animation", key, key + ".controller");
			if (!ani.runtimeAnimatorController || (rac && ani.runtimeAnimatorController != rac)) {
				return true;
			}
		} else {
			return true;
		}

		if (chc) {
			if (chc.radius == 0f || chc.height == 0f) {
				return true;
			}
		} else {
			return true;
		}

		return false;
	}


	#endregion



	#region --- Tools ---

	private static void ClearModels (CharacterBehaviour ch) {
		if (!ch) {
			return;
		}
		if (ch.characterModel.HeadModel) {
			TransformUtil.ClearChildren(ch.characterModel.HeadModel);
		}
		if (ch.characterModel.BodyModel) {
			TransformUtil.ClearChildren(ch.characterModel.BodyModel);
		}
		if (ch.characterModel.ArmLModel) {
			TransformUtil.ClearChildren(ch.characterModel.ArmLModel);
		}
		if (ch.characterModel.ArmRModel) {
			TransformUtil.ClearChildren(ch.characterModel.ArmRModel);
		}
		if (ch.characterModel.LegLModel) {
			TransformUtil.ClearChildren(ch.characterModel.LegLModel);
		}
		if (ch.characterModel.LegRModel) {
			TransformUtil.ClearChildren(ch.characterModel.LegRModel);
		}
		if (ch.characterModel.Leg2LModel) {
			TransformUtil.ClearChildren(ch.characterModel.Leg2LModel);
		}
		if (ch.characterModel.Leg2RModel) {
			TransformUtil.ClearChildren(ch.characterModel.Leg2RModel);
		}
		if (ch.characterModel.FootLModel) {
			TransformUtil.ClearChildren(ch.characterModel.FootLModel);
		}
		if (ch.characterModel.FootRModel) {
			TransformUtil.ClearChildren(ch.characterModel.FootRModel);
		}
		if (ch.characterModel.Foot2LModel) {
			TransformUtil.ClearChildren(ch.characterModel.Foot2LModel);
		}
		if (ch.characterModel.Foot2RModel) {
			TransformUtil.ClearChildren(ch.characterModel.Foot2RModel);
		}
		if (ch.characterModel.HandLModel) {
			TransformUtil.ClearChildren(ch.characterModel.HandLModel);
		}
		if (ch.characterModel.HandRModel) {
			TransformUtil.ClearChildren(ch.characterModel.HandRModel);
		}
		if (ch.characterModel.TailModel) {
			TransformUtil.ClearChildren(ch.characterModel.TailModel);
		}


	}


	private void ApplyPrefab () {
		foreach (Object o in targets) {
			ApplyPrefab((CharacterBehaviour)o);
		}
	}

	private static void ApplyPrefab (CharacterBehaviour ch) {
		if (!ch) {
			return;
		}
		Object prefab = PrefabUtility.GetPrefabParent(ch.gameObject);
		if (!prefab) {
			return;
		}
		if (!EditorApplication.isPlaying) {
			PrefabUtility.ReplacePrefab(ch.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
		}
	}


	private static void ChangeToPlayerBehavior (Transform tf) {
		CharacterBehaviour c = tf.GetComponent<CharacterBehaviour>();
		if (!tf.GetComponent<PlayerBehaviour>() && c) {
			CharacterBehaviour.BehaviourSetting b = c.behaviourSetting;
			DestroyImmediate(c, true);
			PlayerBehaviour p = tf.gameObject.AddComponent<PlayerBehaviour>();
			p.behaviourSetting = b;
			ResetCharacter(p);
			ApplyPrefab(p);
		}
	}


	private void ToPlayerBehavior (CharacterBehaviour ch) {
		UnityEditor.EditorApplication.delayCall += () => {
			ChangeToPlayerBehavior(ch.gameObject.transform);
		};
	}


	public static void ChangeToCharacterBehavior (Transform tf) {
		CharacterBehaviour p = tf.GetComponent<PlayerBehaviour>();
		if (p) {
			CharacterBehaviour.BehaviourSetting b = p.behaviourSetting;
			DestroyImmediate(p, true);
			CharacterBehaviour ch = tf.gameObject.AddComponent<CharacterBehaviour>();
			ch.behaviourSetting = b;
			ResetCharacter(ch);
			ApplyPrefab(ch);
		}
	}

	
	public void ToCharacterBehavior (CharacterBehaviour ch) {
		UnityEditor.EditorApplication.delayCall += () => {
			ChangeToCharacterBehavior(ch.gameObject.transform);
		};
	}


	#endregion



	#endregion


}
}
