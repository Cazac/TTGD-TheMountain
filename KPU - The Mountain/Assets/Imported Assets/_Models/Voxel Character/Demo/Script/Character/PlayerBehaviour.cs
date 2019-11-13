namespace MoenenVoxel {

using UnityEngine;
using System.Collections;


[DisallowMultipleComponent]
public sealed class PlayerBehaviour : CharacterBehaviour {



	#region -------- DAT --------


	[System.Serializable]
	public struct PlayerInputKey {

		public KeyCode Forward;
		public KeyCode Back;
		public KeyCode Left;
		public KeyCode Right;
		public KeyCode Jump;
		public KeyCode RunWalk;
		public KeyCode Attack1;
		public KeyCode Attack2;
		public KeyCode Dash;
		public KeyCode Event;


		public void Reset () {
			Forward = KeyCode.W;
			Back = KeyCode.S;
			Left = KeyCode.A;
			Right = KeyCode.D;
			Jump = KeyCode.Space;
			RunWalk = KeyCode.R;
			Attack1 = KeyCode.O;
			Attack2 = KeyCode.P;
			Dash = KeyCode.L;
			Event = KeyCode.E;
		}

	}


	#endregion


	
	#region -------- VAR --------

	[SerializeField]
	private PlayerInputKey inputKey;

	private float prevFTime = -1f;
	private float prevBTime = -1f;
	private float prevLTime = -1f;
	private float prevRTime = -1f;
	private Vector2 AimMove = Vector2.zero;
	private Quaternion AimRotation = Quaternion.identity;
	private readonly float RotateRant = 0.2f;

	#endregion



	#region -------- MSG --------



	void Reset () {
		inputKey.Reset();
	}


	protected override void Update () {

		MovementUpdate();

		JumpUpdate();

		AttackUpdate();

		DashUpdate();

		base.Update();

	}



	void MovementUpdate () {

		AimMove = Vector2.zero;

		if (Input.GetKey(inputKey.Forward)) {
			if (prevFTime < 0f) {
				prevFTime = Time.time;
				base.BreakAttack();
			}
			if (prevFTime > prevBTime) {
				AimMove.y = 1f;
			}
		} else {
			prevFTime = -1f;
		}

		if (Input.GetKey(inputKey.Back)) {
			if (prevBTime < 0f) {
				prevBTime = Time.time;
				base.BreakAttack();
			}
			if (prevBTime > prevFTime) {
				AimMove.y = -1f;
			}
		} else {
			prevBTime = -1f;
		}

		if (Input.GetKey(inputKey.Left)) {
			if (prevLTime < 0f) {
				prevLTime = Time.time;
				base.BreakAttack();
			}
			if (prevLTime > prevRTime) {
				AimMove.x = -1f;
			}
		} else {
			prevLTime = -1f;
		}

		if (Input.GetKey(inputKey.Right)) {
			if (prevRTime < 0f) {
				prevRTime = Time.time;
				base.BreakAttack();
			}
			if (prevRTime > prevLTime) {
				AimMove.x = 1f;
			}
		} else {
			prevRTime = -1f;
		}

		if (Input.GetKeyDown(inputKey.RunWalk)) {
			//RunIfMove = !RunIfMove;
		}
		/*
		if (RunIfMove) {
			base.RunDependCamera(AimMove);
		} else {
			base.WalkDependCamera(AimMove);
		}*/

		base.RunDependCamera(AimMove);

		if (AimMove != Vector2.zero) {
			AimRotation = Quaternion.Lerp(AimRotation, Quaternion.Euler(
				0f, (AimMove.x > 0f ? 1f : -1f) * Vector2.Angle(Vector2.up, AimMove) + 180f, 0f
			), RotateRant);
		}
		
		
		base.RotateDependCamera(AimRotation);

	}


	void JumpUpdate () {
		if (Input.GetKeyDown(inputKey.Jump)) {
			base.Jump();
		}
	}

	
	void AttackUpdate () {
		if (Input.GetKey(inputKey.Attack1)) {
			base.Attack1();
		}
		if (Input.GetKey(inputKey.Attack2)) {
			base.Attack2();
		}
	}


	void DashUpdate () {
		if (Input.GetKeyDown(inputKey.Dash)) {
			base.Dash();
		}
	}


	#endregion




}
}
