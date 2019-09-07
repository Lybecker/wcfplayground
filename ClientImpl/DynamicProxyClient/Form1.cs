using System;
using System.Windows.Forms;
using System.ServiceModel;

namespace DynamicProxyClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var factory = new ChannelFactory<IHelloWorldService>("myEndPoint");

            IHelloWorldService proxy = factory.CreateChannel();

            using (proxy as IDisposable)
            {
                MessageBox.Show(proxy.HelloWorld("DynamicProxyClient"));
            }
        }
    }
}