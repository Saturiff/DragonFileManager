using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DragonFileManager
{
    public class RenderComponent
    {
        public RenderComponent(Window window, Image image0, string filePath)
        {
            this.window = window;
            image = image0;
            image.Source = ByteToImage(SaveInputImage(filePath));

            imgWidth = image.Width = (96 * biImg.PixelWidth) / biImg.DpiX;
            imgHeight = image.Height = (96 * biImg.PixelHeight) / biImg.DpiY;

            scaleX = scaleY = 1;
            scaleOffsetValue = 0.2;

            ResizeImage();
        }

        public void Bigger()
        {
            scaleX += scaleOffsetValue;
            scaleY += scaleOffsetValue;
            ResizeImage();
        }

        public void Smaller()
        {
            if ((scaleX - scaleOffsetValue) >= 0.5)
            {
                scaleX -= scaleOffsetValue;
                scaleY -= scaleOffsetValue;
            }
            ResizeImage();
        }

        private void ResizeImage()
        {
            scaleTransform.ScaleX = scaleX;
            scaleTransform.ScaleY = scaleY;
            scaleTransform.CenterX = Mouse.GetPosition(image).X;
            scaleTransform.CenterY = Mouse.GetPosition(image).Y;
            image.RenderTransform = scaleTransform;
            window.Width = imgWidth * scaleTransform.ScaleX;
            window.Height = imgHeight * scaleTransform.ScaleY;
        }

        private byte[] SaveInputImage(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();

            return data;
        }

        private ImageSource ByteToImage(byte[] imageData)
        {
            biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        private BitmapImage biImg;
        private Window window;
        private Image image;
        private double imgWidth, imgHeight;
        private ScaleTransform scaleTransform = new ScaleTransform();
        private double scaleX, scaleY;
        private double scaleOffsetValue;
    }
}
