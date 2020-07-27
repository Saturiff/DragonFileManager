using ICSharpCode.AvalonEdit;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DragonFileManager
{
    public class StoryTreeManager
    {
        public StoryTreeManager(StackPanel storyBucket, DragonObjectCollection doc, DragonTextEditor tb1, DragonTextEditor tb2)
        {
            this.storyBucket = storyBucket;
            this.doc = doc;
            this.tb1 = tb1;
            this.tb2 = tb2;
            Initial();
        }

        private void Initial()
        {
            storyButtons.Clear();
            bool writerIsAdded = false;
            foreach (DragonObject story in doc.list)
            {
                foreach (var btn in storyButtons)
                {
                    writerIsAdded = false;
                    if ((string)btn.Content == story.writer)
                    {
                        writerIsAdded = true;
                        break;
                    }
                }
                if (!writerIsAdded) storyButtons.Add(new StoryButton(story, true, this, tb1, tb2));
                storyButtons.Add(new StoryButton(story, false, this, tb1, tb2));
            }
            Display();
        }

        private void Display()
        {
            storyBucket.Children.Clear();
            foreach (var btn in storyButtons)
            {
                storyBucket.Children.Add(btn);
            }
        }

        public void ToggleExpand(string writer)
        {

            // foreach (StoryButton btn in storyButtons)
            for (int i = storyButtons.Count - 1; i > 0; i--)
            {
                if (storyButtons[i].drgObj.writer == writer && !storyButtons[i].isWriter)
                {
                    if (storyButtons[i].Visibility == System.Windows.Visibility.Visible)
                    {
                        storyButtons[i].Visibility = System.Windows.Visibility.Hidden;
                        storyButtons[i].Height = 0;
                    }
                    else
                    {
                        storyButtons[i].Visibility = System.Windows.Visibility.Visible;
                        storyButtons[i].Height = 36;
                    }
                }
            }
            Display();
        }

        StackPanel storyBucket;
        DragonObjectCollection doc;
        List<StoryButton> storyButtons = new List<StoryButton>();
        DragonTextEditor tb1;
        DragonTextEditor tb2;
    }
}
