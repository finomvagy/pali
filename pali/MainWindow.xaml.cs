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

namespace pali
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int db;
        int ar = 1699;
        bool some = true;
        public MainWindow()
        {
            
            InitializeComponent();
            Start();
            Cancell();
            Add();
            Orderr();
        }
        void Start()
        {
            Quantity.GotFocus += OnFocus;
            Type.GotFocus += OnFocus;
            FillingType.GotFocus += OnFocus;
            Quantity.LostFocus += OffFocus;
            Type.LostFocus += OffFocus;
            FillingType.LostFocus += OffFocus;
            
                Order.MouseEnter += (s, e) =>
                {
                    if (!some)
                    {
                        Order.Content = db * ar;
                    }
                };
            

            Order.MouseLeave += (s, e) =>
            {
                Order.Content = Order.Tag.ToString();
            };


        }
        void OnFocus(object s, EventArgs e)
        {
            TextBox sender = s as TextBox;
            if (sender.Text == sender.Tag.ToString())
            {
                sender.Clear();
            }
        }
        void OffFocus(object s, EventArgs e)
        {
            TextBox sender = s as TextBox;
            if (sender.Text == "")
            {
                sender.Text = sender.Tag.ToString();
            }
        }
        void Cancell()
        {
            Cancel.Click += (s, e) =>
            {
                Quantity.Text = Quantity.Tag.ToString();
                Type.Text = Type.Tag.ToString();
                FillingType.Text = FillingType.Tag.ToString();
            };
        }
        void Add()
        {
            Plus.Click += (s, e) =>
            {

                db+=Convert.ToInt32(Quantity.Text);
                some = false;
                Pancake.Children.Add(new Label() { Content = " Palacsinta: " + FillingType.Text+ " Darab: " + Quantity.Text + " Tészta: " + Type.Text, Foreground =Brushes.Cyan, FontSize=20  });

            };

        }
        void Orderr()
        {
            Order.Click += (s, e) =>
            {
                some = true;
                
                db = 0;
                StreamWriter write = new StreamWriter("palik.txt", false, Encoding.UTF8);
                write.WriteLine("Első sor");
                foreach (Label x in Pancake.Children)
                {
                    write.WriteLine(x);
                }
                write.Close();
                Pancake.Children.Clear();
            };
            
        }
       

    }
}
