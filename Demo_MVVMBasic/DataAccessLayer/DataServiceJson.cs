using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Demo_MVVMBasic.DataAccessLayer
{
    public class DataServiceJson : IDataService
    {
        private string _dataFilePath;
        private List<Widget> _widgets;


        /// <summary>
        /// read the json file and load a list of widget objects
        /// </summary>
        /// <returns>list of widgets</returns>
        public IEnumerable<Widget> ReadAll()
        {
            List<Widget> widgets;

            try
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    string jsonString = sr.ReadToEnd();

                    widgets = JsonConvert.DeserializeObject<List<Widget>>(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return widgets;
        }

        /// <summary>
        /// write the current list of widgets to the json data file
        /// </summary>
        /// <param name="widgets">list of widgets</param>
        public void WriteAll()
        {
            string jsonString = JsonConvert.SerializeObject(_widgets, Formatting.Indented);

            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                {
                    writer.WriteLine(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        IEnumerable<Widget> IDataService.GetAll()
        {
            return ReadAll();
        }

        Widget IDataService.GetById(string name)
        {
            return _widgets.FirstOrDefault(w => w.Name == name);
        }

        void IDataService.Add(Widget widget)
        {
            _widgets.Add(widget);
            WriteAll();
        }

        void IDataService.Update(Widget widget)
        {
            _widgets.Remove(_widgets.FirstOrDefault(w => w.Name == widget.Name));
            _widgets.Add(widget);
            WriteAll();
        }

        void IDataService.Delete(string name)
        {
            _widgets.Remove(_widgets.FirstOrDefault(w => w.Name == name));
            WriteAll();
        }

        public DataServiceJson()
        {
            _dataFilePath = DataServiceConfig.DataPathJson;
            _widgets = ReadAll() as List<Widget>;
        }
    }
}
