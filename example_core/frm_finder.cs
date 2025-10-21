using Address_Finder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example_core
{
    public partial class frm_finder : Form
    {
        const string api_key = "your_api_key";
        Address_Finder.Address_Finder address_finder;
        public juso? Selected_Address = null;
        public frm_finder()
        {
            InitializeComponent();
        }

        private void frm_finder_Load(object sender, EventArgs e)
        {
            address_finder = new Address_Finder.Address_Finder(api_key);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("검색어를 입력해주세요");
                return;
            }
            try
            {
                var result = address_finder.GetAddress(textBox1.Text);
                dataGridView1.DataSource = result;
                RefreshStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터를 찾을 수 없거나, 상세주소를 입력해주시기 바랍니다.");

            }
        }

        private void RefreshStatus()
        {
            label1.Text = $"{address_finder.CURRENT_PAGE} / {address_finder.TOTAL_PAGE} Pages";
            if (address_finder.CURRENT_PAGE < address_finder.TOTAL_PAGE)
            {
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
            }
            if (address_finder.CURRENT_PAGE > 1) { btnPrev.Enabled = true; } else { btnPrev.Enabled = false; }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = address_finder.MovePage(address_finder.CURRENT_PAGE + 1);
            RefreshStatus();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = address_finder.MovePage(address_finder.CURRENT_PAGE - 1);
            RefreshStatus();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            juso sel = (juso)dataGridView1.CurrentRow.DataBoundItem;
            Selected_Address = sel;
            MessageBox.Show($"선택된 주소지는\n{sel.roadAddr} [우]{sel.zipNo}\n입니다.");
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
