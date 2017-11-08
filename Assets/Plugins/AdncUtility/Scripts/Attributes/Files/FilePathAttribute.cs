using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adnc.Utility.Files {
	public class FilePathAttribute : Attribute {
		/// <summary>
		/// Should the full path be printed?
		/// </summary>
		public readonly bool printFullPath;
		
		/// <summary>
		/// Should the path be absolute or relative to the Unity project?
		/// </summary>
		public readonly bool absolutePath;

		/// <summary>
		/// Only allow specific file types
		/// </summary>
		public readonly string fileFilter;

		/// <summary>
		/// Customize the file path functionality
		/// </summary>
		/// <param name="printFullPath">Should the full path be printed?</param>
		/// <param name="absolutePath">Should the path be absolute or relative to the Unity project?</param>
		/// <param name="fileFilter">Only allow specific file types</param>
		public FilePathAttribute (bool printFullPath = false, bool absolutePath = false, string fileFilter = "") {
			this.printFullPath = printFullPath;
			this.absolutePath = absolutePath;
			this.fileFilter = fileFilter;
		}
	}
}
