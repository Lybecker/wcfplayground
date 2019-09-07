using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace HandcraftedProxyClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var proxy = new HelloWorldClient();
            try
            {
                proxy.HelloWorld("...");
                proxy.Close();
            }
            catch (CommunicationException)
            {
                proxy.Abort();
            }
            catch (TimeoutException)
            {
                proxy.Abort();
            }
            catch (Exception)
            {
                proxy.Abort();
            }
        }
    }
}