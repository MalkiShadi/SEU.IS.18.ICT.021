using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SEU.IS._18.ICT._021
{
    public partial class Form1 : Form
    {
        private bool isClubMember;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
           
                var bookPrices = new Dictionary<string, decimal>
    {
        { "The Lord of the Rings", 19.99m },
        { "Harry Potter and the Sorcerer's Stone", 12.99m },
        { "Pride and Prejudice", 8.99m },
        { "To Kill a Mockingbird", 11.99m },
        { "The Great Gatsby", 9.99m },
        { "The Catcher in the Rye", 10.99m },
        { "1984", 7.99m },
        { "The Hitchhiker's Guide to the Galaxy", 14.99m },
        { "The Alchemist", 12.99m },
        { "The Silent Patient", 16.99m },
    };

                // Get user input
                string selectedBook = bookcombo.SelectedItem.ToString().Split('-')[0].Trim();
                int quantity = int.Parse(Quantity.Text);
                string membership = comboBox1.SelectedItem.ToString();
                bool isClubMember;

                // Calculate total price before discount
                decimal pricePerItem = bookPrices[selectedBook];
                decimal totalPrice = pricePerItem * quantity;

                // Check for available quantity
                int availableQuantity = 25;
                if (quantity > availableQuantity)
                {
                    MessageBox.Show("Error: Entered quantity exceeds available stock!");
                    return;
                }

             
                decimal discount = 0;
          
                List<decimal> applicableDiscounts = new List<decimal>();
                if(membership == "club")
                {
                        isClubMember = true;
                }
                else
                {
                        isClubMember = false;
                }
               


                // Bulk Purchase Discount
                if (!isClubMember && totalPrice >= 50)
                {
                    applicableDiscounts.Add(totalPrice * 0.10m);
                }

                // Club Member Discount
                if (isClubMember)
                {
                    applicableDiscounts.Add(totalPrice * 0.12m);
                }

                // Series Bundle Discount
                if (selectedBook == "Harry Potter and the Sorcerer's Stone")
                {
                    applicableDiscounts.Add(totalPrice * 0.15m);
                }

                // Sci-Fi/Fantasy Discount
                if (selectedBook == "The Hitchhiker's Guide to the Galaxy")
                {
                    applicableDiscounts.Add(totalPrice * 0.15m);
                }

                // Self-Help Discount
                if (selectedBook == "The Alchemist")
                {
                    applicableDiscounts.Add(totalPrice * 0.15m);
                }

                // Apply the top two discounts, if applicable
                if (!isClubMember && totalPrice >= 50)
                {
                    // If Bulk Purchase is considered, ignore other discounts
                    discount = applicableDiscounts.FirstOrDefault(); // Bulk Purchase is first in the list
                }
                else
                {
                    // Sort and take the top two discounts
                    applicableDiscounts.Sort((a, b) => b.CompareTo(a)); // Sort descending
                    discount = applicableDiscounts.Take(2).Sum();
                }


            // Calculate final price
            decimal finalPrice = totalPrice - discount;

            // bill
            output.Text = $"Book: {selectedBook}{Environment.NewLine}" +
                          $"Quantity: {quantity}{Environment.NewLine}" +
                          $"Price/Item: ${pricePerItem}{Environment.NewLine}" +
                          $"Total Price (Before Discount): ${totalPrice}{Environment.NewLine}" +
                          $"Discount: ${discount}{Environment.NewLine}" +
                          $"Total Price (After Discount): ${finalPrice}";
        }
        }
    }



