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
    public partial class GraphForm : Form
    {
        Dictionary<char, double> Statistics;
        StatisticsCollector Collector = new StatisticsCollector();
        private static int LetterWidth = 40;
        private static int FullColumnHeight = 1000;
        Graphics graph;
        Brush brush = new SolidBrush(Color.BlueViolet);
        int offset = 10;
        int scrollOffset = 0;
        public GraphForm(int style)
        {
            InitializeComponent();
            StyleBox.DataSource = MainForm.Styles;
            StyleBox.SelectedIndex = style;
        }

        private void ShowStatistics()
        {
            GraphPanel.Controls.Clear();
            graph = GraphPanel.CreateGraphics();
            offset = 10;
            foreach (var element in Statistics.OrderByDescending(x => x.Value))
            {
                Label l = new Label();
                l.Text = element.Key+"";
                l.Location = new Point(offset, l.Location.Y);
                l.Width = LetterWidth;
                GraphPanel.Controls.Add(l);
                graph.FillRectangle(brush, offset , 50, LetterWidth / 2, FullColumnHeight*Convert.ToSingle(element.Value) );
                offset += LetterWidth;
            }
        }

        private void StyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Statistics = Collector.GetStat(StyleBox.SelectedIndex);
            ShowStatistics();
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            graph = GraphPanel.CreateGraphics();
            graph.Clear(GraphPanel.BackColor);
            offset = 10-scrollOffset;
            foreach (var element in Statistics.OrderByDescending(x => x.Value))
            {
                graph.FillRectangle(brush, offset, 50, LetterWidth / 2, FullColumnHeight * Convert.ToSingle(element.Value));
                offset += LetterWidth;
            }
        }

        private void GraphPanel_Scroll(object sender, ScrollEventArgs e)
        {
            scrollOffset = e.NewValue;
        }
    }
}
