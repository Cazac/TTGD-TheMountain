namespace MoenenVoxel {

using System.Collections;
using System.Text;
using System.IO;
using System;
using UnityEngine;


public struct FileUtil {



	public static string ReadText (string path) {
		try {
			StreamReader sr = File.OpenText(path);
			string data = sr.ReadToEnd();
			sr.Close();
			return data;
		} catch {
			return "";
		}
	}


	public static void WriteText (string data, string path) {
		try {
			FileStream fs = new FileStream(path, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
			sw.Write(data);
			sw.Close();
			fs.Close();
		} catch {
			return;
		}
	}


	public static byte[] FileToByte (string path) {
		if (File.Exists(path)) {
			byte[] bytes = null;
			try {
				bytes = File.ReadAllBytes(path);
			} catch {
				return null;
			}
			return bytes;
		} else {
			return null;
		}
	}


	public static bool ByteToFile (byte[] bytes, string path) {
		try {
			string parentPath = new FileInfo(path).Directory.FullName;
			CreateFolder(parentPath);
			FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
			fs.Write(bytes, 0, bytes.Length);
			fs.Close();
			fs.Dispose();
			return true;
		} catch {
			return false;
		}
	}


	public static void CreateFolder (string path) {
		if (Directory.Exists(path))
			return;
		string parentPath = new FileInfo(path).Directory.FullName;
		if (Directory.Exists(parentPath)) {
			Directory.CreateDirectory(path);
		} else {
			CreateFolder(parentPath);
			Directory.CreateDirectory(path);
		}
	}



}

public struct PathUtil {



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




}

public struct TransformUtil {


	public static Transform GetCreateName (Transform root, string name) {
		if (root) {
			if (string.IsNullOrEmpty(name)) {
				return root;
			}
			Transform tf = root.Find(name);
			if (tf) {
				return tf;
			} else {
				GameObject o = new GameObject(name);
				o.transform.SetParent(root);
				o.transform.localPosition = Vector3.zero;
				o.transform.localRotation = Quaternion.identity;
				o.transform.localScale = Vector3.one;
				return o.transform;
			}
		} else {
			return null;
		}
	}


	public static Transform GetCreate (Transform root, string path) {
		if (root) {
			if (string.IsNullOrEmpty(path)) {
				return root;
			}
			Transform tf = root.Find(path);
			if (tf) {
				return tf;
			} else {
				string[] paths = path.Split('/', '\\');
				Transform prevTF = root;
				foreach (string name in paths) {
					prevTF = GetCreateName(prevTF, name);
				}
				return prevTF;
			}
		} else {
			return null;
		}
	}


	public static void ClearChildren (Transform tf) {
		while (tf.childCount > 0) {
			GameObject.DestroyImmediate(tf.GetChild(0).gameObject, true);
		}
	}


}


}