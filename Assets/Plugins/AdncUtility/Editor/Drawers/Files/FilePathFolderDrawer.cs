using UnityEditor;

namespace Adnc.Utility.Files {
    [CustomPropertyDrawer(typeof(FilePathFolder))]
    public class FilePathFolderDrawer : FilePathDrawerBase {
        protected override string ButtonSetText {
            get { return "Set Folder"; }
        }

        protected override string ButtonClearText {
            get { return "Clear Folder"; }
        }

        protected override string GetTarget () {
            var attr = GetFileAttr();
            return GetFolderPath(attr.absolutePath);
        }
    }
}