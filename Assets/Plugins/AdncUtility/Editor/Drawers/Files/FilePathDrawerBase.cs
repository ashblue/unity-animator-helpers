using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace Adnc.Utility.Files {
	public abstract class FilePathDrawerBase : PropertyDrawer {
		const float HEIGHT = 34;
		const float BLOCK_HEIGHT = 16;
		const float BLOCK_PADDING = 2;
		
		protected virtual string ButtonSetText {
			get { return "Set File"; }
		}

		protected virtual string ButtonClearText {
			get { return "Clear File"; }
		}

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
			var attr = GetFileAttr();
			
			var rectButtonA = new Rect(position.x, position.y + BLOCK_HEIGHT + BLOCK_PADDING, (position.width / 2) - BLOCK_PADDING, BLOCK_HEIGHT);
			var rectButtonB = new Rect(
				position.x + (position.width / 2) + BLOCK_PADDING,
				position.y + BLOCK_HEIGHT + BLOCK_PADDING,
				(position.width / 2) - BLOCK_PADDING,
				BLOCK_HEIGHT);
			var rectText = new Rect(position.x, position.y, position.width, BLOCK_HEIGHT);

			var propPath = property.FindPropertyRelative("_targetPath");
			var propTarget = property.FindPropertyRelative("_target");

			// Visual output
			EditorGUI.BeginProperty(position, label, property);

			var displayPath = string.Format("{0}/{1}", propPath.stringValue, propTarget.stringValue);
			if (!attr.printFullPath) {
				displayPath = FriendlyDisplayPath(displayPath);
			}
			
			GUI.enabled = false;
			EditorGUI.TextField(rectText, label, displayPath);
			GUI.enabled = true;

			if (GUI.Button(rectButtonA, ButtonSetText)) {
				var filePath = GetTarget();
				if (!string.IsNullOrEmpty(filePath)) {
					var parts = filePath.Split(new string[] {"/"}, System.StringSplitOptions.RemoveEmptyEntries).ToList();
					propTarget.stringValue = parts.Last();

					var partsPath = parts.Where(p => p != parts.Last()).ToArray();
					propPath.stringValue = string.Join("/", partsPath);
				}
			}

			if (GUI.Button(rectButtonB, ButtonClearText)) {
				propPath.stringValue = null;
				propTarget.stringValue = null;
			}

			EditorGUI.EndProperty();
		}

		protected abstract string GetTarget ();

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
			var height = BLOCK_HEIGHT * 2f;
			height += BLOCK_PADDING;
			return height;
		}

		public static string GetProjectWindowFolder () {
			foreach (var obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets)) {
				var path = AssetDatabase.GetAssetPath(obj);
				if (AssetDatabase.IsValidFolder(path)) {
					return path;
				}
			}

			return "Assets";
		}

		public static string GetFilePath (bool absolutePath, string filter) {
			var path = EditorUtility.OpenFilePanel("Choose File", GetProjectWindowFolder(), filter);

			if (!absolutePath) {
				path = path.Replace(Application.dataPath, "Assets");
			}

			return path;
		}

		public static string GetFolderPath (bool absolutePath) {
			var path = EditorUtility.OpenFolderPanel("Choose Folder", GetProjectWindowFolder(), "");

			if (!absolutePath) {
				path = path.Replace(Application.dataPath, "Assets");
			}

			return path;
		}

		public static List<string> FindAssetPaths(string filter, string[] folders) {
			var guids = AssetDatabase.FindAssets(filter, folders);

			return guids.Select(t => AssetDatabase.GUIDToAssetPath(t)).ToList();
		}

		public static string FriendlyDisplayPath (string path) {
			if (string.IsNullOrEmpty(path)) {
				return null;
			}

			var separator = new string[] { "/" };
			var parts = path.Split(separator, System.StringSplitOptions.RemoveEmptyEntries).ToList();
			var partsPath = parts.Where(p => p != parts.Last());

			var partsPathOutput = string.Join("/", partsPath.Reverse().Take(2).Reverse().ToArray());

			string result = null;
			if (parts.Count > 0) {
				result = string.Format(".../{0}/{1}", partsPathOutput, parts[parts.Count - 1]);
			}

			return result;
		}

		protected FilePathAttribute GetFileAttr () {
			var a = fieldInfo.GetCustomAttributes(typeof(FilePathAttribute), true).FirstOrDefault() as FilePathAttribute;
			if (a == null) {
				return new FilePathAttribute();
			}

			return a;
		}
	}
}
