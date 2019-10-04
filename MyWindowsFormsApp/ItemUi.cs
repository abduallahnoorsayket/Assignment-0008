

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp
{
    public partial class ItemUi : Form
    {
        ItemManager _itemManager = new ItemManager();
        Item _item = new Item();
        public ItemUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Check UNIQUE
            _item.Name = nameTextBox.Text;

            if (_itemManager.IsNameExists(_item.Name))
            {
                MessageBox.Show(nameTextBox.Text + "Already Exists!");
                return;
            }

            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))            
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            _item.Price = Convert.ToDouble(priceTextBox.Text);

            //Add/Insert Item
           // bool isAdded = _itemManager.Add(_item.Name,_item.Price);
            bool isAdded = _itemManager.Add(_item);
            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _itemManager.Display();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _itemManager.Display();
        }



        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if ( _itemManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            //showDataGridView.DataSource = dataTable;

            showDataGridView.DataSource = _itemManager.Display();
        }



        private void updateButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            if (_itemManager.Update(nameTextBox.Text, Convert.ToDouble(priceTextBox.Text),
                Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");

                showDataGridView.DataSource = _itemManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {


            //Set Id as Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("  Name  Can not be Empty!!!");
                return;
            }


            showDataGridView.DataSource = _itemManager.Search(nameTextBox.Text);



            //if (_itemManager.Search(nameTextBox.Text)) 

            //{
            //    MessageBox.Show("Found");
            //    showDataGridView.DataSource = _itemManager.Search(nameTextBox.Text);

            //}
            //   else 
            //   {
            //        MessageBox.Show("Not Found");
            //    }
            

        }

        private void showDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (showDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex. != null )

              
                showDataGridView.CurrentRow.Selected = true;
                idTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
               nameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            //var st = (from s in db.MyInfoTabs where s.Name == int.Parse(Name) select s).First();
            //db.MyInfoTabs.Update(st);
            //DBNull.SubmitChanges();

            //loaddata();
            priceTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
           // Update(nm);


           
 

        }




        //Method




    }
}
