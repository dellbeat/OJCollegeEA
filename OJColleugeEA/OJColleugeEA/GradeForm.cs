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
    public partial class GradeForm : Form
    {
        //200 24
        public GradeForm()
        {
            InitializeComponent();
        }

        private void DrawDateLabel(int height, int width, int x, int y, string text, string name, float size)
        {
            Label label = new Label();
            label.Name = name;
            label.Text = text;
            label.Height = height;
            label.Width = width;
            label.Font = new Font("微软雅黑", size);
            label.TextAlign = ContentAlignment.MiddleCenter;
            Point points = new Point(x, y);
            label.Location = points;
            this.Controls.Add(label);
        }
    }
}
