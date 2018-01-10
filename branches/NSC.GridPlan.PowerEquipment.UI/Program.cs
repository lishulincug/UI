using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NSC.GridPlan.PowerEquipment.UI.UI;

namespace NSC.GridPlan.PowerEquipment.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Money Twins");
            Application.Run(new Form1());
            //Application.Run(new SubStationAttribute());
            //Application.Run(new LineInfoShow());
            //Application.Run(new LineAttribute());
            //Application.Run(new StationAttribute());
            //Application.Run(new FieldsManagement());
        }
    }
}
