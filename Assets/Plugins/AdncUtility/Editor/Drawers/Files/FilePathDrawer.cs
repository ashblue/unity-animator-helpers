using UnityEditor;

namespace Adnc.Utility.Files {
    [CustomPropertyDrawer(typeof(FilePath))]
    public class FilePathDrawer : FilePathDrawerBase {
        protected override string GetTarget () {
            var attr = GetFileAttr();
            return GetFilePath(attr.absolutePath, attr.fileFilter);
        }
    }
}