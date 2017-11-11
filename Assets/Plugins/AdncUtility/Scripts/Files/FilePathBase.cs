using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adnc.Utility.Files {
	public abstract class FilePathBase {
		[SerializeField] protected string _target;
		[SerializeField] protected string _targetPath;

		/// <summary>
		/// File or folder location
		/// </summary>
		public virtual string Target { get { return _target; } }

		/// <summary>
		/// Path to the file or folder target
		/// </summary>
		public virtual string TargetPath { get { return _targetPath; } }

		public string FullPath {
			get { return string.Format("{0}/{1}", TargetPath, Target); }
		}

		public virtual string GetFullPath (bool includeAssetsNamespace = true) {
			if (includeAssetsNamespace) {
				return FullPath;
			}

			return FullPath.Replace("Assets/", "");
		}
	}
}
