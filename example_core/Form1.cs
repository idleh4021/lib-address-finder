using Address_Finder.Model;

namespace example_core
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_finder frm = new frm_finder();
            frm.ShowDialog();
            List<juso> data = new List<juso>();
            if (frm.Selected_Address == null) return;
            data.Add(frm.Selected_Address);
            dataGridView1.DataSource = data;
        }
    }
}
