using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrackBarTest
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 默认用地现状和需求绑定
        /// </summary>
        public void lbl_landuse_Bind()
        {
            string sLandUse = "";
            StreamReader sr = new StreamReader("LandUse.txt", System.Text.Encoding.Default);
            try
            {
                //使用StreamReader类来读取文件
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                // 从数据流中读取每一行，直到文件的最后一行
                string strLine = sr.ReadLine();
                while (strLine != null)
                {
                    sLandUse = sLandUse + strLine;
                    strLine = sr.ReadLine();
                }
                //关闭此StreamReader对象
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sr.Close();
            }

            //拆分用地现状字符串
            string[] parts = sLandUse.Split(new char[] { ',' });
            lab_nowCuilt.Text = " " + parts[0] + Environment.NewLine;
            lab_nowForest.Text = " " + parts[1] + Environment.NewLine;
            lab_nowGrass.Text = " " + parts[2] + Environment.NewLine;
            lab_nowWater.Text = " " + parts[3] + Environment.NewLine;
            lab_nowBuild.Text = " " + parts[4] + Environment.NewLine;
            lbl_nowUnuse.Text = " " + parts[5] + Environment.NewLine;

            //用地需求参数获取
            string sDemandCuilt = parts[6];
            string sDemandForest = parts[7];
            string sDemandGrass = parts[8];
            string sDemandWater = parts[9];
            string sDemandBuild = parts[10];
            string sDemandNoUse = parts[11];

            //用地需求参数获取与绑定
            this.lbl_demand_cropland.Text = sDemandCuilt;
            this.lbl_demand_forest.Text = sDemandForest;
            this.lbl_demand_grass.Text = sDemandGrass;
            this.lbl_demand_water.Text = sDemandWater;
            this.lbl_demand_built.Text = sDemandBuild;
            this.lbl_demand_unuse.Text = sDemandNoUse;

            #region 给滑块设置默认需求数值
            //设置滑块属性
            //耕地滑块
            trackBarCult.Minimum = 4000;
            trackBarCult.Maximum = 6000;
            trackBarCult.TickFrequency = 25;
            trackBarCult.SmallChange = 5;
            trackBarCult.LargeChange = 25;
            trackBarCult.Value = Convert.ToInt32(sDemandCuilt);

            //林地滑块
            trackBarFore.Minimum = 5000;
            trackBarFore.Maximum = 6000;
            trackBarFore.TickFrequency = 25;
            trackBarFore.SmallChange = 5;
            trackBarFore.LargeChange = 25;
            trackBarFore.Value = Convert.ToInt32(sDemandForest);
            //草地滑块
            trackBarGrass.Minimum = 30000;
            trackBarGrass.Maximum = 40000;
            trackBarGrass.TickFrequency = 25;
            trackBarGrass.SmallChange = 5;
            trackBarGrass.LargeChange = 25;
            trackBarGrass.Value = Convert.ToInt32(sDemandGrass);
            //水域滑块
            trackBarWater.Minimum = 1510;
            trackBarWater.Maximum = 2000;
            trackBarWater.TickFrequency = 25;
            trackBarWater.SmallChange = 5;
            trackBarWater.LargeChange = 25;
            //水域值固定为
            trackBarWater.Value = Convert.ToInt32(sDemandWater);
            //建设用地滑块
            trackBarBuild.Minimum = 510;
            trackBarBuild.Maximum = 800;
            trackBarBuild.TickFrequency = 25;
            trackBarBuild.SmallChange = 5;
            trackBarBuild.LargeChange = 25;
            trackBarBuild.Value = Convert.ToInt32(sDemandBuild);

            trackBarUnuse.Minimum = 90000;
            trackBarUnuse.Maximum = 100000;
            trackBarUnuse.TickFrequency = 25;
            trackBarUnuse.SmallChange = 5;
            trackBarUnuse.LargeChange = 25;
            trackBarUnuse.Value = Convert.ToInt32(sDemandNoUse);

            #endregion

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ///加载界面各用地类型的默认面积值
            lbl_landuse_Bind();
        }

        /// <summary>
        /// 还原默认值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reductionLandUseDemand_Click(object sender, EventArgs e)
        {
            string sLandUse = "";

            StreamReader sr = new StreamReader("LandUse.txt", System.Text.Encoding.Default);
            try
            {
                //使用StreamReader类来读取文件
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                // 从数据流中读取每一行，直到文件的最后一行
                string strLine = sr.ReadLine();
                while (strLine != null)
                {
                    sLandUse = sLandUse + strLine;
                    strLine = sr.ReadLine();
                }
                //关闭此StreamReader对象
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sr.Close();
            }
            string[] parts = sLandUse.Split(new char[] { ',' });
            lab_nowCuilt.Text = " " + parts[0] + Environment.NewLine;
            lab_nowForest.Text = " " + parts[1] + Environment.NewLine;
            lab_nowGrass.Text = " " + parts[2] + Environment.NewLine;
            lab_nowWater.Text = " " + parts[3] + Environment.NewLine;
            lab_nowBuild.Text = " " + parts[4] + Environment.NewLine;
            lbl_nowUnuse.Text = " " + parts[5] + Environment.NewLine;

            string sDemandCuilt = parts[6];
            string sDemandForest = parts[7];
            string sDemandGrass = parts[8];
            string sDemandWater = parts[9];
            string sDemandBuild = parts[10];
            string sDemandNoUse = parts[11];

            trackBarCult.Value = Convert.ToInt32(sDemandCuilt);
            trackBarFore.Value = Convert.ToInt32(sDemandForest);
            trackBarGrass.Value = Convert.ToInt32(sDemandGrass);
            trackBarWater.Value = Convert.ToInt32(sDemandWater);
            trackBarBuild.Value = Convert.ToInt32(sDemandBuild);
            trackBarUnuse.Value = Convert.ToInt32(sDemandNoUse);

            lbl_demand_cropland.Text = trackBarCult.Value.ToString();
            lbl_demand_forest.Text = trackBarFore.Value.ToString();
            lbl_demand_grass.Text = trackBarGrass.Value.ToString();
            lbl_demand_water.Text = trackBarWater.Value.ToString();
            lbl_demand_built.Text = trackBarBuild.Value.ToString();
            lbl_demand_unuse.Text = trackBarUnuse.Value.ToString();
        }

        //总面积=建设用地面积+林地面积+草地面积+耕地面积+未利用地面积，水域面积不能减小，因此不计入总数
        int totalArea = 510 + 5889 + 32840 + 5524 + 96545;
        int leftArea = 0;//(38874 -  5524 - 32840);


        /// <summary>
        /// 建设用地滑动条事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarBuild_Scroll(object sender, EventArgs e)
        {
            //建设用地变化值
            int changeArea_Build = trackBarBuild.Value - Convert.ToInt32(lab_nowBuild.Text);
            ///【总面积是一定的，建设用地面积增加，必定会使其他用地类型面积减少】，水体不能减少，其余4种用地类型默认为1/4。
            leftArea = changeArea_Build / 4;

            ///耕地面积变化=原有耕地面积-建设用地变化面积的1/4
            trackBarCult.Value = Convert.ToInt32(lab_nowCuilt.Text) - leftArea;
            ///林地面积变化=原有林地面积-建设用地变化面积的1/4
            trackBarFore.Value = Convert.ToInt32(lab_nowForest.Text) - leftArea;
            ///草地面积变化=原有草地面积-建设用地变化面积的1/4
            trackBarGrass.Value = Convert.ToInt32(lab_nowGrass.Text) - leftArea;
            ///未利用地面积变化=原未利用地面积-建设用地变化面积的1/4
            trackBarUnuse.Value = Convert.ToInt32(lbl_nowUnuse.Text) - leftArea;


            lbl_demand_cropland.Text = trackBarCult.Value.ToString();
            lbl_demand_forest.Text = trackBarFore.Value.ToString();
            lbl_demand_grass.Text = trackBarGrass.Value.ToString();
            lbl_demand_water.Text = trackBarWater.Value.ToString();
            lbl_demand_built.Text = trackBarBuild.Value.ToString();
        }

    }
}
