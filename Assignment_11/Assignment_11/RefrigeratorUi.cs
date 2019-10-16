using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_11
{
    public partial class RefrigeratorUi : Form
    {
        Refrigerator refrigerator;
        bool isCreated = false;
        public RefrigeratorUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
           if(String.IsNullOrEmpty(maxWeightTextBox.Text))
            {
                MessageBox.Show("max weight must be an integer value");
                return;
            }
                refrigerator = new Refrigerator(Convert.ToInt32(maxWeightTextBox.Text));
                isCreated = true;
                MessageBox.Show("Saved");
           
               
            
            
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if(isCreated)
            {
                if(String.IsNullOrEmpty(itemsTextBox.Text)||String.IsNullOrEmpty(weightKgTextBox.Text))
                {
                    MessageBox.Show("item & weight must be integer");
                    return;
                }
                double addWeight = 0;
                addWeight = Convert.ToDouble(itemsTextBox.Text) * Convert.ToDouble(weightKgTextBox.Text);

                if (refrigerator.Validation(addWeight))
                {
                    MessageBox.Show("Weight Execeeded");
                }
                else
                {
                    weightDetailRichTextBox.Clear();


                    refrigerator.Add(Convert.ToInt32(itemsTextBox.Text), Convert.ToDouble(weightKgTextBox.Text));
                    currentWeightTextBox.Text = Convert.ToString(refrigerator.Current());

                    remainingWeightTextBox.Text = Convert.ToString(refrigerator.RemainWeight());
                    weightDetailRichTextBox.Text= refrigerator.GetDetails();
                    MessageBox.Show("Entered");


                  //  weightTextBox.Clear();
                  //  itemsTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter the max weight first");
            }

            
           

        }
    }
}
