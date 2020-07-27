using ICSharpCode.AvalonEdit;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DragonFileManager
{
    public class StoryButton : Button
    {
        public StoryButton(DragonObject drgObj, bool isWriter, StoryTreeManager stm, DragonTextEditor tb1, DragonTextEditor tb2)
        {
            this.drgObj = drgObj;
            this.isWriter = isWriter;
            this.stm = stm;
            this.tb1 = tb1;
            this.tb2 = tb2;
            Content = isWriter ? drgObj.writer : drgObj.storyName;
            HorizontalAlignment = HorizontalAlignment.Right;
            HorizontalContentAlignment = HorizontalAlignment.Left;
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00DDDDDD"));
            BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            FontWeight = FontWeights.Bold;
            FontSize = 20;
            Height = isWriter ? 36 : 0;
            Visibility = isWriter ? Visibility.Visible : Visibility.Hidden;
            Width = isWriter ? 320 : 300;
            Margin = new Thickness(0, 0, 0, 0);
            Click += StoryButton_Click;
        }

        private void StoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (isWriter)
            {
                stm.ToggleExpand(drgObj.writer);
            }
            else
            {
                tb1.Clear();
                tb2.Clear();

                if (drgObj.enStoryLink != "")
                {
                    tb1.Load(drgObj.enStoryLink);
                    tb1.AddInfo(drgObj);
                }

                if (drgObj.zhStoryLink != "")
                {
                    tb2.Load(drgObj.zhStoryLink);
                    tb2.AddInfo(drgObj);
                }
            }
        }

        public DragonObject drgObj;
        public bool isWriter;
        private StoryTreeManager stm;
        private DragonTextEditor tb1;
        private DragonTextEditor tb2;
    }
}
