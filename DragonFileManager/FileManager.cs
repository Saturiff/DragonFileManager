using System.Collections.Generic;
using System.IO;

namespace DragonFileManager
{
    public class FileManager
    {
        protected FileManager() { }
        public FileManager(string rootPath)
        {
            _rootPath = rootPath;
            Refresh();
        }

        public void Refresh()
        {
            _dirPath.Clear();
            _filePath.Clear();
            GetAllPath();
        }

        private void GetAllPath()
        {
            dirBFS(ref _dirPath, _rootPath);

            foreach (string dir in _dirPath)
            {
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    _filePath.Add(file);
                }
            }
        }

        protected List<string> GetDir(string path)
        {
            string[] dir = Directory.GetDirectories(path);
            List<string> dirPath = new List<string>();
            foreach (string subDir in dir)
            {
                dirPath.Add(subDir);
            }

            return dirPath;
        }

        protected void dirBFS(ref List<string> dirPathList, string dirPath)
        {
            List<string> dir = GetDir(dirPath);
            if (dir.Count == 0) return;
            foreach (string subDir in dir)
            {
                dirPathList.Add(subDir);
                dirBFS(ref dirPathList, subDir);
            }
        }

        protected string _rootPath = "";
        protected List<string> _dirPath = new List<string>();
        protected List<string> _filePath = new List<string>();
        
        public string rootPath { get => _rootPath; private set { } }
        public List<string> dirPath { get => _dirPath; private set { } }
        public List<string> filePath { get => _filePath; private set { } }
    }
}
