using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJColleugeEA
{
    public partial class PublicClassForm : Form
    {
        public PublicClassForm()
        {
            InitializeComponent();
        }

        //GetClass getfc = null;
        string indexs = "";

        private void Init_Click(object sender, EventArgs e)
        {
            //getfc = new GetClass();
            ClassList.Rows.Clear();
            int index = 0;
            for (int i = 0; i < LoginInfo.PublicClassList.Count; i++)
            {
                index = ClassList.Rows.Add();
                ClassList.Rows[index].Cells[0].Value = i.ToString();
                ClassList.Rows[index].Cells[1].Value = LoginInfo.PublicClassList[i].ClassName;
                ClassList.Rows[index].Cells[2].Value = LoginInfo.PublicClassList[i].Teacher;
                ClassList.Rows[index].Cells[3].Value = LoginInfo.PublicClassList[i].Count.ToString();
            }
        }

        private void SelectClass_Click(object sender, EventArgs e)
        {

            MessageBox.Show(getfc.GetClasss(Index.Text));
        }

        //private Task GetClassTask()
        //{

        //}
    }
}
