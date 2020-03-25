using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DragonFileManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            stm = new StoryTreeManager(SP_TreeView, dragonCollection, TE_Area1, TE_Area2);
        }

        private const string BASE_PATH = @"G:\Dragons\Dragon\00_新排序\story\";
        private DragonObjectCollection dragonCollection = new DragonObjectCollection(BASE_PATH);
        StoryTreeManager stm;

        #region 所有按鈕事件
        private void ClickMin(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            Close();
            Environment.Exit(Environment.ExitCode);
        }

        private void ClickDrag(object sender, MouseButtonEventArgs e) => DragMove();

        private void ClickShowButton(object sender, MouseEventArgs e) => ShowButton(true);

        private void ClickHideButton(object sender, MouseEventArgs e) => ShowButton(false);

        private void ShowButton(bool show) => Min_button.Opacity = show ? 1 : 0;

        #endregion
    }
}
