using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Demo_MVVMBasic.DataAccessLayer
{
    public class DataServiceXml : IDataService
    {
        private string _dataFilePath;
        private List<Widget> _widgets;

        /// <summary>
        /// read the xml file and load a list of widget objects
        /// </summary>
        /// <returns>list of widgets</returns>
        public IEnumerable<Widget> ReadAll()
        {
            List<Widget> widgets = new List<Widget>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Widget>));

            try
            {
                StreamReader reader = new StreamReader(_dataFilePath);
                using (reader)
                {
                    widgets = (List<Widget>)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return widgets;
        }

        /// <summary>
        /// write the current list of widgets to the xml data file
        /// </summary>
        /// <param name="_widgets">list of widgets</param>
        public void WriteAll()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Widget>), new XmlRootAttribute("Widgets"));

            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                {
                    serializer.Serialize(writer, _widgets);
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

        public DataServiceXml()
        {
            _dataFilePath = DataServiceConfig.DataPathXml;
            _widgets = ReadAll() as List<Widget>;
        }
    }
}
