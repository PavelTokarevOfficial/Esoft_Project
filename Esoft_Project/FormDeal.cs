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
    public partial class FormDeal : Form
    {
        public FormDeal()
        {
            InitializeComponent();
            ShowDemand();
            ShowDealSet();
            ShowSupply();
        }
        void ShowSupply()
        {
            comboBoxSupply.Items.Clear();
            foreach(SupplySet supplySet in Program.wftDb.SupplySet)
            {
                string[] item = { supplySet.Id.ToString() + ". ", "Риелтор: " + supplySet.AgentsSet.LastName, "Клиент: " + supplySet.ClientsSet.LastName };
                comboBoxSupply.Items.Add(string.Join(" ", item));
            }
        }
        void ShowDemand()
        {
            comboBoxDemand.Items.Clear();
            foreach (DemandSet demandSet in Program.wftDb.DemandSet)
            {
                string[] item = { demandSet.Id.ToString() + ". ", "Риелтор: " + demandSet.AgentsSet.LastName, "Клиент: " + demandSet.ClientsSet.LastName };
                comboBoxDemand.Items.Add(string.Join(" ", item));
            }
        }

        private void comboBoxSupply_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }

        private void comboBoxDemand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }
        void Deductions()
        {
            if(comboBoxSupply.SelectedItem!=null&& comboBoxDemand.SelectedItem != null)
            {
                SupplySet supplySet = Program.wftDb.SupplySet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                DemandSet demandSet = Program.wftDb.DemandSet.Find(Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]));
                double custometCompanyDeductions = supplySet.Price * 0.03;
                textCustomerCompanyDeductions.Text = custometCompanyDeductions.ToString("0.00");
                if (demandSet.AgentsSet.DealShare != null)
                {
                    double agentCostomerDeductions = custometCompanyDeductions * Convert.ToDouble(demandSet.AgentsSet.DealShare) / 100.00;
                    textBoxAgentCustomerDeductions.Text = agentCostomerDeductions.ToString("0.00");
                }
                else
                {
                    double agentCustomerDeductions = custometCompanyDeductions * 0.45;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDeductions.ToString("0.00");
                }
            }
            else
            {
                textCustomerCompanyDeductions.Text = "";
                textBoxAgentCustomerDeductions.Text = "";  
            }

            if (comboBoxSupply.SelectedItem != null)
            {
                SupplySet supplySet = Program.wftDb.SupplySet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                double sellerCompanyDeductions;
                if (supplySet.RealEstateSet.Type == 0)
                {
                    sellerCompanyDeductions = 36000 + supplySet.Price * 0.01;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                else if (supplySet.RealEstateSet.Type == 1)
                {
                    sellerCompanyDeductions = 30000 + supplySet.Price * 0.01;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                else
                {
                    sellerCompanyDeductions = 30000 + supplySet.Price * 0.02;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }

                if(supplySet.AgentsSet.DealShare != null)
                {
                    double agentSellDeductions = sellerCompanyDeductions * Convert.ToDouble(supplySet.AgentsSet.DealShare) / 100.00;
                    textBoxAgentSellerDeductions.Text = agentSellDeductions.ToString("0.00");
                }
                else
                {
                    double agentSellerDeductions = sellerCompanyDeductions * 0.45;
                    textBoxAgentSellerDeductions.Text = agentSellerDeductions.ToString("0.00");
                }
            }
            else
            {
                textBoxSellerCompanyDeductions.Text = "";
                textBoxAgentSellerDeductions.Text = "";
                textCustomerCompanyDeductions.Text = "";
                textBoxAgentCustomerDeductions.Text = "";
                
            }
        }
        void ShowDealSet()
        {
            ListViewDealSet.Items.Clear();
            foreach (DealSet deal in Program.wftDb.DealSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                    {
                        deal.SupplySet.ClientsSet.FirstName +" "+ deal.SupplySet.ClientsSet.MiddleName + " " + deal.SupplySet.ClientsSet.LastName,
                        deal.SupplySet.AgentsSet.FirstName+" "+ deal.SupplySet.AgentsSet.MiddleName + " " + deal.SupplySet.AgentsSet.LastName,
                        deal.DemandSet.ClientsSet.FirstName + " " + deal.DemandSet.ClientsSet.MiddleName + " " + deal.DemandSet.ClientsSet.LastName,
                        deal.DemandSet.AgentsSet.FirstName + " " + deal.DemandSet.AgentsSet.MiddleName + " " + deal.DemandSet.AgentsSet.LastName,
                        "г. "+ deal.SupplySet.RealEstateSet.Address_City + ", ул. " + deal.SupplySet.RealEstateSet.Address_Street + ", д. "+
                        deal.SupplySet.RealEstateSet.Address_House + ", кв. " + deal.SupplySet.RealEstateSet.Address_Number,
                        deal.SupplySet.Price.ToString()
                    });
                item.Tag = deal;
                ListViewDealSet.Items.Add(item);
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxDemand.SelectedItem != null && comboBoxSupply.SelectedItem != null)
            {
                DealSet deal = new DealSet();
                deal.IdSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                deal.IdDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);
                Program.wftDb.DealSet.Add(deal);
                Program.wftDb.SaveChanges();
                ShowDealSet();
            }
            else
            {
                MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(ListViewDealSet.SelectedItems.Count == 1)
            {
                DealSet deal = ListViewDealSet.SelectedItems[0].Tag as DealSet;
                deal.IdSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                deal.IdDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);
                Program.wftDb.SaveChanges();
                ShowDealSet();
            }

        }

        private void ListViewDealSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ListViewDealSet.SelectedItems.Count == 1)
            {
                DealSet deal = ListViewDealSet.SelectedItems[0].Tag as DealSet;
                comboBoxSupply.SelectedIndex = comboBoxSupply.FindString(deal.IdSupply.ToString());
                comboBoxDemand.SelectedIndex = comboBoxDemand.FindString(deal.IdDemand.ToString());
            }
            else
            {
                comboBoxSupply.SelectedItem = null;
                comboBoxDemand.SelectedItem = null;
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if(ListViewDealSet.SelectedItems.Count == 1)
                {
                    DealSet deal = ListViewDealSet.SelectedItems[0].Tag as DealSet;
                    Program.wftDb.DealSet.Remove(deal);
                    Program.wftDb.SaveChanges();
                    ShowDealSet();
                }
                comboBoxSupply.SelectedItem = null;
                comboBoxDemand.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
