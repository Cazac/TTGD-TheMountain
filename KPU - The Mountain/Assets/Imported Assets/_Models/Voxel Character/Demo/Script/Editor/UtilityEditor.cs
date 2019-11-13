namespace MoenenVoxel {

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;




public struct MsgUtil {


	private static readonly string TOOLKIT_LABEL = "[UTimeLine]";


	#region -------- ProgressBar --------

	public static void ShowProgressBar (string title, string info, float progress) {
		EditorUtility.DisplayProgressBar(title, info, progress);
	}


	public static bool ShowCancelableProgressBar (string title, string info, float progress) {
		return EditorUtility.DisplayCancelableProgressBar(title, info, progress);
	}


	public static void ClearProgressBar () {
		EditorUtility.ClearProgressBar();
	}


	#endregion


	#region -------- DialogWindow ---------


	public static bool DialogWindow (string title, string msg, string ok, string cancel = "") {
		if (cancel == "") {
			return EditorUtility.DisplayDialog(title, msg, ok);
		} else {
			return EditorUtility.DisplayDialog(title, msg, ok, cancel);
		}
	}


	public static int DialogWindowComplex (string title, string msg, string ok, string cancel, string alt) {
		return EditorUtility.DisplayDialogComplex(title, msg, ok, cancel, alt);
	}


	#endregion


	#region -------- Log --------

	public static void Log (params object[] msg) {
		LogUtil(0, true, msg);
	}


	public static void Logs (params object[] msg) {
		LogUtil(0, false, msg);
	}


	public static void LogWarning (params object[] msg) {
		LogUtil(1, true, msg);
	}


	public static void LogWarnings (params object[] msg) {
		LogUtil(1, false, msg);
	}


	public static void LogError (params object[] msg) {
		LogUtil(2, true, msg);
	}


	public static void LogErrors (params object[] msg) {
		LogUtil(2, false, msg);
	}


	private static void LogUtil (int id, bool combine, params object[] msg) {
		if (combine) {
			string error = TOOLKIT_LABEL + " ";
			foreach (object m in msg) {
				error += m != null ? m.ToString() + "\n" : "Null\n";
			}
			if (id == 0) {
				Debug.Log(error);
			} else if (id == 1) {
				Debug.LogWarning(error);
			} else {
				Debug.LogError(error);
			}
		} else {
			foreach (object m in msg) {
				string error = TOOLKIT_LABEL + " " + (m != null ? m.ToString() : "Null");
				if (id == 0) {
					Debug.Log(error);
				} else if (id == 1) {
					Debug.LogWarning(error);
				} else {
					Debug.LogError(error);
				}
			}
		}
	}


	#endregion

}



public struct MenuUtil {


	public static void CustomMenu (Vector2 pos, GUIContent[] content, int selectingID, EditorUtility.SelectMenuItemFunction callBack, object data) {
		EditorUtility.DisplayCustomMenu(new Rect(pos.x, pos.y, 0, 0), content, selectingID, callBack, data);
	}

	public static void CustomMenu (Vector2 pos, int selectingID, EditorUtility.SelectMenuItemFunction callBack, object data, params GUIContent[] content) {
		CustomMenu(pos, content, selectingID, callBack, data);
	}

	public static void CustomMenu (Vector2 pos, int selectingID, EditorUtility.SelectMenuItemFunction callBack, params GUIContent[] content) {
		CustomMenu(pos, content, selectingID, callBack, null);
	}





}



public struct TextureUtil {


	private static Dictionary<string, Texture2D> Textures;



	public static Texture2D GetTexture (string name) {
		if (Textures != null && Textures.ContainsKey(name)) {
			return Textures[name];
		} else {
			MsgUtil.LogError("Can not load texture: " + name);
			return null;
		}
	}


	public static void LoadAllTextures () {
		if (Textures != null) {
			Textures.Clear();
		}
		Textures = new Dictionary<string, Texture2D>();
		if (Directory.Exists(PathUtil_Editor.ResPath)) {
			FileInfo[] infos = new DirectoryInfo(PathUtil_Editor.ResPath).GetFiles();
			foreach (FileInfo i in infos) {
				Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(PathUtil_Editor.GetReletivePath(i.FullName));
				if (texture) {
					string name = Path.GetFileNameWithoutExtension(i.FullName);
					if (!Textures.ContainsKey(name)) {
						Textures.Add(name, texture);
					}
				}
			}
		}
	}


	public static Texture2D QuickTexture (int w, int h, int wB, int hB, Color c, Color cB) {
		Texture2D txt = new Texture2D(w, h);
		Color[] colors = new Color[w * h];
		for (int i = 0; i < w; i++) {
			for (int j = 0; j < h; j++) {
				colors[j * w + i] = i < wB || j < hB || i > w - wB - 1 || j > h - hB - 1 ? cB : c;
			}
		}
		txt.SetPixels(colors);
		txt.Apply();
		return txt;
	}

	public static Texture2D QuickTexture (int w, int h, Color c) {
		return QuickTexture(w, h, 0, 0, c, Color.clear);
	}

}



public struct MeshUtil {

	public enum Direction {
		Top = 0,
		Bottom = 1,
		Left = 2,
		Right = 3,
		Front = 4,
		Back = 5,
	}


	public static Mesh GetChildrenMesh (Transform tf) {
		if (tf) {
			MeshFilter meshF = tf.GetComponentInChildren<MeshFilter>();
			if (meshF) {
				return meshF.sharedMesh;
			}
		}
		return null;
	}


	public static void GetMeshMargin (Mesh mesh, out Vector3 min, out Vector3 max) {
		if (!mesh) {
			min = max = Vector3.zero;
			return;
		}
		min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
		max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
		Vector3[] vs = mesh.vertices;
		foreach (Vector3 v in vs) {
			min.x = Mathf.Min(min.x, v.x);
			min.y = Mathf.Min(min.y, v.y);
			min.z = Mathf.Min(min.z, v.z);
			max.x = Mathf.Max(max.x, v.x);
			max.y = Mathf.Max(max.y, v.y);
			max.z = Mathf.Max(max.z, v.z);
		}
	}
	public static void GetMeshMargin (Transform tf, out Vector3 min, out Vector3 max) {
		GetMeshMargin(GetChildrenMesh(tf), out min, out max);
	}

	public static Vector3 GetMeshSize (Mesh mesh) {
		Vector3 a, b;
		GetMeshMargin(mesh, out a, out b);
		return b - a;
	}
	public static Vector3 GetMeshSize (Transform tf) {
		return GetMeshSize(GetChildrenMesh(tf));
	}

	public static void GetExtremeMargin (Mesh mesh, out Vector3 min, out Vector3 max, Direction dir) {
		if (!mesh) {
			min = max = Vector3.zero;
			return;
		}
		min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
		max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
		Vector3 meshMin, meshMax;
		GetMeshMargin(mesh, out meshMin, out meshMax);
		Vector3[] vs = mesh.vertices;
		foreach (Vector3 v in vs) {
			if (dir == Direction.Top && v.y == meshMax.y ||
				dir == Direction.Bottom && v.y == meshMin.y ||
				dir == Direction.Left && v.x == meshMin.x ||
				dir == Direction.Right && v.x == meshMax.x ||
				dir == Direction.Front && v.z == meshMax.z ||
				dir == Direction.Back && v.z == meshMin.z
			) {
				min.x = Mathf.Min(min.x, v.x);
				min.y = Mathf.Min(min.y, v.y);
				min.z = Mathf.Min(min.z, v.z);
				max.x = Mathf.Max(max.x, v.x);
				max.y = Mathf.Max(max.y, v.y);
				max.z = Mathf.Max(max.z, v.z);
			}
		}
	}
	public static void GetExtremeMargin (Transform tf, out Vector3 min, out Vector3 max, Direction dir) {
		GetExtremeMargin(GetChildrenMesh(tf), out min, out max, dir);
	}
	
	public static Vector3 GetExtremeAverage (Mesh mesh, Direction dir) {
		Vector3 a, b;
		GetExtremeMargin(mesh, out a, out b, dir);
		return (a + b) * 0.5f;
	}
	public static Vector3 GetExtremeAverage (Transform tf, Direction dir) {
		return GetExtremeAverage(GetChildrenMesh(tf), dir);
	}

	public static Vector3 GetExtremeSize (Mesh mesh, Direction dir) {
		Vector3 a, b;
		GetExtremeMargin(mesh, out a, out b, dir);
		return b - a;
	}
	public static Vector3 GetExtremeSize (Transform tf, Direction dir) {
		return GetExtremeSize(GetChildrenMesh(tf), dir);
	}


}




public struct PathUtil_Editor {


	#region -------- VAR --------


	public static string RootPath {
		get {
			if (!Directory.Exists(rootPath)) {
				rootPath = "";
				string[] allPath = AssetDatabase.GetAllAssetPaths();
				foreach (string path in allPath) {
					if (Path.GetExtension(path) == "" && Path.GetFileNameWithoutExtension(path) == ROOT_FOLDER_NAME) {
						rootPath = path;
						break;
					}
				}
			}
			return rootPath;
		}
	}
	private static string rootPath = "";

	public static string ResPath {
		get {
			return CombinePaths(RootPath, RES_FOLDER_NAME);
		}
	}


	private static readonly string ROOT_FOLDER_NAME = "Moenen_Voxel_Collection";
	private static readonly string RES_FOLDER_NAME = "Res";


	#endregion



	#region -------- API --------


	public static string GetFullPath (string path) {
		return new FileInfo(path).FullName;
	}


	public static string FixPath (string _path) {
		return _path.Replace(@"\", @"/").Replace(@"//", @"/");
	}



	public static string CombinePaths (params string[] paths) {
		string path = "";
		for (int i = 0; i < paths.Length; i++) {
			path = Path.Combine(path, paths[i]);
		}
		return FixPath(path);
	}


	public static string GetURL (string path) {
		return (new Uri(path)).AbsoluteUri;
	}


	public static string GetURL (params string[] paths) {
		return GetURL(CombinePaths(paths));
	}


	public static string GetReletivePath (string path) {
		return FixPath(path).Replace(FixPath(Application.dataPath), "Assets");
	}


	public static string GetReletiveParentPath (string path) {
		return GetReletivePath(Path.GetDirectoryName(path));
	}


	public static string GetParentPath (string path) {
		return GetFullPath(GetReletiveParentPath(path));
	}


	public static string GetParentPath (params string[] paths) {
		return GetParentPath(CombinePaths(paths));
	}



	public static T GetRootAsset<T> (string path) where T : UnityEngine.Object {
		return AssetDatabase.LoadAssetAtPath<T>(CombinePaths(RootPath, path));
	}


	public static T GetRootAsset<T> (params string[] paths) where T : UnityEngine.Object {
		return GetRootAsset<T>(CombinePaths(paths));
	}







	#endregion


}





}