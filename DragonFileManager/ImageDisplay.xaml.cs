using System.Windows;
using System.Windows.Input;

namespace DragonFileManager
{
    public partial class ImageDisplay : Window
    {
        public ImageDisplay()
        {
            InitializeComponent();
        }


        private RenderComponent imageWidget;

        private string AskFilePath()
        {
            Microsoft.Win32.OpenFileDialog dlg;
            bool? result = null;
            do
            {
                dlg = new Microsoft.Win32.OpenFileDialog();
                result = dlg.ShowDialog();
            }
            while (result != true);
            return dlg.FileName;
        }

        public void Display(string path)
        {
            imageWidget = new RenderComponent(this, img0, path);
        }

        #region 鍵盤/滑鼠與程式間的交互

        private void ClickDrag(object sender, MouseButtonEventArgs e) => DragMove();

        private void Img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void ChangeSize(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0) // 滾輪向上放大字體，反之縮小字體
            {
                imageWidget.Bigger();
            }
            else
            {
                imageWidget.Smaller();
            }
        }

        #endregion
    }
}
