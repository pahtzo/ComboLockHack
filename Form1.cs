/*
 *  Combination Padlock Hacker
 *  
 *  For assiting with the math involved in calcuating the digits of a typical 0-39 combination padlock.
 *
 *  MIT License
 *  
 *  Copyright (c) 2023 pahtzo
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 *
 *  Credits to:
 *  The SANS Holiday Hack Challenge 2023
 *  https://www.sans.org/mlp/holiday-hack-challenge-2023/
 *  
 *  Helpful Lock Picker
 *  https://www.youtube.com/watch?v=27rE5ZvWLU0
 *  https://docs.google.com/document/d/1QhKZLDr22G0RpuTSGm0M6pz4dG82IByesim3elwfw98/edit
 *  
 *  Flaticon for the lock icon.
 *  https://www.flaticon.com/free-icons/combination
 */

using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace ComboLockHack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_stickynum.Text = "0";
            comboBox_guess_even.Text = "0";
            comboBox_guess_odd.Text = "1";
            comboBox_stickynum.SelectedIndex = 0;
            comboBox_guess_even.SelectedIndex = 0;
            comboBox_guess_odd.SelectedIndex = 0;
            comboBox_stickynum.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_guess_even.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_guess_odd.DropDownStyle = ComboBoxStyle.DropDownList;
            calculateCombinations(this, null);
        }

        private void calculateCombinations(object sender, EventArgs e)
        {
            int combo_mod = 0;
            int first_digit = 0;
            int guess_num_odd = 0;
            int guess_num_even = 0;
            int[] third_digits = new int[8];
            int[] second_digits = new int[10];

            /*
             *  Grab the "sticky" number, add 5 MOD 40 to get the first digit in the combo.
             *  Get the combination modulus from the first digit MOD 4 for future calculations.
             */
            first_digit = (Convert.ToInt32(comboBox_stickynum.Items[comboBox_stickynum.SelectedIndex].ToString()) + 5) % 40;
            combo_mod = first_digit % 4;

            /*
             *  If the first digit is even, the guess number is also even, and vice-versa for odd.
             *  Because of this, we don't need to find the opposite odd or even guess number.
             */
            if(first_digit % 2 == 0)
            {
                comboBox_guess_even.Enabled = true;
                comboBox_guess_odd.Enabled = false;
                label5.Enabled = true;
                label5.ForeColor = System.Drawing.Color.Green;
                label4.Enabled = false;
            }
            else
            {
                comboBox_guess_even.Enabled = false;
                comboBox_guess_odd.Enabled = true;
                label5.Enabled = false;
                label4.Enabled = true;
                label4.ForeColor = System.Drawing.Color.Green;
            }

            guess_num_odd = Convert.ToInt32(comboBox_guess_odd.Items[comboBox_guess_odd.SelectedIndex].ToString());
            guess_num_even = Convert.ToInt32(comboBox_guess_even.Items[comboBox_guess_even.SelectedIndex].ToString());

            /*
             *  Fill the third number array with guess numbers.  Add 10 to each previous number 3 times.
             *  If the guess numbers are say 2 and 5 then the array will be:
             *  2, 12, 22, 32, 5, 15, 25, 35
             */
            for(int x = 0; x < third_digits.Length / 2; x++)
            {
                third_digits[x] = (guess_num_odd + (x * 10)) % 40;
                third_digits[x + third_digits.Length / 2] = (guess_num_even + (x * 10)) % 40;
            }

            /*
             *  Using the third_digits array, find each element's remainder from element MOD 4.
             *  If the remainder doesn't match our combination modulus, ("sticky" number + 5 MOD 40) MOD 4, then set it to -1.
             *  We'll sort it later and grab the last two elements as they will be the two
             *  options for the third digit in the combo.
             *  2, 12, 22, 32, 5, 15, 25, 35 -> -1, -1, -1, -1, -1, -1, 12, 32
             */
            for (int x = 0; x < third_digits.Length; x++)
            {
                if(third_digits[x] % 4 != combo_mod)
                {
                    third_digits[x] = -1;
                }
            }

            /*
             *  Fill the two second number arrays using the combo modulus + 2 and combo modulus + 6,
             *  then add 8 to each previous element 4 times with MOD 40.
             *  
             *  This will look like:
             *  2, 10, 18, 26, 34, 6, 14, 22, 30, 38
             *  
             *  Changed this to have two second number arrays, one for third digit A, and one for third digit B,
             *  eliminating any digits that are within 2 of each third digit candidate.
             *  That will get us from 10 options to 8.
             *  So for this list it will look like:
             *  
             *  2, 6, 10, 14, 18, 22, 26, 30, 34, 38
             *  
             */
            for (int x = 0; x < second_digits.Length / 2; x++)
            {
                second_digits[x] = (combo_mod + 2 + (x * 8)) % 40;
                second_digits[x + second_digits.Length / 2] = (combo_mod + 6 + (x * 8)) % 40;
            }

            // Sort the third digit array and grab the last two elements into a new, smaller array.
            Array.Sort(third_digits);
            int[] t = new int[2];
            t[0] = third_digits[third_digits.Length - 2];
            t[1] = third_digits[third_digits.Length - 1];

            int[] second_digitsA = new int[second_digits.Length];
            int[] second_digitsB = new int[second_digits.Length];
            
            Array.Copy(second_digits, second_digitsA, second_digitsA.Length);
            Array.Copy(second_digits, second_digitsB, second_digitsB.Length);

            // A painful way to account for negative digits and wrapping backwards MOD 40.
            int[] within_two_A = {
                (t[0] - 2) % 40 < 0 ? ((t[0] - 2) % 40) + 40 : (t[0] - 2) % 40,
                (t[0] - 1) % 40 < 0 ? ((t[0] - 1) % 40) + 40 : (t[0] - 1) % 40,
                t[0],
                (t[0] + 1) % 40,
                (t[0] + 2) % 40
            };
            int[] within_two_B = {
                (t[1] - 2) % 40 < 0 ? ((t[1] - 2) % 40) + 40 : (t[1] - 2) % 40,
                (t[1] - 1) % 40 < 0 ? ((t[1] - 1) % 40) + 40 : (t[1] - 1) % 40,
                t[1],
                (t[1] + 1) % 40,
                (t[1] + 2) % 40
            };

            /*
             * Remove any second digits within 2 of the third digits.
             * Since the third digit A and B candidates are 12 and 32
             * in our example, our two second digit arrays will be:
             *
             * A: 2, 6, 18, 22, 26, 30, 34, 38
             * B: 2, 6, 10, 14, 18, 22, 26, 38
             * 
             */
            second_digitsA = second_digitsA.Except(within_two_A).ToArray();
            second_digitsB = second_digitsB.Except(within_two_B).ToArray();

            // Sort the arrays
            Array.Sort(second_digitsA);
            Array.Sort(second_digitsB);

            // Print it all out into the text box for the lockpicker.
            String strsecondA = String.Join(", ", second_digitsA);
            String strsecondB = String.Join(", ", second_digitsB);

            StringBuilder sb = new StringBuilder();

            sb.Append("Set A Combinations :\r\n");
            for (int x = 0; x < second_digitsA.Length; x++)
            {
                sb.AppendFormat("{0:D} - ", first_digit);
                sb.AppendFormat("{0:D} - ", second_digitsA[x]);
                sb.AppendFormat("{0:D}", t[0]);
                sb.AppendLine();
            }

            sb.Append("\r\nSet B Combinations :\r\n");
            for (int x = 0; x < second_digitsB.Length; x++)
            {
                sb.AppendFormat("{0:D} - ", first_digit);
                sb.AppendFormat("{0:D} - ", second_digitsB[x]);
                sb.AppendFormat("{0:D}", t[1]);
                sb.AppendLine();
            }

            String outstr = "";
            outstr = sb.ToString();

            textBox1.Text =
                "Combination Modulus   : " + combo_mod.ToString() + "\r\n" +
                "First Digit           : " + first_digit.ToString() + "\r\n\r\n" +
                "Second Digits - Set A : " + strsecondA + "\r\n" +
                "Third Digit -   Set A : " + t[0] + "\r\n\r\n" +
                "Second Digits - Set B : " + strsecondB + "\r\n" +
                "Third Digit -   Set B : " + t[1] + "\r\n\r\n" +
                outstr
                ;
        }

        private void comboBox_firstnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateCombinations(this,null);
        }

        private void comboBox_guessnum2_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateCombinations(this, null);
        }

        private void comboBox_guessnum1_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateCombinations(this, null);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://docs.google.com/document/d/1QhKZLDr22G0RpuTSGm0M6pz4dG82IByesim3elwfw98/",
                UseShellExecute = true
            });

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.youtube.com/watch?v=27rE5ZvWLU0",
                UseShellExecute = true
            });
        }
    }
}
