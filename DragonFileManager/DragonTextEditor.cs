using ICSharpCode.AvalonEdit;
using System;
using System.Collections;

namespace DragonFileManager
{
    public class DragonTextEditor : TextEditor
    {
        public DragonTextEditor() : base() { }

        public void Save()
        {
            Save(drgObj.zhStoryLink);
        }

        public void AddInfo(DragonObject additionalInfo) => drgObj = additionalInfo;

        public DragonObject drgObj = new DragonObject();
    }
}
