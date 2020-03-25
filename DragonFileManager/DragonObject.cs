namespace DragonFileManager
{
    public class DragonObject
    {
        public DragonObject()
        {
            storyName = "";
            enStoryLink = "";
            zhStoryLink = "";
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
        }

        public string storyName;
        public string enStoryLink;
        public string zhStoryLink;
        public string writer;
        // tag?
    }
    
}
