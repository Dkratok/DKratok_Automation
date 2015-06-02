using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Airline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Calc(object sender, EventArgs e)
        {
           
                PlaneCalculation PC = new PlaneCalculation();
                if (PC == null) throw new NullReferenceException();
                else
                {
                    this.textBox1.Text = PC.Crew().ToString();
                    this.textBox2.Text = PC.FlightRange().ToString();
                }
        }

        //Sorting, serialization, and deserialization the collection "planes" by Max Load parameter    
        private void XML_Ser_DeSer_Click(object sender, EventArgs e)
        {
            //Sorting
            AviaModel.Sortby();

            //Serialization the collection "planes" to XML file planes.dat
            Methods.XMLSerialization.XMLFileSerialization();

            List<AviaModel> DeserializedPlanes = Methods.XMLSerialization.DeserializeFromXML();
            
               

            //output to the Form
            string str = "";
            foreach (AviaModel deserializaAviamodel in AviaModel.planes)
            {
                str = str + "Make=" + deserializaAviamodel.Make.ToString() + " Board Number=" + deserializaAviamodel.BoardNum.ToString() + " Max Load=" + deserializaAviamodel.MaxLoad.ToString() + "\n";
            };
            this.richTextBox1.Text = "Object 'planes' has been serialized and deserialized"+"\n"+str;
             }
             

        private void button_FindPassPlane(object sender, EventArgs e)
        {
            int passquantity = 0;
            int maxFlightRange = 0;
            int maxFlightHeight = 0;
            
            string str = "";

            //tag1:
            try
            {
                passquantity = Convert.ToInt32(textBox6.Text);
                maxFlightRange = Convert.ToInt32(textBox4.Text);
                maxFlightHeight = Convert.ToInt32(textBox7.Text);
            }
            catch (FormatException)
            {
                this.richTextBox2.Text = "Error: Passenger Quatity, Max Flight Range, Flight Height must be integer and not NULL!";
                File.AppendAllText("../../PlaneByParameterLog.txt", "Error: Passenger Quatity, Max Flight Range, Flight Height must be integer and not NULL!" + "\n");
                return;
            }
                foreach (PassPlane PP in PassPlane.passengerplanes)
                {
                    if (PP.Passengers == passquantity & PP.Flightrange == maxFlightRange & PP.MaxFlightHeight == maxFlightHeight)
                    {
                        str = str + "Make=" + PP.Make.ToString() + " Board Number=" + PP.BoardNum.ToString() + " Passenger Quantity=" + PP.Passengers.ToString() + " Max Flight Range=" + maxFlightRange + " Max Flight Height=" + maxFlightHeight + "\n\n";
                        this.richTextBox2.Text = str + "\n";
                        File.AppendAllText("../../PlaneByParameterLog.txt", str + "\n"); 
                        break;
                    }                 
                }
                if (str == "")
                {
                    this.richTextBox2.Text = "There are no any airplanes with this parameters";
                    File.AppendAllText("../../PlaneByParameterLog.txt", "There are no any airplanes with this parameters" + "\n");
                }
        }


        
        private void button_FindCargoPlane(object sender, EventArgs e) 
        {
        int cargoload = 0;
        int maxFlightRange = 0;
        string str="";
           
            
                try
                {
                    cargoload = Convert.ToInt32(textBox3.Text);
                    maxFlightRange = Convert.ToInt32(textBox5.Text);
                }
                catch (FormatException)
                {
                    this.richTextBox2.Text = "Error: Max Cargo Load, Flight Range, must be integer and not NULL!";
                    File.AppendAllText("../../PlaneByParameterLog.txt", "Error: Max Cargo Load, Flight Range, must be integer and not NULL!" + "\n");
                    return;
                }
            

                foreach (CargoAirplane CA in CargoAirplane.cargoplanes)
                {
                    if (CA.MaxCargoLoad == cargoload && CA.Flightrange == maxFlightRange)
                    {
                        str = str + "Max Cargo Load= " + CA.MaxCargoLoad.ToString() + ", Max Load = " + CA.MaxLoad.ToString() + ", Crew = " + CA.Crew.ToString() + ", Flight Range = " + CA.Flightrange.ToString() + ", Max Fligh Height= " + CA.MaxFlightHeight.ToString() + "Make = " + CA.Make.ToString() + ", Board Number = " + CA.BoardNum.ToString() + ", Military = " + CA.IsMilitary.ToString() + "\n\n";
                        this.richTextBox2.Text = str + "\n";
                        File.AppendAllText("../../PlaneByParameterLog.txt", str + "\n"); 
                        break;
                    }
                   
                }
                if (str == "")
                {
                    this.richTextBox2.Text = "There are no any airplanes with this parameters";
                    File.AppendAllText("../../PlaneByParameterLog.txt", "There are no any airplanes with this parameters" + "\n");
                }
        }
        
        private void button5_GetWholeCollection(object sender, EventArgs e)
        {
            
            string str = "";
            foreach (PassPlane PP in PassPlane.passengerplanes)
            {

                if (PP is PassPlane)
                {
                    str = str + "Make=" + PP.Make.ToString() + " Board Number=" + PP.BoardNum.ToString() + " Passenger Qquantity=" + PP.Passengers.ToString() + " Max Flight Range=" + PP.Flightrange.ToString() + " Max Flight Height=" + PP.MaxFlightHeight.ToString() + "\n\n";
                              
                }
               
            }

            foreach (CargoAirplane CP in CargoAirplane.cargoplanes)
            {
                if (CP is CargoAirplane)
                {
                    str = str + "Max Cargo Load= " + CP.MaxCargoLoad.ToString() + ", Max Load = " + CP.MaxLoad.ToString() + ", Crew = " + CP.Crew.ToString() + ", Flight Range = " + CP.Flightrange.ToString() + ", Max Fligh Height= " + CP.MaxFlightHeight.ToString() + "Make = " + CP.Make.ToString() + ", Board Number = " + CP.BoardNum.ToString() + ", Military = " + CP.IsMilitary.ToString() + "\n\n";
                    
                }
               
            }

            foreach (Helicopter Hel in Helicopter.helicopters)
            {
                if (Hel is Helicopter)
                {
                    str = str + "Make= " + Hel.Make + ", Passengers= " + Hel.Passengers + ", Max Cargo Load= " + Hel.MaxCargoLoad.ToString() + ", Max Load = " + Hel.MaxLoad.ToString() + ", Crew = " + Hel.Crew.ToString() + ", Flight Range = " + Hel.Flightrange.ToString() + ", Max Fligh Height= " + Hel.MaxFlightHeight.ToString() + ", Board Number = " + Hel.BoardNum.ToString() + ", Military = " + Hel.IsMilitary.ToString() + "\n\n";
                }
            }

            File.WriteAllText("../../Avia.txt", str);
            try
            {
                this.richTextBox3.Text = "The collection has been written and read from text file\n\n" + File.ReadAllText("../../Avia.txt");
            }
            catch (FileNotFoundException)
            {
                this.richTextBox3.Text = "File Avia.txt is not found";
            }
            finally
            {
                this.richTextBox3.Text = str + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Boardnumber = textBox8.Text.ToString();

            int CommonTicketPrice=Airline.Methods.TicketsCalc.CommonTicketPrice(Boardnumber);
            double AvTicketPrice = 0;
            try
            {
                AvTicketPrice = Airline.Methods.TicketsCalc.AverageTicketPrice(Boardnumber);
            }
            catch (DivideByZeroException)
            {
                richTextBox4.Text = "Passenger quantity is 0. Cannot divide by zero";
                return;
            }
            richTextBox4.Text = Boardnumber+"\n"+"Business Class Ticket Price = " + Airline.Methods.TicketsCalc.BusinessClassTicketPrice + "\n" + "First Class Ticket Price = " + Airline.Methods.TicketsCalc.FirstClassTicketPrice + "\n" + "Other Ticket Price = " + Airline.Methods.TicketsCalc.OtherTicketPrice + "\n" + "Common Price of All Tickets = " + CommonTicketPrice + "\n" + "Averige Ticket Price = " + AvTicketPrice + "\n";
        }

        private void JSON_Ser_DeSer_Click(object sender, EventArgs e)
        {
            AviaModel.Sortby();

            Methods.JSONSerealization jsonserial = new Methods.JSONSerealization();
            jsonserial.JSONSerealiz("../../JSON.JSON");
            this.richTextBox1.Text = "Object 'planes' has been serialized in JSON and deserialized" + "\n"+jsonserial.JSONDeserealiz("../../JSON.JSON").ToString();

            string str = "";
            foreach (AviaModel jsondeserializaAviamodel in AviaModel.planes)
            {
                str = str + "Make=" + jsondeserializaAviamodel.Make.ToString() + " Board Number=" + jsondeserializaAviamodel.BoardNum.ToString() + " Max Load=" + jsondeserializaAviamodel.MaxLoad.ToString() + "\n";
            };
            this.richTextBox1.Text = "Object 'planes' has been serialized in JSON and deserialized" + "\n" + str;
        }
    }
}

