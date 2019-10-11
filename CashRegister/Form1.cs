using System;
using System.Drawing;
using System.Threading;
using System.Media;
using System.Windows.Forms;
/// <summary>
/// Seamus Kittmer Cash Register Sumative october 11/19
/// </summary>
namespace CashRegister
{
    public partial class reciptLabel : Form
    {
        const double TAXRATE = 0.13;
        const int ANTIPASTOPRICE = 7;
        const int PASTAPRICE = 9;
        const int PIZZAPRICE = 12;
        double numAntipasto;
        double numPasta;
        double numPizza;
        double subTotalPrice;
        double taxAmount;
        double totalPrice;
        double tendered;
        double cashBack;
        public reciptLabel()
        {
            InitializeComponent();
        }
        private void PrintReciptButton_Click(object sender, EventArgs e)
        {
             // reciving input from user adn converting to numbers
             numAntipasto = Convert.ToDouble(antipastoUpDown.Value);
             numPasta = Convert.ToDouble(pastaUpDown.Value);
             numPizza = Convert.ToDouble(pizzaUpDown.Value);

             //calculating the subtotal, tax amount, total  

             subTotalPrice = numAntipasto * ANTIPASTOPRICE + numPasta + numPasta * PASTAPRICE + numPizza * PIZZAPRICE;

             taxAmount = TAXRATE * subTotalPrice;

             totalPrice = subTotalPrice + taxAmount;

             // printing out the subtotal, tax value, adn total for the bill 

             subtotalLabel.Text = (subTotalPrice.ToString("C"));
             taxLabel.Text = (taxAmount.ToString("C"));
             totalLabel.Text = (totalPrice.ToString("C"));
        }
        private void CashBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Reciving tenderd cash from customer
                tendered = Convert.ToDouble(tenderTextBox.Text);

                // calculating cash back for customer
                cashBack = tendered - totalPrice;

                //Printing the cash back
                cashBackLabel.Text = (cashBack.ToString("C"));
            }
            catch
            {
                // telling user the input a numeric value

                youreWrongLabel.Text = "Please type the correct change for the order";
                return;
            }
        }
        private void ReciptButton_Click(object sender, EventArgs e)
        {
            //Graphics var, font var, brush var
            Graphics g = reciptPrintLabel.CreateGraphics();

            Font reciptFont = new Font("Courier New", 10);

            SolidBrush blackBrush = new SolidBrush(Color.Black);

            SoundPlayer printSound = new SoundPlayer(Properties.Resources.print);

            //Printing the num of dishes ordered
            printSound.Play();
            g.DrawString("Antipasto x " + numAntipasto +" @ "+ ANTIPASTOPRICE.ToString("C"), reciptFont, blackBrush, 0,0 );
            Thread.Sleep(450);
            g.DrawString("Pasta     x " + numPasta +" @ "+ PASTAPRICE.ToString("C"), reciptFont, blackBrush, 0, 20);
            Thread.Sleep(450);
            g.DrawString("Pizza     x " + numPizza + " @ "+PIZZAPRICE.ToString("C"), reciptFont, blackBrush, 0, 40);
            Thread.Sleep(450);
            g.DrawString("-----------", reciptFont, blackBrush, 0, 50);

            //End of the food ordered

            //Subtotal, total , tax value
            Thread.Sleep(450);
            printSound.Play(); 

            g.DrawString("Subtotal      : " + subTotalPrice.ToString("C") , reciptFont, blackBrush, 0, 80);

            Thread.Sleep(450);

            g.DrawString("Tax @ 13% GST : " + taxAmount.ToString("C"), reciptFont, blackBrush, 0, 100);

            Thread.Sleep(450);

            g.DrawString("Total         : " + totalPrice.ToString("C"), reciptFont, blackBrush, 0, 120);

            //Cash tenderd, and cash back 
            printSound.Play();

            g.DrawString("Cash Tendered : " + tendered.ToString("C"), reciptFont, blackBrush, 0, 170);

            Thread.Sleep(450);

            g.DrawString("Cash Back     : " + cashBack.ToString("C"), reciptFont, blackBrush, 0, 190);

            //Phone number of resturant adress ect

            printSound.Play();

            g.DrawString("Call Big Toney's @ 416-462-0967" + tendered.ToString("C"), reciptFont, blackBrush, 0, 220);

            g.DrawString("3362 Bloor St. Etobicoke, ON  " + tendered.ToString("C"), reciptFont, blackBrush, 0, 240);

            g.DrawString("   Thank You For Eating \n\n With Us Today", reciptFont, blackBrush, 0, 280);
        }
        private void NewCoustomerButton_Click(object sender, EventArgs e)
        {
            // making all of the labels, vars, up downs, and textboxes = nothing or zero so that the register is reset 
            numAntipasto=0;
            numPasta=0 ;
            numPizza=0;
            subTotalPrice=0;
            taxAmount=0;
            totalPrice=0;
            tendered=0;
            cashBack=0;
            antipastoUpDown.Value = 0;
            pastaUpDown.Value = 0;
            pizzaUpDown.Value = 0 ;
            subtotalLabel.Text = " ";
            taxLabel.Text = " ";
            totalLabel.Text = " ";
            tenderTextBox.Text = "";
            cashBackLabel.Text = "";
            reciptPrintLabel.Text = " ";
        }
    }
}
