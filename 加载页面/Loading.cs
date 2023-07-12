using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 加载页面
{
    //定义接口
    public interface ISplashForm
    {
        void SetStatusInfo(string NewStatusInfo);
    }


    //这个才是类
    public class Loading
    {
        private static Thread m_SplashThread = null;

        private delegate void SplashStatusChangedHandle(string  NewStatusInfo);

        public static string Status = String.Empty;

        public static FrmWelcom frmWelcom = null;
    
     

        public static void Close(Form form)
        {
            form.Close();
        }

        internal static void ShowFrmWelcome(Type type)
        {

            if(type == typeof(FrmWelcom))
            {
                //new FrmWelcom().Show();
                frmWelcom = new FrmWelcom();
                frmWelcom.Show();

                //frmWelcom.ShowDialog();

                //Thread.Sleep(1000);

                //frmWelcom.Close();
            }
        }

        public static void Close()
        {
            frmWelcom.Close();
        }
    }
}
