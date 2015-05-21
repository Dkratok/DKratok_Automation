using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace Airline.Methods
{
    [Serializable]
    class JSONSerealization
    {
        public void JSONSerealiz(string Jsonfilename)
        {
            string jsonAviaPark = JsonConvert.SerializeObject(AviaModel.planes);
            File.AppendAllText(Jsonfilename, jsonAviaPark + "\n");
        }
        public List<AviaModel> JSONDeserealiz(string Jsonfilename)
        {
            string jsonfilecontent = "";
            jsonfilecontent = File.ReadAllText(Jsonfilename);
            List<AviaModel> jsonplanes = JsonConvert.DeserializeObject<List<AviaModel>>(jsonfilecontent); 
            return jsonplanes;
        }

    }
}
