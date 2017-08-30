using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrackBarTest
{
    public partial class frmMain : Form
    {
        /// <summary>  
        /// TrackBar数量  
        /// </summary>  
        int tbCount = 3; 

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //设置滑块属性
            //滑块一
            trackBar1.Minimum = 400;
            trackBar1.Maximum = 800;
            trackBar1.TickFrequency = 25;
            trackBar1.SmallChange = 5;
            trackBar1.LargeChange = 25;
            trackBar1.Value = 510;

            //滑块二
            trackBar2.Minimum = 4000;
            trackBar2.Maximum = 6000;
            trackBar2.TickFrequency = 25;
            trackBar2.SmallChange = 5;
            trackBar2.LargeChange = 25;
            trackBar2.Value = 5524;

            //滑块三
            trackBar3.Minimum = 30000;
            trackBar3.Maximum = 40000;
            trackBar3.TickFrequency = 25;
            trackBar3.SmallChange = 5;
            trackBar3.LargeChange = 25;
            trackBar3.Value = 32840;

            //滑块四
            trackBar4.Minimum = 1000;
            trackBar4.Maximum = 2000;
            trackBar4.TickFrequency = 25;
            trackBar4.SmallChange = 5;
            trackBar4.LargeChange = 25;
            trackBar4.Value = 1510;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar4.Value.ToString();
        }
    }
}
