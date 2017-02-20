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
    public partial class MainForm : Form
    {
        public static string[] Styles = { "Худ. произведение", "Тех. документация", "Сказка", "Выступление" };
        public MainForm()
        {
            InitializeComponent();
            StyleBox.DataSource = Styles;
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            if (StyleBox.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите тип анализируемого текста");
                return;
            }
            StatisticsCollector collector = new StatisticsCollector();
            collector.ImproveStat(StyleBox.SelectedIndex, SampleTextField.Text);
            SampleTextField.Clear();
            MessageBox.Show("Статистика успешно дополнена");
        }

        private void ShowStatButton_Click(object sender, EventArgs e)
        {
            StatForm sf = new StatForm(StyleBox.SelectedIndex);
            sf.Show();
        }

        private void ShowGraphButton_Click(object sender, EventArgs e)
        {
            GraphForm gf = new GraphForm(StyleBox.SelectedIndex);
            gf.Show();
        }
    }
}
