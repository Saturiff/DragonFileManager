using System.Collections.Generic;

namespace DragonFileManager
{
    public class DragonObjectCollection
    {
        public DragonObjectCollection() { }
        public DragonObjectCollection(string path)
        {
            _fm = new FileManager(path);
            StartCategory();
        }

        public void StartCategory()
        {
            foreach (string path in _fm.filePath)
            {
                string[] bucket = path.Split("story\\")[1].Split('\\');
                if (!bucket[0].Contains("translate by other ppl") && bucket.Length == 2)
                {
                    SortByLanguage(path, bucket, new string[] { "_en", "_zh" });
                }
            }
        }

        private void SortByLanguage(string path, string[] bucket, string[] langTags)
        {
            foreach (string langTag in langTags)
            {
                // bucket:
                // 0. writer
                // 1. file_name
                if (bucket[1].Contains(langTag))
                {
                    string storyName = bucket[1].Split(langTag)[0];
                    bool alreadyCategory = false;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].storyName.Contains(storyName))
                        {
                            list[i].AddLinkByLanguageTag(langTag, path);
                            alreadyCategory = true;
                            break;
                        }
                    }

                    if (!alreadyCategory)
                    {
                        DragonObject dragonObj = new DragonObject();
                        dragonObj.writer = bucket[0];
                        dragonObj.storyName = storyName;
                        dragonObj.AddLinkByLanguageTag(langTag, path);
                        list.Add(dragonObj);
                    }
                }
            }
        }

        protected FileManager _fm;
        protected List<DragonObject> _list = new List<DragonObject>();

        public List<DragonObject> list { get => _list; }
    }
}
