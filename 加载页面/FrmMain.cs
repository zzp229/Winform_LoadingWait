﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 加载页面
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            Thread.Sleep(1000);

            Loading.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            

            
        }
    }
}
