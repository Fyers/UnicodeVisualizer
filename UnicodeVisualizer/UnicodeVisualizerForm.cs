using System.Globalization;
using System.Windows.Forms;

namespace UnicodeVisualizer
{
    public partial class UnicodeVisualizerForm : Form
    {
        public UnicodeVisualizerForm(string value)
        {
            InitializeComponent();
            txtPresentingValue.Text = value;
            ShowUnicodeTable(value);
        }

        public void ShowUnicodeTable(string value)
        {
            var count = 0;
            foreach (var c in value)
            {
                int cDez = (int)c;
                var item = new ListViewItem(count.ToString());
                item.SubItems.Add(c.ToString());
                item.SubItems.Add($"U+{cDez:x4}".ToUpper());
                item.SubItems.Add(cDez.ToString().ToUpper());
                item.SubItems.Add(CharUnicodeInfo.GetUnicodeCategory(c).ToString());
                listView1.Items.Add(item);
                count++;
            }            
        }

    }
        
}
