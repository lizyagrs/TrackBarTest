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
    public partial class FrmTrackBar : Form
    {
        //总面积=建设用地面积+耕地面积+草地面积，水域面积不能减小，因此不计入总数
        int totalArea = 510 + 5524 + 32840;
        int leftArea = 0;//(38874 -  5524 - 32840);
        int changeArea_Build = 0;
        public FrmTrackBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 滑动条1滑动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            //建设用地变化面积【这里只增加，因此即增加面积】
            changeArea_Build = trackBar1.Value - 510;
            ///【总面积是一定的，建设用地面积增加，必定会使耕地或者林地面积减少】，默认为耕地和林地各减少一半。
            leftArea = changeArea_Build / 2;
            //耕地面积减少建设用地增加值的一半
            trackBar2.Value = 5524 - leftArea;
            //林地面积减少建设用地增加值的一半
            trackBar3.Value = 32840 - leftArea;
            //实时显示滑动条2的值
            label2.Text = trackBar2.Value.ToString();
            //实时显示滑动条3的值
            label3.Text = trackBar3.Value.ToString();

        }

        /// <summary>
        /// 滑动条2滑动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
            //耕地变化面积=滑动条2的滑动值-标签值【滑动前的值】
            int changeArea_Cropland = trackBar2.Value - 5524;
            //如果耕地变化面积>=0，说明耕地面积增加

            int changeArea_Forest = 32840 - changeArea_Cropland;

            if (changeArea_Forest >= trackBar3.Minimum && changeArea_Forest <= trackBar3.Maximum)
            {
                //滑动条【林地】则需要减少相同的值
                trackBar3.Value = 32840 - changeArea_Cropland;
                label3.Text = trackBar3.Value.ToString();
            }
            else
            {
                MessageBox.Show("已经达到极值！");
                return;
            }
            
        }

        /// <summary>
        /// 滑动条3滑动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //标签栏实时显示滑动条的值
            //label3.Text = trackBar3.Value.ToString();
            ///剩余变化面积=总面积-滑动条1的值-滑动条2的值-滑动条3的值
            ///【总面积是一定的，建设用地面积增加，必定会使耕地或者林地面积减少】，默认为耕地和林地各减少一半。
            ///相应的，耕地面积


            int changeArea_Forest = trackBar3.Value - int.Parse(label3.Text);
            label3.Text = trackBar3.Value.ToString();

            int changeArea_Cropland = trackBar2.Value - changeArea_Forest;

            if (changeArea_Cropland >= trackBar2.Minimum && changeArea_Cropland <= trackBar2.Maximum) 
            {
                trackBar2.Value = trackBar2.Value - changeArea_Forest;
                label2.Text = trackBar2.Value.ToString();
            }
            else
            {
                MessageBox.Show("由于草地面积受限，林地调整已经达到极值！");
                return;
            }
           
        }

        /// <summary>
        /// 滑动条4滑动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar4.Value.ToString();
        }

        private void FrmTrackBar_Load(object sender, EventArgs e)
        {
            //设置滑块属性
            //滑块一
            trackBar1.Minimum = 510;
            trackBar1.Maximum = 800;
            trackBar1.TickFrequency = 25;
            trackBar1.SmallChange = 5;
            trackBar1.LargeChange = 25;
            trackBar1.Value = 510;
            label1.Text = trackBar1.Value.ToString();

            //滑块二
            trackBar2.Minimum = 4000;
            trackBar2.Maximum = 8000;
            trackBar2.TickFrequency = 25;
            trackBar2.SmallChange = 5;
            trackBar2.LargeChange = 25;
            trackBar2.Value = 5524;
            label2.Text = trackBar2.Value.ToString();

            //滑块三
            trackBar3.Minimum = 30000;
            trackBar3.Maximum = 34364;
            trackBar3.TickFrequency = 25;
            trackBar3.SmallChange = 5;
            trackBar3.LargeChange = 25;
            trackBar3.Value = 32840;
            label3.Text = trackBar3.Value.ToString();

            //滑块四
            trackBar4.Minimum = 1510;
            trackBar4.Maximum = 2000;
            trackBar4.TickFrequency = 25;
            trackBar4.SmallChange = 5;
            trackBar4.LargeChange = 25;
            trackBar4.Value = 1510;
            label4.Text = trackBar4.Value.ToString();
        }
    }
}
