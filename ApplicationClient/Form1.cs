using MathServiceLibrary;
using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace ApplicationClient
{
    public partial class Form1 : Form
    {
        private readonly IMathService _mathClient = new ChannelFactory<IMathService>("MathService").CreateChannel();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(textBox1.Text);
            int number2 = Convert.ToInt32(textBox2.Text);

            int result = _mathClient.Add(new MathServiceLibrary.MyNumbers() { Number1 = number1, Number2 = number2 });
            textBox3.Text = result.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(textBox1.Text);
            int number2 = Convert.ToInt32(textBox2.Text);

            int result = _mathClient.Substract(new MathServiceLibrary.MyNumbers() { Number1 = number1, Number2 = number2 });
            textBox3.Text = result.ToString();
        }
    }
}
