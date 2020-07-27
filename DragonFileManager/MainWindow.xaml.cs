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

            InitializeTextEditor();

            stm = new StoryTreeManager(SP_TreeView, dragonCollection, TE_Area1, TE_Area2);

            id.Hide();
        }

        ~MainWindow()
        {
            id.Close();
        }

        ImageDisplay id = new ImageDisplay();

        public void InitializeTextEditor()
        {
            DragonTextEditor[] editors = new DragonTextEditor[] { TE_Area1, TE_Area2 };
            for (int i = 0; i < 2; i++)
            {
                editors[i].IsReadOnly = i == 0 ? true : false;
                editors[i].ShowLineNumbers = true;
                editors[i].Width = double.NaN;
                editors[i].Height = double.NaN;
                editors[i].WordWrap = true;
                editors[i].FontSize = 20;
                G_Main.Children.Add(editors[i]);
                Grid.SetRow(editors[i], i * 2);
                Grid.SetColumn(editors[i], 2);
            }
        }

        private DragonTextEditor TE_Area1 = new DragonTextEditor(), TE_Area2 = new DragonTextEditor();

        private const string BASE_PATH = @"E:\Backups\Dragons_backup_20200714\00_NewSort\01_story\";

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

        private void ClickImage(object sender, RoutedEventArgs e)
        {
            if (TE_Area1.drgObj.imageLink != "" && !id.IsVisible)
            {
                id.Display(TE_Area1.drgObj.imageLink);
                id.Show();
            }
            else
                id.Hide();
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            TE_Area2.Save();
        }
    }
}
