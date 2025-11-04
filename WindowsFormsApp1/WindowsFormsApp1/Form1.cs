using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Create and initialize an object of the Random class, which will be used for generating the random numbers
        Random random = new Random();

        // The number of random numbers that will be generated will be stored in this variable
        decimal number_of_random_numbers;

        // The randomly generated numbers will be inserted in this array
        decimal[] numbers;

        // Each newly generated number will be stored in this variable, in order to check later if it's unique
        decimal new_number;

        // Set this variable to "true" if a newly generated number has already been generated
        Boolean duplicate_found; 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          /* The program can generate up to 1000 unique random numbers at a time. Trying to generate more than that would lead to an infinite loop.
             Therefore, we check if the random numbers that the user wants to generate are more than 1000, 1000, or less than 1000.
             If they're more than 1000, display a message notifying the user about that.
             Otherwise, generate the numbers */
            if (numericUpDown1.Value > 1000)
            {
                MessageBox.Show("Only up to 1000 unique random numbers can be generated at a time.", "Cannot generate the numbers");
            }
            else 
            {
                // Clear the contents of the richTextBox1 item, in order to make room for the new numbers
                richTextBox1.Clear();

                // Store the value of the numericUpDown1 item, so the program will remember it for later use
                number_of_random_numbers = numericUpDown1.Value;

                // The numbers array gets initialized, receiving as many places as the number of random numbers that the user wants generated
                numbers = new decimal[Convert.ToInt32(number_of_random_numbers)];

                // Generate each random number, then check if it's unique. 
                // If it's not unique, generate a new one and repeat the process until a unique number has been generated
                for (int i = 0; i < number_of_random_numbers; i++)
                {
                    do
                    {
                        // Generate the number
                        new_number = random.Next(1001);

                        // Set duplicate_found to false so we can check later if the generated number is unique
                        duplicate_found = false;

                        // Check if the generated number has already been generated
                        for (int j = 0; j < i; j++)
                        {
                            // If a duplicate is found, mark it and exit the loop, so that a new number will be generated in the next iteration of the do-while loop
                            if (numbers[j] == new_number)
                            {
                                // Set this to true to signify that the generated number isn't unique, so we can exit the for loop and generate a new number
                                duplicate_found = true;

                                // Exit the for loop
                                break;
                            }
                        }
                    } while (duplicate_found);

                    // Finally, insert the generated number into the numbers array
                    numbers[i] = new_number;
                }

                // Display all the generated numbers into the richTextBox item
                for (int i = 0; i < number_of_random_numbers; i++)
                {
                    richTextBox1.Text += numbers[i] + " ";
                }
            }
        }
    }
}