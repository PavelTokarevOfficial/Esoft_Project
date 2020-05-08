using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormAgents : Form
    {
        public FormAgents()
        {
            InitializeComponent();
            ShowAgents();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AgentsSet agentsSet = new AgentsSet();
            agentsSet.FirstName = textBoxFirstName.Text;
            agentsSet.MiddleName = textBoxMiddleName.Text;
            agentsSet.LastName = textBoxLastName.Text;
            agentsSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
            Program.wftDb.AgentsSet.Add(agentsSet);
            Program.wftDb.SaveChanges();
            ShowAgents();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(listViewAgents.SelectedItems.Count==1)
            {
                AgentsSet agentsSet = listViewAgents.SelectedItems[0].Tag as AgentsSet;
                agentsSet.FirstName = textBoxFirstName.Text;
                agentsSet.MiddleName = textBoxMiddleName.Text;
                agentsSet.LastName = textBoxLastName.Text;
                agentsSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                Program.wftDb.SaveChanges();
                ShowAgents();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if(listViewAgents.SelectedItems.Count == 1)
                {
                    AgentsSet agentsSet = listViewAgents.SelectedItems[0].Tag as AgentsSet;
                    Program.wftDb.AgentsSet.Remove(agentsSet);
                    Program.wftDb.SaveChanges();
                    ShowAgents();
                }
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
                    
            }
            catch 
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ShowAgents()
        {
            listViewAgents.Items.Clear();
            foreach(AgentsSet agentsSet in Program.wftDb.AgentsSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    agentsSet.Id.ToString(),agentsSet.FirstName,agentsSet.MiddleName,agentsSet.LastName,agentsSet.DealShare.ToString()
                });
                item.Tag = agentsSet;
                listViewAgents.Items.Add(item);
            }
            listViewAgents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            
        }

        private void listViewAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAgents.SelectedItems.Count == 1)
            {
                AgentsSet agentsSet = listViewAgents.SelectedItems[0].Tag as AgentsSet;
                textBoxFirstName.Text = agentsSet.FirstName;
                textBoxMiddleName.Text = agentsSet.MiddleName;
                textBoxLastName.Text = agentsSet.LastName;
                textBoxDealShare.Text = Convert.ToString(agentsSet.DealShare);
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
        }

        
    }
}
