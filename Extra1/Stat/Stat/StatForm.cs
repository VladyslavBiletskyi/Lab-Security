using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stat
{
    public partial class StatForm : Form
    {
        Dictionary<char, double> Statistics;
        StatisticsCollector Collector = new StatisticsCollector();
        public StatForm(int style)
        {
            InitializeComponent();
            StyleBox.DataSource = MainForm.Styles;
            StyleBox.SelectedIndex = style;
        }
        private void ShowStatistics()
        {
            StatPanel.Controls.Clear();
            int offset = 0;
            foreach (var element in Statistics.OrderByDescending(x=>x.Value))
            {
                TextBox t = new TextBox();
                t.Text = element.Key + " - " + (element.Value*100).ToString() + "%";
                t.Location = new Point(t.Location.X, offset);
                offset += t.Height * 2;
                StatPanel.Controls.Add(t);
            }
        }

        private void StyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Statistics = Collector.GetStat(StyleBox.SelectedIndex);
            ShowStatistics();
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            GraphForm gf = new GraphForm(StyleBox.SelectedIndex);
            gf.Show();
        }
    }
}
