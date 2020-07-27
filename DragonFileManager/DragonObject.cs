using System.Drawing;

namespace DragonFileManager
{
    public class DragonObject
    {
        public DragonObject()
        {
            storyName = "";
            enStoryLink = "";
            zhStoryLink = "";
            imageLink = "";
            writer = "";
        }
        
        // tag?
        public void AddLinkByLanguageTag(string tag, string link)
        {
            if (tag == "_en")
            {
                enStoryLink = link;
            }
            else if (tag == "_zh")
            {
                zhStoryLink = link;
            }
            else
            {
                imageLink = link;
            }
        }

        public string storyName;
        public string enStoryLink;
        public string zhStoryLink;
        public string imageLink;
        public string writer;
        // tag?
    }
    
}
