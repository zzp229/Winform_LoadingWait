using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static 加载页面.Loading;

namespace 加载页面
{
    //    public partial class FrmWelcom : Form, ISplashForm
    //    {
    //        Timer timer;
    //        public FrmWelcom()
    //        {
    //            InitializeComponent();
    //            timer = new Timer();
    //            timer.Interval = 100;
    //            timer.Enabled = true;
    //            timer.Tick += Timer_Tick;
    //            timer.Start();
    //        }

    //        int count = 0;
    //        private void Timer_Tick(object sender, EventArgs e)
    //        {
    //            count++;
    //            this.label1.Text = count.ToString();
    //        }

    //        private void FrmWelcom_Load(object sender, EventArgs e)
    //        {

    //        }

    //        public void SetStatusInfo(string NewStatusInfo)
    //        {
    //            ShowFrmMainInfo(this.listView, NewStatusInfo);  //接收主窗体发送的消息 并显示到加载页面
    //        }

    //        private void ShowFrmMainInfo(ListView lsv, string info)
    //        {
    //            //this.Invoke(new Action(() =>
    //            //{
    //                ListViewItem lvItem = new ListViewItem();

    //                this.listView.Items.AddRange(new ListViewItem[] { lvItem });
    //                this.listView.EnsureVisible(listView.Items.Count - 1);  //如果信息比较多，滚动到最后一条
    //            //}));
    //        }

    //    }


    public partial class FrmWelcom : Form, ISplashForm
    {
        Timer timer;
        public FrmWelcom()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void FrmWelcom_Load(object sender, EventArgs e)
        {
            // 异步加载图片
            string imagePath = "D:\\window\\Visual Studio 2022\\Projects\\64gX课堂\\加载页面\\image\\loading.gif";
            Image gifImage = await LoadImageAsync(imagePath);

            // 显示图片
            pictureBox.Image = gifImage;
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void FrmWelcom_Shown(object sender, EventArgs e)
        {
            // 显示窗口
            this.Show();
        }

        int count = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 计算加载进度
            int progress = count * 100 / 100;

            // 显示加载进度的百分比
            this.label1.Text = $"Loading... {progress}%";
        }

        public void SetStatusInfo(string NewStatusInfo)
        {
            ShowFrmMainInfo(this.listView, NewStatusInfo);  //接收主窗体发送的消息 并显示到加载页面
        }

        private void ShowFrmMainInfo(ListView lsv, string info)
        {
            //this.Invoke(new Action(() =>
            //{
            ListViewItem lvItem = new ListViewItem();

            this.listView.Items.AddRange(new ListViewItem[] { lvItem });
            this.listView.EnsureVisible(listView.Items.Count - 1);  //如果信息比较多，滚动到最后一条
                                                                    //}));
        }

        private async Task<Image> LoadImageAsync(string imagePath)
        {
            // 异步加载图片
            using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                return await Task.Run(() => Image.FromStream(stream));
            }
        }
    }
}
