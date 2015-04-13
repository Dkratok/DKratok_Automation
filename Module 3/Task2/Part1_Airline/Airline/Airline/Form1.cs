using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Passquantitycalc PC = new Passquantitycalc();


            this.textBox1.Text = PC.Passquantity().ToString();
            this.textBox2.Text = PC.Maxload().ToString(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Sorting.Sort1();
            string str = "";
            foreach (Helicopter Helic in Aviapark.helicopters)
            {
                str = str + "Make=" + Helic.Make.ToString() + " Board Number=" + Helic.BoardNum.ToString() + " Max Cargo Load=" + Helic.MaxCargoLoad.ToString() + "\n";
            };
            this.richTextBox1.Text = str;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int passquantity = 0;
            int maxFlightRange = 0;
            int maxFlightHeight = 0;
            
            string str = "";
            if (textBox6.Text !="" & textBox4.Text !="" & textBox7.Text !="")
            {
                passquantity = Convert.ToInt32(textBox6.Text);
                maxFlightRange = Convert.ToInt32(textBox4.Text);
                maxFlightHeight = Convert.ToInt32(textBox7.Text);
                foreach (PassPlane PP in Aviapark.passengerplanes)
                {
                    if (PP.Passengers == passquantity & PP.Flightrange == maxFlightRange & PP.MaxFlightHeight == maxFlightHeight)
                    {
                        str = str + "Make=" + PP.Make.ToString() + " Board Number=" + PP.BoardNum.ToString() + " Passenger Qquantity=" + PP.Passengers.ToString() + " Max Flight Range=" + maxFlightRange + " Max Flight Height=" + maxFlightHeight + "\n\n";
                        this.richTextBox2.Text = str + "\n";
                        break;
                    }
                    else
                    {
                        this.richTextBox2.Text = "There are no any airplanes with this parameters";
                    }
                }
               
            }
            else
            {
                                        
                this.richTextBox2.Text = "Error: Passenger Quatity, Max Flight Range, Max Flight Height must be integer and not NULL!";
                this.richTextBox2.ForeColor = Color.Red;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Helstr = "";
             foreach (Helicopter Helic in Aviapark.helicopters)
            {
                Helstr = Helstr + "Make = " + Helic.Make.ToString() + ", Passengers= " + Helic.Passengers.ToString() + ", Max Cargo Load = " + Helic.MaxCargoLoad.ToString() + ", Max Load = " + Helic.MaxLoad.ToString() + ", Crew = " + Helic.Crew.ToString() + ", Flight Range = " + Helic.Flightrange.ToString() + ", Fligh Height= " + Helic.MaxFlightHeight.ToString() + ", Board Number = " + Helic.BoardNum.ToString() + ", Military = " + Helic.IsMilitary.ToString() + "\n\n";
            };
             this.richTextBox5.Text = Helstr;

            string Passstr = "";
            foreach (PassPlane PP in Aviapark.passengerplanes)
            {
                Passstr = Passstr + "Passengers= " + PP.Passengers.ToString() + ", Business Class Passengers= " + PP.BusinessClassPassengers.ToString() + ", First Class Passengers= " + PP.FirstClassPassengers.ToString() + "Max Load" + PP.MaxLoad.ToString() + ", Crew = " + PP.Crew.ToString() + ", Flight Range = " + PP.Flightrange.ToString() + ", Max Fligh Height= " + PP.MaxFlightHeight.ToString() + "Make = " + PP.Make.ToString() + ", Board Number = " + PP.BoardNum.ToString() + ", Military = " + PP.IsMilitary.ToString() + "\n\n";
            };
            this.richTextBox3.Text = Passstr;

             string Cargostr = "";
            foreach (CargoAirplane CP in Aviapark.cargoplanes)
            {
                Cargostr = Cargostr + "Max Cargo Load= " + CP.MaxCargoLoad.ToString() + ", Max Load = " + CP.MaxLoad.ToString() + ", Crew = " + CP.Crew.ToString() + ", Flight Range = " + CP.Flightrange.ToString() + ", Max Fligh Height= " + CP.MaxFlightHeight.ToString() + "Make = " + CP.Make.ToString() + ", Board Number = " + CP.BoardNum.ToString() + ", Military = " + CP.IsMilitary.ToString() + "\n\n";
            };
            this.richTextBox4.Text = Cargostr;
   
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cargoload = 0;
            int maxFlightRange = 0;
            

            string str = "";
            if (textBox3.Text != "" & textBox5.Text != "")
            {
                cargoload = Convert.ToInt32(textBox3.Text);
                maxFlightRange = Convert.ToInt32(textBox5.Text);

                foreach (CargoAirplane CP in Aviapark.cargoplanes)
                {
                    if (CP.MaxCargoLoad == cargoload && CP.Flightrange == maxFlightRange)
                    {
                        str = str + "Max Cargo Load= " + CP.MaxCargoLoad.ToString() + ", Max Load = " + CP.MaxLoad.ToString() + ", Crew = " + CP.Crew.ToString() + ", Flight Range = " + CP.Flightrange.ToString() + ", Max Fligh Height= " + CP.MaxFlightHeight.ToString() + "Make = " + CP.Make.ToString() + ", Board Number = " + CP.BoardNum.ToString() + ", Military = " + CP.IsMilitary.ToString() + "\n\n";
                        this.richTextBox2.Text = str + "\n";
                        break;
                    }
                    else
                    {
                        this.richTextBox2.Text = "There are no any airplanes with this parameters";
                    }
                }

            }
            else
            {

                this.richTextBox2.Text = "Error: Max Cargo Load, Flight Range, must be integer and not NULL!";
                this.richTextBox2.ForeColor = Color.Red;
            }
        }
    }
}

