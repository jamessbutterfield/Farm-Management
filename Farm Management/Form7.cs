using Classes.Part;
using Classes.LinkedList;
using System.Data.OleDb;

namespace Farm_Management
{
    public partial class Form7 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\FarmDatabase.accdb;Persist Security Info=False;";

        public static Form7? instance;
        
        public Form7()
        {
            InitializeComponent();
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            PopulateListBox();
            instance = this;
        }

        // Buttons

        private void AddSelectedParts(object sender, EventArgs e)
        {
            if (CheckPartsSelected() == true)
            {
                for (int i = 1; i <= GetCheckedParts().Count(); i++)
                {
                    Form6.instance?.SelectedParts?.AppendPart(GetCheckedParts().GetPart(i));
                }

                Form6.instance?.AddPartsToListBox(Form6.instance.SelectedParts);
                Close();
            }
        }

        private void CreateNewPart(object sender, EventArgs e)
        {
            using (Form8 form8 = new Form8())
                form8.ShowDialog();
        }

        private void DeleteSelectedParts(object sender, EventArgs e)
        {
            if (CheckPartsSelected() == true)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete these parts?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    LinkedList SelectedParts = GetCheckedParts();

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        for (int i = 1; i <= SelectedParts.Count(); i++)
                        {
                            using (OleDbCommand deletePartsFromRelatedTable = new OleDbCommand("DELETE FROM JobParts WHERE PartID=@PartID", connection))
                            {
                                deletePartsFromRelatedTable.Parameters.AddWithValue("@PartID", SelectedParts.GetPart(i).GetPartID());
                                deletePartsFromRelatedTable.ExecuteNonQuery();
                            }

                            using (OleDbCommand deleteParts = new OleDbCommand("DELETE FROM Parts WHERE PartID=@PartID", connection))
                            {
                                deleteParts.Parameters.AddWithValue("@PartID", SelectedParts.GetPart(i).GetPartID());
                                deleteParts.ExecuteNonQuery();
                            }
                        }
                    }

                    PopulateListBox();
                }
            }
        }

        // Displaying and Selecting Parts

        private LinkedList GetAllParts()
        {
            LinkedList parts = new LinkedList();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getParts = new OleDbCommand("SELECT * FROM Parts", connection))
                {
                    using (OleDbDataReader reader = getParts.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Part CurrentPart = new Part(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
                            parts.AppendPart(CurrentPart);
                        }
                    }
                }
            }

            return parts;
        }

        public void PopulateListBox()
        {
            checkedListBoxParts.Items.Clear();
            LinkedList parts = GetAllParts();

            if (Form6.instance?.SelectedParts?.Count() != 0)
            {
                for (int i = 1; i <= Form6.instance?.SelectedParts?.Count(); i++)
                {
                    parts.RemovePart(Form6.instance.SelectedParts.GetPart(i).GetPartID());
                }
            }
            
            for (int i = 1; i <= parts.Count(); i++)
            {
                checkedListBoxParts.Items.Add($"{parts.GetPart(i).GetName()} [{parts.GetPart(i).GetNumber()}]");
            }
        }

        private LinkedList GetCheckedParts()
        {
            LinkedList selectedItems = new LinkedList();

            if (checkedListBoxParts.CheckedItems.Count != 0)
            { 
                for (int i = 0; i < checkedListBoxParts.CheckedItems.Count; i++)
                {
                    selectedItems.Append(checkedListBoxParts.CheckedItems[i].ToString());
                }

                return ConvertSelectedPartsToPart(selectedItems);
            }

            return selectedItems;
        }

        private Part GetPart(string PartNumber)
        {
            int PartID = 0;
            string PartName = "";
            double Price = 0;
            
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand getPart = new OleDbCommand("SELECT * FROM Parts WHERE PartNumber=@PartNumber", connection))
                {
                    getPart.Parameters.AddWithValue("@PartNumber", PartNumber);
                    using (OleDbDataReader reader = getPart.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PartID = reader.GetInt32(0);
                            PartName = reader.GetString(1);
                            Price = reader.GetDouble(3);
                        }
                    }
                }
            }

            Part part = new Part(PartID, PartName, PartNumber, Price);
            return part;
        }

        private LinkedList ConvertSelectedPartsToPart(LinkedList selectedItems)
        {
            LinkedList parts = new LinkedList();
            
            for (int i = 1; i <= selectedItems.Count(); i++)
            {
                int StartIndex = 0;
                
                for (int j = 0; j < selectedItems.GetItem(i).Length; j++)
                {
                    if (selectedItems.GetItem(i)[j] == '[')
                        StartIndex = j + 1;
                }

                string PartNumber = "";

                for (int k = StartIndex; k < selectedItems.GetItem(i).Length - 1; k++)
                {
                    PartNumber += selectedItems.GetItem(i)[k];
                }

                parts.AppendPart(GetPart(PartNumber));
            }

            return parts;
        }

        // Validation Checks

        private bool CheckPartsSelected()
        {
            if (checkedListBoxParts.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select a Part or Parts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
