using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Tema3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        byte[] hashValue;
        FileStream fstream;
        HashAlgorithm hashObject;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() ==true)
            {
                fstream = File.Open(dialog.FileName, FileMode.Open);
                textBox.Text = dialog.FileName;
            }
        }
        private byte[] myComputeHash(HashAlgorithm obj,FileStream f)
        {
            Thread.Sleep(6000);
            return obj.ComputeHash(f);
        }
        private async void cryptButton_Click(object sender, RoutedEventArgs e)
        {
      
            switch(comboBox.Text)
            {
                case "MD5":
                    {
                        hashObject = MD5.Create();

                        // this ain't working //Task<byte[]> task = new Task<byte[]>(hashObject.ComputeHash(fstream));
                        //Task<byte[]> task = new Task<byte[]>(() => hashObject.ComputeHash(fstream));
                        Task<byte[]> task = new Task<byte[]>(() => myComputeHash(hashObject,fstream));
                        task.Start();
                        hashValue = await task;
                        MessageBox.Show(BitConverter.ToString(hashValue).Replace("-", ""));
                        break;
                    }
                case "RIPEMD160":
                    {
                        hashObject = RIPEMD160.Create();
                        Task<byte[]> task = new Task<byte[]>(() => hashObject.ComputeHash(fstream));
                        task.Start();
                        hashValue = await task;
                        MessageBox.Show(BitConverter.ToString(hashValue).Replace("-", ""));
                        break;
                    }
                case "SHA1":
                    {
                        hashObject = SHA1.Create();
                        //before
                        //hashValue = hashObject.ComputeHash(fstream);
                        //after
                        Task<byte[]> task = new Task<byte[]>(() => hashObject.ComputeHash(fstream));
                        task.Start();
                        hashValue = await task;
                        MessageBox.Show(BitConverter.ToString(hashValue).Replace("-", ""));
                        break;
                    }
                case "SHA256":
                    {
                        hashObject = SHA256.Create();
                        hashValue = hashObject.ComputeHash(fstream);
                        MessageBox.Show(BitConverter.ToString(hashValue).Replace("-", ""));
                        break;
                    }
                case "SHA384":
                    {
                        hashObject = SHA384.Create();
                        hashValue = hashObject.ComputeHash(fstream);
                        MessageBox.Show(BitConverter.ToString(hashValue).Replace("-", ""));
                        break;
                    }
                case "SHA512":
                    {
                        hashObject = SHA512.Create();
                        hashValue = hashObject.ComputeHash(fstream);
                        MessageBox.Show(BitConverter.ToString(hashValue).Replace("-", ""));
                        break;
                    }
                default:
                    {
                        MessageBox.Show("You didn't choose ANYTHING.");
                        break;
                    }
            }
            

        }
    }
}
