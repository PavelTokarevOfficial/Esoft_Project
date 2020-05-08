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
    public partial class FormDemand : Form
    {
        public FormDemand()
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;
            ShowAgents();
            ShowClients();
            ShowDemandSet();
        }
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                listViewDemand_Apartment.Visible = true;
                labelAgents.Visible = true;
                comboBoxAgents.Visible = true;
                labelClients.Visible = true;
                comboBoxClients.Visible = true;
                labelType.Visible = true;
                comboBoxType.Visible = true;
                labelMinPrice.Visible = true;
                textBoxMinPrice.Visible = true;
                labelMaxPrice.Visible = true;
                textBoxMaxPrice.Visible = true;
                labelMinArea.Visible = true;
                textBoxMinArea.Visible = true;
                labelMaxArea.Visible = true;
                textBoxMaxArea.Visible = true;
                labelMinFloor.Visible = true;
                textBoxMinFloor.Visible = true;
                labelMaxFloor.Visible = true;
                textBoxMaxFloor.Visible = true;
                labelMinRooms.Visible = true;
                textBoxMinRooms.Visible = true;
                labelMaxRooms.Visible = true;
                textBoxMaxRooms.Visible = true;
                listViewDemand_House.Visible = false;
                listViewDemand_Land.Visible = false;

                labelMinFloors.Visible = false;
                textBoxMinFloors.Visible = false;
                labelMaxFloors.Visible = false;
                textBoxMaxFloors.Visible = false;

                //textBoxMinPrice.Text = "";
                //textBoxMaxPrice.Text = "";
                //textBoxMinArea.Text = "";
                //textBoxMaxArea.Text = "";
                //textBoxMinFloor.Text = "";
                //textBoxMaxFloor.Text = "";
                //textBoxMinRooms.Text = "";
                //textBoxMaxRooms.Text = "";
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                listViewDemand_House.Visible = true;
                labelAgents.Visible = true;
                comboBoxAgents.Visible = true;
                labelClients.Visible = true;
                comboBoxClients.Visible = true;
                labelType.Visible = true;
                comboBoxType.Visible = true;
                labelMinPrice.Visible = true;
                textBoxMinPrice.Visible = true;
                labelMaxPrice.Visible = true;
                textBoxMaxPrice.Visible = true;
                labelMinArea.Visible = true;
                textBoxMinArea.Visible = true;
                labelMaxArea.Visible = true;
                textBoxMaxArea.Visible = true;
                labelMinFloors.Visible = true;
                textBoxMinFloors.Visible = true;
                labelMaxFloors.Visible = true;
                textBoxMaxFloors.Visible = true;

                listViewDemand_Apartment.Visible = false;
                listViewDemand_Land.Visible = false;
                labelMinRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMaxRooms.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;

                //textBoxMinPrice.Text = "";
                //textBoxMaxPrice.Text = "";
                //textBoxMinArea.Text = "";
                //textBoxMaxArea.Text = "";
                //textBoxMinFloors.Text = "";
                //textBoxMaxFloors.Text = "";
            }
            else if (comboBoxType.SelectedIndex == 2)
            {
                listViewDemand_Land.Visible = true;
                labelAgents.Visible = true;
                comboBoxAgents.Visible = true;
                labelClients.Visible = true;
                comboBoxClients.Visible = true;
                labelType.Visible = true;
                comboBoxType.Visible = true;
                labelMinPrice.Visible = true;
                textBoxMinPrice.Visible = true;
                labelMaxPrice.Visible = true;
                textBoxMaxPrice.Visible = true;
                labelMinArea.Visible = true;
                textBoxMinArea.Visible = true;
                labelMaxArea.Visible = true;
                textBoxMaxArea.Visible = true;
                listViewDemand_Apartment.Visible = false;
                listViewDemand_House.Visible = false;
                labelMinFloor.Visible = false;
                textBoxMinFloor.Visible = false;
                labelMaxFloor.Visible = false;
                textBoxMaxFloor.Visible = false;
                labelMinRooms.Visible = false;
                textBoxMinRooms.Visible = false;
                labelMaxRooms.Visible = false;
                textBoxMaxRooms.Visible = false;
                labelMinFloors.Visible = false;
                textBoxMinFloors.Visible = false;
                labelMaxFloors.Visible = false;
                textBoxMaxFloors.Visible = false;
            }
            
        }
        void ShowAgents()
        {
            comboBoxAgents.Items.Clear();
            foreach (AgentsSet agentsSet in Program.wftDb.AgentsSet)
            {
                string[] item = { agentsSet.Id.ToString() + ".", agentsSet.FirstName, agentsSet.MiddleName, agentsSet.LastName };
                comboBoxAgents.Items.Add(string.Join(" ", item));
            }
        }
        void ShowClients()
        {
            comboBoxClients.Items.Clear();
            foreach (ClientsSet clientsSet in Program.wftDb.ClientsSet)
            {
                string[] item = { clientsSet.Id.ToString() + ".", clientsSet.FirstName, clientsSet.MiddleName, clientsSet.LastName };
                comboBoxClients.Items.Add(string.Join(" ", item));

            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DemandSet demandSet = new DemandSet();

            if (comboBoxType.SelectedIndex == 0)
            {
                demandSet.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                demandSet.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                demandSet.Type = Convert.ToInt32(comboBoxType.SelectedIndex);
                demandSet.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                demandSet.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                demandSet.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                demandSet.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                demandSet.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                demandSet.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                demandSet.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                demandSet.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
            }
            else if (comboBoxType.SelectedIndex == 1)
            {

                demandSet.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                demandSet.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                demandSet.Type = Convert.ToInt32(comboBoxType.SelectedIndex);
                demandSet.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                demandSet.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                demandSet.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                demandSet.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                demandSet.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                demandSet.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
                
            }
            else if(comboBoxType.SelectedIndex == 2)
            {
                demandSet.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                demandSet.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                demandSet.Type = Convert.ToInt32(comboBoxType.SelectedIndex);
                demandSet.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                demandSet.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                demandSet.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                demandSet.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);

            }
            else MessageBox.Show("Данный не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Program.wftDb.DemandSet.Add(demandSet);
            Program.wftDb.SaveChanges();
            ShowDemandSet();
        }
        void ShowDemandSet()
        {
            listViewDemand_Apartment.Items.Clear();
            listViewDemand_House.Items.Clear();
            listViewDemand_Land.Items.Clear();
            foreach (DemandSet demandSet in Program.wftDb.DemandSet)
            {
                
                if (demandSet.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demandSet.IdAgent.ToString() + ". " + demandSet.AgentsSet.FirstName + " " + " " + demandSet.AgentsSet.MiddleName + " " + demandSet.AgentsSet.LastName,
                        demandSet.IdClient.ToString() + ". " + demandSet.ClientsSet.FirstName + " " + " " + demandSet.ClientsSet.MiddleName + " " + demandSet.ClientsSet.LastName,
                        demandSet.Type.ToString()+". Квартира",
                        demandSet.MinPrice.ToString(),
                        demandSet.MaxPrice.ToString(),
                        demandSet.MinArea.ToString(),
                        demandSet.MaxArea.ToString(),
                        demandSet.MinRooms.ToString(),
                        demandSet.MaxRooms.ToString(),
                        demandSet.MinFloor.ToString(),
                        demandSet.MaxFloor.ToString()
                    });
                    item.Tag = demandSet;
                    listViewDemand_Apartment.Items.Add(item);
                }
                else if (demandSet.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demandSet.IdAgent.ToString() + ". " + demandSet.AgentsSet.FirstName + " " + " " + demandSet.AgentsSet.MiddleName + " " + demandSet.AgentsSet.LastName,
                        demandSet.IdClient.ToString() + ". " + demandSet.ClientsSet.FirstName + " " + " " + demandSet.ClientsSet.MiddleName + " " + demandSet.ClientsSet.LastName,
                        demandSet.Type.ToString() +". Квартира",
                        demandSet.MinPrice.ToString(),
                        demandSet.MaxPrice.ToString(),
                        demandSet.MinArea.ToString(),
                        demandSet.MaxArea.ToString(),
                        demandSet.MinFloors.ToString(),
                        demandSet.MaxFloors.ToString()
                    });
                    item.Tag = demandSet;
                    listViewDemand_House.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        demandSet.IdAgent.ToString()  + ". " + demandSet.AgentsSet.FirstName + " " + " " + demandSet.AgentsSet.MiddleName + " " + demandSet.AgentsSet.LastName,
                        demandSet.IdClient.ToString()  + ". " + demandSet.ClientsSet.FirstName + " " + " " + demandSet.ClientsSet.MiddleName + " " + demandSet.ClientsSet.LastName,
                        demandSet.Type.ToString()  +". Квартира",
                        demandSet.MinPrice.ToString(),
                        demandSet.MaxPrice.ToString(),
                        demandSet.MinArea.ToString(),
                        demandSet.MaxArea.ToString(),
                    });
                    item.Tag = demandSet;
                    listViewDemand_Land.Items.Add(item);
                }
            }
            listViewDemand_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewDemand_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewDemand_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewDemand_Apartment.SelectedItems.Count == 1)
                {
                    DemandSet demandSet = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                    demandSet.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                    demandSet.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                    demandSet.Type = Convert.ToInt32(comboBoxType.SelectedIndex);
                    demandSet.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demandSet.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                    demandSet.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demandSet.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    demandSet.MinRooms = Convert.ToInt32(textBoxMinRooms.Text);
                    demandSet.MaxRooms = Convert.ToInt32(textBoxMaxRooms.Text);
                    demandSet.MinFloor = Convert.ToInt32(textBoxMinFloor.Text);
                    demandSet.MaxFloor = Convert.ToInt32(textBoxMaxFloor.Text);
                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                if (listViewDemand_House.SelectedItems.Count == 1)
                {
                    DemandSet demandSet = listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                    demandSet.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                    demandSet.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                    demandSet.Type = Convert.ToInt32(comboBoxType.SelectedIndex);
                    demandSet.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demandSet.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                    demandSet.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demandSet.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    demandSet.MinFloors = Convert.ToInt32(textBoxMinFloors.Text);
                    demandSet.MaxFloors = Convert.ToInt32(textBoxMaxFloors.Text);
                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
            else
            {
                if (listViewDemand_Land.SelectedItems.Count == 1)
                {
                    DemandSet demandSet = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
                    demandSet.IdAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                    demandSet.IdClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                    demandSet.Type = Convert.ToInt32(comboBoxType.SelectedIndex);
                    demandSet.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demandSet.MaxPrice = Convert.ToInt64(textBoxMaxPrice.Text);
                    demandSet.MinArea = Convert.ToDouble(textBoxMinArea.Text);
                    demandSet.MaxArea = Convert.ToDouble(textBoxMaxArea.Text);
                    Program.wftDb.SaveChanges();
                    ShowDemandSet();
                }
            }
        }

        private void listViewDemand_Apartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemand_Apartment.SelectedItems.Count == 1)
            {
                DemandSet demandSet = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(demandSet.IdAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(demandSet.IdClient.ToString());
                comboBoxType.SelectedIndex = Convert.ToInt32(demandSet.Type);
                textBoxMinPrice.Text = demandSet.MinPrice.ToString();
                textBoxMaxPrice.Text = demandSet.MaxPrice.ToString();
                textBoxMinArea.Text = demandSet.MinArea.ToString();
                textBoxMaxArea.Text = demandSet.MaxArea.ToString();
                textBoxMinRooms.Text = demandSet.MinRooms.ToString();
                textBoxMaxRooms.Text = demandSet.MaxRooms.ToString();
                textBoxMinFloor.Text = demandSet.MinFloor.ToString();
                textBoxMaxFloor.Text = demandSet.MaxFloor.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxType.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinRooms.Text = "";
                textBoxMaxRooms.Text = "";
                textBoxMinFloor.Text = "";
                textBoxMaxFloor.Text = "";
            }
        }

        private void listViewDemand_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemand_House.SelectedItems.Count == 1)
            {
                DemandSet demandSet = listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(demandSet.IdAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(demandSet.IdClient.ToString());
                comboBoxType.SelectedIndex = Convert.ToInt32(demandSet.Type);
                textBoxMinPrice.Text = demandSet.MinPrice.ToString();
                textBoxMaxPrice.Text = demandSet.MaxPrice.ToString();
                textBoxMaxArea.Text = demandSet.MaxArea.ToString();
                textBoxMinFloors.Text = demandSet.MinFloors.ToString();
                textBoxMaxFloors.Text = demandSet.MaxFloors.ToString();
            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxType.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMaxArea.Text = "";
                textBoxMinFloors.Text = "";
                textBoxMaxFloors.Text = "";
            }
        }

        private void listViewDemand_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            DemandSet demandSet = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
            if (listViewDemand_Land.SelectedItems.Count == 1)
            {
                comboBoxAgents.SelectedIndex = comboBoxAgents.FindString(demandSet.IdAgent.ToString());
                comboBoxClients.SelectedIndex = comboBoxClients.FindString(demandSet.IdClient.ToString());
                comboBoxType.SelectedIndex = Convert.ToInt32(demandSet.Type);
                textBoxMinPrice.Text = demandSet.MinPrice.ToString();
                textBoxMaxPrice.Text = demandSet.MaxPrice.ToString();
                textBoxMinArea.Text =  demandSet.MinArea.ToString();
                textBoxMaxArea.Text = demandSet.MaxArea.ToString();

            }
            else
            {
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxType.SelectedItem = null;
                textBoxMinPrice.Text = "";
                textBoxMaxPrice.Text = "";
                textBoxMinArea.Text = "";
                textBoxMaxArea.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxType.SelectedIndex == 0)
                {
                    if(listViewDemand_Apartment.SelectedItems.Count==1)
                    {
                        DemandSet demandSet = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demandSet);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    comboBoxAgents.SelectedItem = null;
                    comboBoxClients.SelectedItem = null;
                    comboBoxType.SelectedItem = null;
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMaxRooms.Text = "";
                    textBoxMinFloor.Text = "";
                    textBoxMaxFloor.Text = "";
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewDemand_House.SelectedItems.Count == 1)
                    {
                        DemandSet demandSet = listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demandSet);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                    comboBoxAgents.SelectedItem = null;
                    comboBoxClients.SelectedItem = null;
                    comboBoxType.SelectedItem = null;
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrice.Text = "";
                    textBoxMinArea.Text = "";
                    textBoxMaxArea.Text = "";
                    textBoxMinRooms.Text = "";
                    textBoxMaxRooms.Text = "";
                    textBoxMinFloor.Text = "";
                    textBoxMaxFloor.Text = "";
                }
                else
                {
                    if (listViewDemand_Land.SelectedItems.Count == 1)
                    {
                        DemandSet demandSet = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
                        Program.wftDb.DemandSet.Remove(demandSet);
                        Program.wftDb.SaveChanges();
                        ShowDemandSet();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
