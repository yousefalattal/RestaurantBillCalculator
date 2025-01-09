using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantBillCalculator
{
    public partial class Form1 : Form
    {
        private Dictionary<string, double> beverages = new Dictionary<string, double>
        {
            { "Soda", 1.95 },
            { "Tea", 1.50 },
            { "Coffee", 1.25 },
            { "Mineral Water", 2.95 },
            { "Juice", 2.50 },
            { "Milk", 1.50 }
        };

        private Dictionary<string, double> appetizers = new Dictionary<string, double>
        {
            { "Buffalo Wings", 5.95 },
            { "Potato Skins", 8.95 },
            { "Nachos", 8.95 },
            { "Shrimp Cocktail", 12.95 },
            { "Mushroom Caps", 10.95 },
            { "Chips and Salsa", 6.95 }
        };

        private Dictionary<string, double> mainCourses = new Dictionary<string, double>
        {
            { "Chicken Alfredo", 13.95 },
            { "Chicken Piccata", 13.95 },
            { "Turkey Club", 11.95 },
            { "Lobster Pie", 19.95 },
            { "Prime Rib", 20.95 },
            { "Shrimp Scampi", 18.95 },
            { "Turkey Dinner", 13.95 },
            { "Stuffed Chicken", 14.95 },
            { "Seafood Alfredo", 15.95 }
        };

        private Dictionary<string, double> desserts = new Dictionary<string, double>
        {
            { "Apple Pie", 5.95 },
            { "Sundae", 3.95 },
            { "Carrot Cake", 5.95 },
            { "Mud Pie", 4.95 },
            { "Apple Crisp", 5.95 }
        };

        private double subtotal = 0.0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate ComboBoxes with Menu Items
            comboBoxBeverage.Items.AddRange(beverages.Keys.ToArray());
            comboBoxAppetizer.Items.AddRange(appetizers.Keys.ToArray());
            comboBoxMainCourse.Items.AddRange(mainCourses.Keys.ToArray());
            comboBoxDessert.Items.AddRange(desserts.Keys.ToArray());
        }

        private void comboBoxBeverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBeverage.SelectedIndex >= 0)
            {
                string selectedBeverage = comboBoxBeverage.SelectedItem.ToString();
                subtotal += beverages[selectedBeverage];
                UpdateBill();
            }
        }

        private void comboBoxAppetizer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAppetizer.SelectedIndex >= 0)
            {
                string selectedAppetizer = comboBoxAppetizer.SelectedItem.ToString();
                subtotal += appetizers[selectedAppetizer];
                UpdateBill();
            }
        }

        private void comboBoxMainCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainCourse.SelectedIndex >= 0)
            {
                string selectedMainCourse = comboBoxMainCourse.SelectedItem.ToString();
                subtotal += mainCourses[selectedMainCourse];
                UpdateBill();
            }
        }

        private void comboBoxDessert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDessert.SelectedIndex >= 0)
            {
                string selectedDessert = comboBoxDessert.SelectedItem.ToString();
                subtotal += desserts[selectedDessert];
                UpdateBill();
            }
        }

        private void UpdateBill()
        {
            double tax = subtotal * 0.16; // 16% tax
            double total = subtotal + tax;

            labelSubtotal.Text = $"Subtotal: ${subtotal:F2}";
            labelTax.Text = $"Tax: ${tax:F2}";
            labelTotal.Text = $"Total: ${total:F2}";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            subtotal = 0.0;
            labelSubtotal.Text = "Subtotal: $0.00";
            labelTax.Text = "Tax: $0.00";
            labelTotal.Text = "Total: $0.00";

            comboBoxBeverage.SelectedIndex = -1;
            comboBoxAppetizer.SelectedIndex = -1;
            comboBoxMainCourse.SelectedIndex = -1;
            comboBoxDessert.SelectedIndex = -1;

            textBoxTableNumber.Text = "";
            textBoxWaiterName.Text = "";
        }

        
    }
}
